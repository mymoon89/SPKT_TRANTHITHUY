// fbodrawbuffers.cpp
// OpenGL SuperBible, Chapter 18
// Demonstrates multiple render targets with FBOs
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"   // OpenGL toolkit

#include <assert.h>
#include <stdio.h>

GLboolean npotTexturesAvailable = GL_FALSE;
GLboolean useDrawBuffers = GL_TRUE;     // Use FBOs + drawbuffers vs. multipass
GLboolean doProcessing = GL_TRUE;       // Show scene using FBOs and post-processing

GLint windowWidth = 512;                // window size
GLint windowHeight = 512;

GLint fboWidth = 0;                     // set based on window size
GLint fboHeight = 0;
GLuint wallTextureID[4];                // textures for walls
GLuint renderTextureID[5];              // 1 in 1st pass and up to 4 simultaneous render targets in 2nd
GLint maxTexSize;                       // maximum allowed size for our 2D textures
GLint maxTexUnits;                      // maximum number of texture image units
GLint maxDrawBuffers;                   // maximum number of drawbuffers supported
GLint maxColorAttachments;              // maximum number of FBO color attachments

#define TOTAL_SHADERS 6
GLuint fShader[TOTAL_SHADERS], progObj[TOTAL_SHADERS];          // shader object names
GLboolean needsValidation[TOTAL_SHADERS];
char *shaderNames[TOTAL_SHADERS] = {"multirender", "combine", "blur", "laplacian", "grayscale", "colorinvert"};

GLuint framebufferID[2];                // FBO names
GLuint renderbufferID;                  // renderbuffer object name
GLint maxRenderbufferSize;              // maximum allowed size for FBO renderbuffer
GLfloat texCoordOffsets[18];

GLfloat ambientLight[] = { 0.4f, 0.4f, 0.4f, 1.0f};
GLfloat diffuseLight[] = { 0.6f, 0.6f, 0.6f, 1.0f};
GLfloat specularLight[] = { 1.0f, 1.0f, 1.0f, 1.0f};
GLfloat lightPos[]     = { 0.0f, 125.0f, 0.0f, 1.0f};

GLfloat cameraPos[]    = { 50.0f, 50.0f, 100.0f, 1.0f};
GLdouble cameraZoom = 1.5;

GLfloat animationAngle = 0.0f;          // used to spin objects

#define MAX_INFO_LOG_SIZE 2048

// Load shader from disk into a null-terminated string
GLchar *LoadShaderText(const char *fileName)
{
    GLchar *shaderText = NULL;
    GLint shaderLength = 0;
    FILE *fp;

    fp = fopen(fileName, "r");
    if (fp != NULL)
    {
        while (fgetc(fp) != EOF)
        {
            shaderLength++;
        }
        rewind(fp);
        shaderText = (GLchar *)malloc(shaderLength+1);
        if (shaderText != NULL)
        {
            fread(shaderText, 1, shaderLength, fp);
        }
        shaderText[shaderLength] = '\0';
        fclose(fp);
    }

    return shaderText;
}

// Compile shaders
void PrepareShader(GLint shaderNum)
{
    char fullFileName[255];
    GLchar *fsString;
    const GLchar *fsStringPtr[1];
    GLint success;

    // Create shader objects and specify shader text
    sprintf(fullFileName, "./shaders/%s.fs", shaderNames[shaderNum]);
    fsString = LoadShaderText(fullFileName);
    if (!fsString)
    {
        fprintf(stderr, "Unable to load \"%s\"\n", fullFileName);
        Sleep(5000);
        exit(0);
    }
    fShader[shaderNum] = glCreateShader(GL_FRAGMENT_SHADER);
    fsStringPtr[0] = fsString;
    glShaderSource(fShader[shaderNum], 1, fsStringPtr, NULL);
    free(fsString);

    // Compile shaders and check for any errors
    glCompileShader(fShader[shaderNum]);
    glGetShaderiv(fShader[shaderNum], GL_COMPILE_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(fShader[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        fprintf(stderr, "Error in fragment shader #%d compilation!\n", shaderNum);
        fprintf(stderr, "Info log: %s\n", infoLog);
        Sleep(10000);
        exit(0);
    } else
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(fShader[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        //fprintf(stderr, "Fragment shader #%d compile info log: %s\n", shaderNum, infoLog);
    }

    // Create program object, attach shader, then link
    progObj[shaderNum] = glCreateProgram();
    glAttachShader(progObj[shaderNum], fShader[shaderNum]);

    glLinkProgram(progObj[shaderNum]);
    glGetProgramiv(progObj[shaderNum], GL_LINK_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetProgramInfoLog(progObj[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        fprintf(stderr, "Error in program #%d linkage!\n", shaderNum);
        fprintf(stderr, "Info log: %s\n", infoLog);
        Sleep(10000);
        exit(0);
    }
    else
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetProgramInfoLog(progObj[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        //fprintf(stderr, "Program #%d link info log: %s\n", shaderNum, infoLog);
    }

    // Program object has changed, so we should revalidate
    needsValidation[shaderNum] = GL_TRUE;
}

// Called to draw scene objects
void DrawModels(GLboolean drawTeapot)
{
    // Draw plane that the objects rest on
    glColor3f(0.0f, 0.0f, 0.90f); // Blue
    glNormal3f(0.0f, 1.0f, 0.0f);
    glBegin(GL_QUADS);
        glVertex3f(-100.0f, -25.0f, -100.0f);
        glVertex3f(-100.0f, -25.0f, 100.0f);		
        glVertex3f(100.0f,  -25.0f, 100.0f);
        glVertex3f(100.0f,  -25.0f, -100.0f);
    glEnd();

    // Draw walls
    glEnable(GL_TEXTURE_2D);
    glBindTexture(GL_TEXTURE_2D, wallTextureID[0]);
    glColor3f(1.0f, 1.0f, 1.0f);
    glNormal3f(1.0f, 0.0f, 0.0f);
    glBegin(GL_QUADS);
        glTexCoord2f(0.0f, 0.0f);
        glVertex3f(-100.0f, -25.0f, 100.0f);		
        glTexCoord2f(0.0f, 1.0f);
        glVertex3f(-100.0f,  125.0f, 100.0f);
        glTexCoord2f(1.0f, 1.0f);
        glVertex3f(-100.0f,  125.0f, -100.0f);
        glTexCoord2f(1.0f, 0.0f);
        glVertex3f(-100.0f, -25.0f, -100.0f);
    glEnd();
    glBindTexture(GL_TEXTURE_2D, wallTextureID[2]);
    glNormal3f(-1.0f, 0.0f, 0.0f);
    glBegin(GL_QUADS);
        glTexCoord2f(0.0f, 0.0f);
        glVertex3f(100.0f, -25.0f, -100.0f);
        glTexCoord2f(0.0f, 1.0f);
        glVertex3f(100.0f,  125.0f, -100.0f);
        glTexCoord2f(1.0f, 1.0f);
        glVertex3f(100.0f,  125.0f, 100.0f);
        glTexCoord2f(1.0f, 0.0f);
        glVertex3f(100.0f, -25.0f, 100.0f);		
    glEnd();
    glBindTexture(GL_TEXTURE_2D, wallTextureID[1]);
    glNormal3f(0.0f, 0.0f, 1.0f);
    glBegin(GL_QUADS);
        glTexCoord2f(0.0f, 0.0f);
        glVertex3f(-100.0f, -25.0f, -100.0f);
        glTexCoord2f(0.0f, 1.0f);
        glVertex3f(-100.0f, 125.0f, -100.0f);		
        glTexCoord2f(1.0f, 1.0f);
        glVertex3f(100.0f,  125.0f, -100.0f);
        glTexCoord2f(1.0f, 0.0f);
        glVertex3f(100.0f,  -25.0f, -100.0f);
    glEnd();
    glBindTexture(GL_TEXTURE_2D, wallTextureID[3]);
    glNormal3f(0.0f, 0.0f, -1.0f);
    glBegin(GL_QUADS);
        glTexCoord2f(0.0f, 0.0f);
        glVertex3f(100.0f, -25.0f, 100.0f);		
        glTexCoord2f(0.0f, 1.0f);
        glVertex3f(100.0f,  125.0f, 100.0f);
        glTexCoord2f(1.0f, 1.0f);
        glVertex3f(-100.0f, 125.0f, 100.0f);
        glTexCoord2f(1.0f, 0.0f);
        glVertex3f(-100.0f, -25.0f, 100.0f);
    glEnd();
    glDisable(GL_TEXTURE_2D);

    // Draw ceiling
    glColor3f(1.0f, 0.6f, 0.6f); // pale red
    glNormal3f(0.0f, -1.0f, 0.0f);
    glBegin(GL_QUADS);
        glVertex3f(-100.0f, 125.0f, -100.0f);
        glVertex3f(-100.0f, 125.0f, 100.0f);		
        glVertex3f(100.0f,  125.0f, 100.0f);
        glVertex3f(100.0f,  125.0f, -100.0f);
    glEnd();

    if (drawTeapot)
    {
        // Draw orange teapot
        glColor3f(1.0f, 0.6f, 0.4f);
        glFrontFace(GL_CW);
        glutSolidTeapot(25.0f);
        glFrontFace(GL_CCW);
    }

    // Draw green sphere
    glColor3f(0.0f, 1.0f, 0.0f);
    glPushMatrix();
    glRotatef(animationAngle, 0.0f, 1.0f, 0.0f);
    glTranslatef(-60.0f, 0.0f, 0.0f);
    glutSolidSphere(25.0f, 50, 50);
    glPopMatrix();

    // Draw yellow cone
    glColor3f(1.0f, 1.0f, 0.0f);
    glPushMatrix();
    glRotatef(animationAngle, 0.0f, 1.0f, 0.0f);
    glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);
    glTranslatef(60.0f, 0.0f, -24.0f);
    glutSolidCone(25.0f, 50.0f, 50, 50);
    glPopMatrix();

    // Draw magenta torus
    glColor3f(1.0f, 0.0f, 1.0f);
    glPushMatrix();
    glRotatef(animationAngle, 0.0f, 1.0f, 0.0f);
    glTranslatef(0.0f, 0.0f, 60.0f);
    glutSolidTorus(8.0f, 16.0f, 50, 50);
    glPopMatrix();

    // Draw cyan octahedron
    glColor3f(0.0f, 1.0f, 1.0f);
    glPushMatrix();
    glRotatef(animationAngle, 0.0f, 1.0f, 0.0f);
    glTranslatef(0.0f, 0.0f, -60.0f);
    glScalef(25.0f, 25.0f, 25.0f);
    glutSolidOctahedron();
    glPopMatrix();
}

// Called to draw scene
void RenderScene(void)
{
    // spin objects
    animationAngle += 1.0f;
    if (animationAngle == 360.0f) animationAngle = 0.0f;

    // Track camera angle
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    if (windowWidth > windowHeight)
    {
        GLdouble ar = (GLdouble)windowWidth / (GLdouble)windowHeight;
        glFrustum(-ar * cameraZoom, ar * cameraZoom, -cameraZoom, cameraZoom, 2.0, 1000.0);
    }
    else
    {
        GLdouble ar = (GLdouble)windowHeight / (GLdouble)windowWidth;
        glFrustum(-cameraZoom, cameraZoom, -ar * cameraZoom, ar * cameraZoom, 2.0, 1000.0);
    }

    // Keep the camera inside the room
    if (cameraPos[0] > 99.0f) cameraPos[0] = 99.0f;
    if (cameraPos[0] < -99.0f) cameraPos[0] = -99.0f;
    if (cameraPos[1] > 120.0f) cameraPos[1] = 120.0f;
    if (cameraPos[1] < -20.0f) cameraPos[1] = -20.0f;
    if (cameraPos[2] > 99.0f) cameraPos[2] = 99.0f;
    if (cameraPos[2] < -99.0f) cameraPos[2] = -99.0f;

    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    gluLookAt(cameraPos[0], cameraPos[1], cameraPos[2], 
              0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);

    if (doProcessing)
    {
        // draw the scene as pass 1 to an FBO
        glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID[0]);
        glViewport(0, 0, fboWidth, fboHeight);
        
        GLenum fboStatus = glCheckFramebufferStatusEXT(GL_FRAMEBUFFER_EXT);
        if (fboStatus != GL_FRAMEBUFFER_COMPLETE_EXT)
        {
            fprintf(stderr, "FBO #1 Error!\n");
        }
    }
    else
    {
        // just draw the scene to the window
        glViewport(0, 0, windowWidth, windowHeight);
    }

    // Clear the window with current clearing color
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    // Validate our shader before first use
    for (int whichShader = 0; whichShader < TOTAL_SHADERS; whichShader++)
    {
        if (needsValidation[whichShader])
        {
            GLint success;

            glValidateProgram(progObj[whichShader]);
            glGetProgramiv(progObj[whichShader], GL_VALIDATE_STATUS, &success);
            if (!success)
            {
                GLchar infoLog[MAX_INFO_LOG_SIZE];
                glGetProgramInfoLog(progObj[whichShader], MAX_INFO_LOG_SIZE, NULL, infoLog);
                fprintf(stderr, "Error in program #%d validation!\n", whichShader);
                fprintf(stderr, "Info log: %s\n", infoLog);
                Sleep(10000);
                exit(0);
            }

            needsValidation[whichShader] = GL_FALSE;
        }
    }
    
    DrawModels(GL_TRUE);

    if (doProcessing)
    {
        GLint uniformLoc;
        int loopCount;

        // 2nd pass: Redraw from texture w/ fragment shader outputting to multiple targets
        glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID[1]);
        glBindTexture(GL_TEXTURE_2D, renderTextureID[0]);
        // to enhance the blur effect, force texture 0 to use a coarser mip level
        glGenerateMipmapEXT(GL_TEXTURE_2D);

        if (useDrawBuffers)
        {
            // single shader will write to all 4 render textures simultaneously
            loopCount = 1;
            GLenum buf[4] = {GL_COLOR_ATTACHMENT0_EXT, GL_COLOR_ATTACHMENT1_EXT, GL_COLOR_ATTACHMENT2_EXT, GL_COLOR_ATTACHMENT3_EXT};
            glDrawBuffers(maxDrawBuffers, buf);
        }
        else
        {
            // we need a separate shader pass for each render target
            loopCount = maxDrawBuffers;
        }

        while (loopCount--)
        {
            int shaderNum = 0;
            if (!useDrawBuffers)
            {
                shaderNum = loopCount + 2;
                glDrawBuffer(GL_COLOR_ATTACHMENT0_EXT + loopCount);
            }

            glUseProgram(progObj[shaderNum]);
            uniformLoc = glGetUniformLocation(progObj[shaderNum], "sampler0");
            if (uniformLoc != -1)
            {
                glUniform1i(uniformLoc, 0);
            }
            uniformLoc = glGetUniformLocation(progObj[shaderNum], "tc_offset");
            if (uniformLoc != -1)
            {
                glUniform2fv(uniformLoc, 9, texCoordOffsets);
            }

            glDisable(GL_DEPTH_TEST);
            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();
            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();

            GLenum fboStatus = glCheckFramebufferStatusEXT(GL_FRAMEBUFFER_EXT);
            if (fboStatus != GL_FRAMEBUFFER_COMPLETE_EXT)
            {
                fprintf(stderr, "FBO #2 Error!\n");
            }

            glBegin(GL_QUADS);
                glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 0.0f);
                glVertex2f(-1.0f, -1.0f);
                glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 1.0f);
                glVertex2f(-1.0f, 1.0f);
                glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 1.0f);
                glVertex2f(1.0f, 1.0f);
                glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 0.0f);
                glVertex2f(1.0f, -1.0f);
            glEnd();
        }

        // 3rd pass: Tile the multiple targets back to the window
        glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, 0);
        glViewport(0, 0, windowWidth, windowHeight);

        glUseProgram(progObj[1]);
        uniformLoc = glGetUniformLocation(progObj[1], "sampler0");
        if (uniformLoc != -1)
        {
            glUniform1i(uniformLoc, 0);
        }
        uniformLoc = glGetUniformLocation(progObj[1], "sampler1");
        if (uniformLoc != -1)
        {
            glUniform1i(uniformLoc, 1);
        }
        uniformLoc = glGetUniformLocation(progObj[1], "sampler2");
        if (uniformLoc != -1)
        {
            glUniform1i(uniformLoc, 2);
        }
        uniformLoc = glGetUniformLocation(progObj[1], "sampler3");
        if (uniformLoc != -1)
        {
            glUniform1i(uniformLoc, 3);
        }

        glBindTexture(GL_TEXTURE_2D, renderTextureID[1]);

        glBegin(GL_QUADS);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 0.0f);
            glVertex2f(-1.0f, -1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 1.0f);
            glVertex2f(-1.0f, 1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 1.0f);
            glVertex2f(1.0f, 1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 0.0f);
            glVertex2f(1.0f, -1.0f);
        glEnd();

        glEnable(GL_DEPTH_TEST);

        glUseProgram(0);
    }

    if (glGetError() != GL_NO_ERROR)
        fprintf(stderr, "GL Error!\n");

    // Flush drawing commands
    glutSwapBuffers();
}

void SetupTextures(void)
{
    // Create 4 texture objects and load them up
    glGenTextures(4, wallTextureID);

    GLint w, h, c;
    GLenum format;
    GLbyte *texels;

    for (int i = 0; i < 4; i++)
    {
        switch (i)
        {
        case 0:
            texels = gltLoadTGA("WRHS.tga", &w, &h, &c, &format);
            break;
        case 1:
            texels = gltLoadTGA("MAMS.tga", &w, &h, &c, &format);
            break;
        case 2:
            texels = gltLoadTGA("WPI.tga", &w, &h, &c, &format);
            break;
        case 3:
            texels = gltLoadTGA("Babson.tga", &w, &h, &c, &format);
            break;
        default:
            break;
        }

        assert(c == GL_RGB8);

        glBindTexture(GL_TEXTURE_2D, wallTextureID[i]);
        glTexParameteri(GL_TEXTURE_2D, GL_GENERATE_MIPMAP, 1);
        glTexImage2D(GL_TEXTURE_2D, 0, c, w, h, 0, format, GL_UNSIGNED_BYTE, texels);
        free(texels);

        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
    }

    // Set up the render textures: 1 for 1st pass, up to 4 for 2nd
    glGenTextures(5, renderTextureID);

    for (GLint i = 0; i < maxDrawBuffers+1; i++)
    {
        if (i > 0)
            glActiveTexture(GL_TEXTURE0 + i - 1);
        glBindTexture(GL_TEXTURE_2D, renderTextureID[i]);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
        if (i == 0)
        {
            // The 1st pass texture needs to be mipmapped for the enhanced blur effect
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_NEAREST);
        }

        // this may change with window size changes
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA8, fboWidth, fboHeight, 0, GL_RGBA, GL_UNSIGNED_BYTE, 0);
    }
    glActiveTexture(GL_TEXTURE0);
}

void SetupShaders(void)
{
    // we'll leave fixed functionality vertex shading in place,
    // but we'll swap between two fragment shaders

    // Load and compile shaders
    for (int i = 0; i < TOTAL_SHADERS; i++)
    {
        PrepareShader(i);
    }
}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
{
    fprintf(stdout, "FBO Draw Buffers Demo\n\n");

    // Make sure required functionality is available: cube maps, auto mip gen, etc.
    if (!GLEE_VERSION_1_4)
    {
        fprintf(stderr, "OpenGL 1.4 is not available!\n");
        Sleep(2000);
        exit(0);
    }

    if (GLEE_ARB_texture_non_power_of_two)
    {
        npotTexturesAvailable = GL_TRUE;
    }
    else
    {
        fprintf(stderr, "GL_ARB_texture_non_power_of_two extension is not available!\n");
        fprintf(stderr, "Framebuffer effects will be lower resolution (lower quality).\n\n");
    }

    if (!GLEE_EXT_framebuffer_object)
    {
        fprintf(stderr, "GL_EXT_framebuffer_object extension is unavailable!\n");
        Sleep(2000);
        exit(0);
    }

    // we'll use up to 4 render targets if they're available
    glGetIntegerv(GL_MAX_DRAW_BUFFERS, &maxDrawBuffers);
    glGetIntegerv(GL_MAX_COLOR_ATTACHMENTS_EXT, &maxColorAttachments);
    glGetIntegerv(GL_MAX_TEXTURE_IMAGE_UNITS, &maxTexUnits);
    maxDrawBuffers = (maxDrawBuffers > maxColorAttachments) ? maxColorAttachments : maxDrawBuffers;
    maxDrawBuffers = (maxDrawBuffers > (maxTexUnits-1)) ? (maxTexUnits-1) : maxDrawBuffers;
    maxDrawBuffers = (maxDrawBuffers > 4) ? 4 : maxDrawBuffers;
    if (((!GLEE_ARB_draw_buffers || !GLEE_ARB_fragment_shader || !GLEE_ARB_shader_objects) 
        && !GLEE_VERSION_2_0) || (maxDrawBuffers != 4))
    {
        fprintf(stderr, "Support for at least 4 draw buffers is unavailable!\n");
        Sleep(2000);
        exit(0);
    }

    glGetIntegerv(GL_MAX_TEXTURE_SIZE, &maxTexSize);
    glGetIntegerv(GL_MAX_RENDERBUFFER_SIZE_EXT, &maxRenderbufferSize);
    maxTexSize = (maxRenderbufferSize > maxTexSize) ? maxTexSize : maxRenderbufferSize;

    fprintf(stdout, "Controls:\n");
    fprintf(stdout, "\tRight-click for menu\n\n");
    fprintf(stdout, "\tx/X\t\tMove +/- in x direction\n");
    fprintf(stdout, "\ty/Y\t\tMove +/- in y direction\n");
    fprintf(stdout, "\tz/Z\t\tMove +/- in z direction\n\n");
    fprintf(stdout, "\td/D\t\tToggle use of draw buffers\n\n");
    fprintf(stdout, "\tq\t\tExit demo\n\n");
    
    // Black background
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );

    // Hidden surface removal
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LEQUAL);

    // Set up some lighting state that never changes
    glShadeModel(GL_SMOOTH);
    glLightModeli(GL_LIGHT_MODEL_LOCAL_VIEWER, 1);
    glLightfv(GL_LIGHT0, GL_AMBIENT, ambientLight);
    glLightfv(GL_LIGHT0, GL_DIFFUSE, diffuseLight);
    glLightfv(GL_LIGHT0, GL_SPECULAR, specularLight);
    glLightfv(GL_LIGHT0, GL_POSITION, lightPos);
    glMaterialfv(GL_FRONT, GL_SPECULAR, specularLight);
    glMateriali(GL_FRONT, GL_SHININESS, 128);
    glEnable(GL_LIGHTING);
    glEnable(GL_COLOR_MATERIAL);
    glEnable(GL_NORMALIZE);
    glEnable(GL_LIGHT0);

    // Set up textures & shaders
    SetupTextures();
    SetupShaders();

    // Set up some renderbuffer state
    glGenRenderbuffersEXT(1, &renderbufferID);
    glBindRenderbufferEXT(GL_RENDERBUFFER_EXT, renderbufferID);
    glRenderbufferStorageEXT(GL_RENDERBUFFER_EXT, GL_DEPTH_COMPONENT32, fboWidth, fboHeight);

    glGenFramebuffersEXT(2, framebufferID);
    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID[0]);
    glFramebufferRenderbufferEXT(GL_FRAMEBUFFER_EXT, GL_DEPTH_ATTACHMENT_EXT, GL_RENDERBUFFER_EXT, renderbufferID);
    glFramebufferTexture2DEXT(GL_FRAMEBUFFER_EXT, GL_COLOR_ATTACHMENT0_EXT, GL_TEXTURE_2D, renderTextureID[0], 0);

    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID[1]);
    for (int i = 0; i < maxDrawBuffers; i++)
    {
        glFramebufferTexture2DEXT(GL_FRAMEBUFFER_EXT, GL_COLOR_ATTACHMENT0_EXT + i, GL_TEXTURE_2D, renderTextureID[i+1], 0);
    }
    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, 0);
}

void ChangeSize(int w, int h)
{
    GLfloat xInc, yInc;

    GLint origWidth = fboWidth;
    GLint origHeight = fboHeight;
    GLint i, j;
    windowWidth = fboWidth = w;
    windowHeight = fboHeight = h;

    // use a render target that is the size of the window
    // or next larger power of two if necessary
    if (!npotTexturesAvailable)
    {
        // Try each size until we get one larger than the window
        i = 0;
        while ((1 << i) <= windowWidth)
            i++;
        fboWidth = (1 << i);

        i = 0;
        while ((1 << i) <= windowHeight)
            i++;
        fboHeight = (1 << i);
    }

    if (fboWidth > maxTexSize)
    {
        fboWidth = maxTexSize;
    }

    if (fboHeight > maxTexSize)
    {
        fboHeight = maxTexSize;
    }

    if ((origWidth != fboWidth) || (origHeight != fboHeight))
    {
        glRenderbufferStorageEXT(GL_RENDERBUFFER_EXT, GL_DEPTH_COMPONENT32, fboWidth, fboHeight);

        // 1 for 1st pass, up to 4 for 2nd pass
        for (i = 0; i < maxDrawBuffers+1; i++)
        {
            glBindTexture(GL_TEXTURE_2D, renderTextureID[i]);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA8, fboWidth, fboHeight, 0, GL_RGBA, GL_UNSIGNED_BYTE, 0);
        }

        xInc = 1.0f / (GLfloat)fboWidth;
        yInc = 1.0f / (GLfloat)fboHeight;

        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                texCoordOffsets[(((i*3)+j)*2)+0] = (-1.0f * xInc) + ((GLfloat)i * xInc);
                texCoordOffsets[(((i*3)+j)*2)+1] = (-1.0f * yInc) + ((GLfloat)j * yInc);
            }
        }
    }
}

void ProcessMenu(int value)
{
    switch(value)
    {
    case 1:
        useDrawBuffers = !useDrawBuffers;
        if (useDrawBuffers)
        {
            glutChangeToMenuEntry(1, "Toggle draw buffers usage (currently ON)", 1);
        }
        else
        {
            glutChangeToMenuEntry(1, "Toggle draw buffers usage (currently OFF)", 1);
        }
        break;

    case 2:
        doProcessing = !doProcessing;
        if (doProcessing)
        {
            glutChangeToMenuEntry(2, "Toggle post-processing (currently ON)", 2);
        }
        else
        {
            glutChangeToMenuEntry(2, "Toggle post-processing (currently OFF)", 2);
        }
        break;

    default:
        break;
    }

    // Refresh the Window
    glutPostRedisplay();
}

void KeyPressFunc(unsigned char key, int x, int y)
{
    switch (key)
    {
    case 'x':
        cameraPos[0] += 1.0f;
        break;
    case 'X':
        cameraPos[0] -= 1.0f;
        break;
    case 'y':
        cameraPos[1] += 1.0f;
        break;
    case 'Y':
        cameraPos[1] -= 1.0f;
        break;
    case 'z':
        cameraPos[2] += 1.0f;
        break;
    case 'Z':
        cameraPos[2] -= 1.0f;
        break;
    case 'd':
    case 'D':
        useDrawBuffers = !useDrawBuffers;
        if (useDrawBuffers)
        {
            glutChangeToMenuEntry(1, "Toggle draw buffers usage (currently ON)", 1);
        }
        else
        {
            glutChangeToMenuEntry(1, "Toggle draw buffers usage (currently OFF)", 1);
        }
        break;
    case 'p':
    case 'P':
        doProcessing = !doProcessing;
        if (doProcessing)
        {
            glutChangeToMenuEntry(2, "Toggle post-processing (currently ON)", 2);
        }
        else
        {
            glutChangeToMenuEntry(2, "Toggle post-processing (currently OFF)", 2);
        }
        break;
    case 'q':
    case 'Q':
    case 27 : /* ESC */
        exit(0);
    }

    // Refresh the Window
    glutPostRedisplay();
}

void SpecialKeys(int key, int x, int y)
{
    switch (key)
    {
    case GLUT_KEY_LEFT:
        cameraPos[0] -= 1.0f;
        break;
    case GLUT_KEY_RIGHT:
        cameraPos[0] += 1.0f;
        break;
    case GLUT_KEY_UP:
        cameraPos[2] -= 1.0f;
        break;
    case GLUT_KEY_DOWN:
        cameraPos[2] += 1.0f;
        break;
    default:
        break;
    }

    // Refresh the Window
    glutPostRedisplay();
}

int main(int argc, char* argv[])
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("FBO Draw Buffers Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);
    glutIdleFunc(RenderScene);

    // Create the Menu
    glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("Toggle draw buffers usage (currently ON)", 1);
    glutAddMenuEntry("Toggle post-processing (currently ON)", 2);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    SetupRC();

    glutMainLoop();

    glDeleteTextures(5, renderTextureID);
    glDeleteTextures(4, wallTextureID);
    if (glDeleteFramebuffersEXT)
        glDeleteFramebuffersEXT(2, framebufferID);
    if (glDeleteRenderbuffersEXT)
        glDeleteRenderbuffersEXT(1, &renderbufferID);

    return 0;
}
