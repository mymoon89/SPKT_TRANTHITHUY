// hdrbloom.cpp
// OpenGL SuperBible, Chapter 18
// Demonstrates HDR rendering with bloom
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"   // OpenGL toolkit
#include "../../shared/glFrame.h"   // OpenGL toolkit

#include <stdio.h>
#include <assert.h>

#define HDRBALL           0
#define GAUSSIAN          1
#define COMBINE           2
#define SHOW2D            3
#define TOTAL_SHADER_SETS 4

GLuint fShader[TOTAL_SHADER_SETS]; // shader object names
GLuint vShader[TOTAL_SHADER_SETS]; 
GLuint progObj[TOTAL_SHADER_SETS]; 
GLboolean needsValidation[TOTAL_SHADER_SETS];
char *shaderNames[TOTAL_SHADER_SETS] = {"hdrball", "gaussian", "combine", "show2d"};

GLboolean npotTexturesAvailable = GL_FALSE;

GLuint pboID;                           // PBO name
GLuint framebufferID[5];                // FBO names for 1st pass (1) and 2nd pass (4)
GLuint textureID[7];                    // original scene, bright pass, and bloom results (4)
GLuint renderbufferID;                  // renderbuffer object name
GLint maxRenderbufferSize;              // maximum allowed size for FBO renderbuffer
GLint maxTexSize;                       // maximum allowed size for our 2D textures
GLint maxTexUnits;                      // maximum number of texture image units
GLint maxDrawBuffers;                   // maximum number of drawbuffers supported
GLint maxColorAttachments;              // maximum number of FBO color attachments

GLint lightPosLoc, bloomLimitLoc, offsetsLoc, starIntensityLoc, afterGlowLoc;

GLint windowWidth = 512;                // window size
GLint windowHeight = 512;
GLint fboWidth = 0;                     // set based on window size
GLint fboHeight = 0;

GLint iCursorX = 0;                     // integer cursor position [0,w/h]
GLint mainMenu, showMenu;               // menu handles

GLfloat cameraPos[] = { 50.0f, 50.0f, 150.0f, 1.0f};
GLdouble cameraZoom = 0.4;

GLfloat lightPos[] = { 140.0f, 250.0f, 140.0f, 1.0f};

GLfloat texCoordOffsets[4][5*5*2];
GLfloat lightRotation = 30.0f;
GLfloat bloomLimit = 1.0f;
GLint tess = 75;

#define ORIG_SCENE      0
#define BRIGHT_PASS     1
#define PRE_BLUR        2
#define POST_BLUR       3
#define JUST_BLOOM      4
#define NO_AFTER_GLOW   5
#define JUST_AFTER_GLOW 6
#define FULL_SCENE      7
GLint whichStopPoint = FULL_SCENE;

GLboolean afterGlowValid = GL_FALSE;

GLfloat animationAngle = 0.0f;          // used to spin object
GLfloat angleIncrement = 4.0f;          // degrees to spin per frame
GLboolean paused = GL_FALSE;

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
    GLchar *shString;
    const GLchar *shStringPtr[1];
    GLint success;

    // Create shader objects and specify shader text
    sprintf(fullFileName, "./shaders/%s.vs", shaderNames[shaderNum]);
    shString = LoadShaderText(fullFileName);
    if (!shString)
    {
        fprintf(stderr, "Unable to load \"%s\"\n", fullFileName);
        Sleep(5000);
        exit(0);
    }
    vShader[shaderNum] = glCreateShader(GL_VERTEX_SHADER);
    shStringPtr[0] = shString;
    glShaderSource(vShader[shaderNum], 1, shStringPtr, NULL);
    free(shString);

    // Compile shaders and check for any errors
    glCompileShader(vShader[shaderNum]);
    glGetShaderiv(vShader[shaderNum], GL_COMPILE_STATUS, &success);
    if (!success)
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(vShader[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        fprintf(stderr, "Error in vertex shader #%d compilation!\n", shaderNum);
        fprintf(stderr, "Info log: %s\n", infoLog);
        Sleep(10000);
        exit(0);
    }

    sprintf(fullFileName, "./shaders/%s.fs", shaderNames[shaderNum]);
    shString = LoadShaderText(fullFileName);
    if (!shString)
    {
        fprintf(stderr, "Unable to load \"%s\"\n", fullFileName);
        Sleep(5000);
        exit(0);
    }
    fShader[shaderNum] = glCreateShader(GL_FRAGMENT_SHADER);
    shStringPtr[0] = shString;
    glShaderSource(fShader[shaderNum], 1, shStringPtr, NULL);
    free(shString);

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
    }
    else
    {
        GLchar infoLog[MAX_INFO_LOG_SIZE];
        glGetShaderInfoLog(fShader[shaderNum], MAX_INFO_LOG_SIZE, NULL, infoLog);
        //fprintf(stderr, "Fragment shader #%d info log: %s\n", shaderNum, infoLog);
    }

    // Create program object, attach shader, then link
    progObj[shaderNum] = glCreateProgram();
    glAttachShader(progObj[shaderNum], vShader[shaderNum]);
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
        //fprintf(stderr, "Program #%d info log: %s\n", shaderNum, infoLog);
    }

    // Program object has changed, so we should revalidate
    needsValidation[shaderNum] = GL_TRUE;
}

// Called to draw scene objects
void DrawModels(void)
{
    M3DVector3f lightPosEye;
    M3DMatrix44f mv;

    // Transform light position to eye space
    glPushMatrix();
    glRotatef(lightRotation, 0.0, 1.0, 0.0);
    glGetFloatv(GL_MODELVIEW_MATRIX, mv);
    m3dTransformVector3(lightPosEye, lightPos, mv);
    glPopMatrix();

    glUniform3fv(lightPosLoc, 1, lightPosEye);

    // Draw sphere
    glPushMatrix();
    // spin the ball, but 5x slower because it looks better
    glRotatef(animationAngle/5.0f, 0.0f, 1.0f, 0.0f);
    glutSolidSphere(50.0f, tess, tess);
    glPopMatrix();
}

// 1st pass:
//  - render full scene to color attachment 0 -- texture
//  - render bright parts of scene to color attachment 1 -- texture
void FirstPass(void)
{
    glUseProgram(progObj[HDRBALL]);
    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID[0]);
    glViewport(0, 0, fboWidth, fboHeight);

    GLenum fboStatus = glCheckFramebufferStatusEXT(GL_FRAMEBUFFER_EXT);
    if (fboStatus != GL_FRAMEBUFFER_COMPLETE_EXT)
    {
        fprintf(stderr, "FBO #1 Error!\n");
    }

    // Validate our shader before first use
    if (needsValidation[HDRBALL])
    {
        GLint success;

        glValidateProgram(progObj[HDRBALL]);
        glGetProgramiv(progObj[HDRBALL], GL_VALIDATE_STATUS, &success);
        if (!success)
        {
            GLchar infoLog[MAX_INFO_LOG_SIZE];
            glGetProgramInfoLog(progObj[HDRBALL], MAX_INFO_LOG_SIZE, NULL, infoLog);
            fprintf(stderr, "Error in program #%d validation!\n", HDRBALL);
            fprintf(stderr, "Info log: %s\n", infoLog);
            Sleep(10000);
            exit(0);
        }

        needsValidation[HDRBALL] = GL_FALSE;
    }
    
    // Clear the window with current clearing color
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    glEnable(GL_DEPTH_TEST);

    glUniform1f(starIntensityLoc, abs(angleIncrement));

    // Draw objects in the scene
    DrawModels();

    glDisable(GL_DEPTH_TEST);
}

// 2nd pass:
//  - actually 4 passes, one for each level of bright pass texture 0-3
void SecondPass(void)
{
    glUseProgram(progObj[GAUSSIAN]);

    // Validate our shader before first use
    if (needsValidation[GAUSSIAN])
    {
        GLint success;

        glValidateProgram(progObj[GAUSSIAN]);
        glGetProgramiv(progObj[GAUSSIAN], GL_VALIDATE_STATUS, &success);
        if (!success)
        {
            GLchar infoLog[MAX_INFO_LOG_SIZE];
            glGetProgramInfoLog(progObj[GAUSSIAN], MAX_INFO_LOG_SIZE, NULL, infoLog);
            fprintf(stderr, "Error in program #%d validation!\n", GAUSSIAN);
            fprintf(stderr, "Info log: %s\n", infoLog);
            Sleep(10000);
            exit(0);
        }

        needsValidation[GAUSSIAN] = GL_FALSE;
    }

    glBindTexture(GL_TEXTURE_2D, textureID[1]);

    for (int i = 0; i < 4; i++)
    {
        glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID[1+i]);
        glViewport(0, 0, (fboWidth>>i), (fboHeight>>i));

        GLenum fboStatus = glCheckFramebufferStatusEXT(GL_FRAMEBUFFER_EXT);
        if (fboStatus != GL_FRAMEBUFFER_COMPLETE_EXT)
        {
            fprintf(stderr, "FBO #2/%d Error!\n", i);
        }

        glUniform2fv(offsetsLoc, 25, texCoordOffsets[i]);

        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_BASE_LEVEL, i);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAX_LEVEL, i);

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

    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_BASE_LEVEL, 0);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAX_LEVEL, 1000);
}

// final pass:
//  - output to backbuffer the final image
void FinalPass(void)
{
    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, 0);
    glViewport(0, 0, windowWidth, windowHeight);

    // set up afterglow texture
    glActiveTexture(GL_TEXTURE5);
    glBindBuffer(GL_PIXEL_UNPACK_BUFFER, pboID);
    glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB8, fboWidth, fboHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, 0);
    glBindBuffer(GL_PIXEL_UNPACK_BUFFER, 0);
    glActiveTexture(GL_TEXTURE0);

    // Validate our shader before first use
    if (needsValidation[GAUSSIAN])
    {
        GLint success;

        glValidateProgram(progObj[GAUSSIAN]);
        glGetProgramiv(progObj[GAUSSIAN], GL_VALIDATE_STATUS, &success);
        if (!success)
        {
            GLchar infoLog[MAX_INFO_LOG_SIZE];
            glGetProgramInfoLog(progObj[GAUSSIAN], MAX_INFO_LOG_SIZE, NULL, infoLog);
            fprintf(stderr, "Error in program #%d validation!\n", GAUSSIAN);
            fprintf(stderr, "Info log: %s\n", infoLog);
            Sleep(10000);
            exit(0);
        }

        needsValidation[GAUSSIAN] = GL_FALSE;
    }

    switch (whichStopPoint)
    {
    case ORIG_SCENE:
        glUseProgram(progObj[SHOW2D]);
        glBindTexture(GL_TEXTURE_2D, textureID[0]);
        break;
    case BRIGHT_PASS:
    case PRE_BLUR:
        glUseProgram(progObj[SHOW2D]);
        glBindTexture(GL_TEXTURE_2D, textureID[1]);
        break;
    case POST_BLUR:
        glUseProgram(progObj[SHOW2D]);
        break;
    case JUST_BLOOM:
    case NO_AFTER_GLOW:
    case JUST_AFTER_GLOW:
    case FULL_SCENE:
        glUseProgram(progObj[COMBINE]);
        glBindTexture(GL_TEXTURE_2D, 
            ((whichStopPoint == JUST_BLOOM) || (whichStopPoint == JUST_AFTER_GLOW)) ? 0 : textureID[0]);
        glUniform1i(afterGlowLoc, ((whichStopPoint >= JUST_AFTER_GLOW) && afterGlowValid) ? 1 : 0);
        break;
    default:
        assert(0);
        break;
    }

    if ((whichStopPoint == PRE_BLUR) || (whichStopPoint == POST_BLUR))
    {
        if (whichStopPoint == PRE_BLUR)
        {
            // show each LOD individually
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_BASE_LEVEL, 0);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAX_LEVEL, 0);
        }
        else
        {
            glBindTexture(GL_TEXTURE_2D, textureID[2]);
        }
        glBegin(GL_QUADS);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 0.0f);
            glVertex2f(-1.0f, 0.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 1.0f);
            glVertex2f(-1.0f, 1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 1.0f);
            glVertex2f(0.0f, 1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 0.0f);
            glVertex2f(0.0f, 0.0f);
        glEnd();
        if (whichStopPoint == PRE_BLUR)
        {
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_BASE_LEVEL, 1);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAX_LEVEL, 1);
        }
        else
        {
            glBindTexture(GL_TEXTURE_2D, textureID[3]);
        }
        glBegin(GL_QUADS);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 0.0f);
            glVertex2f(0.0f, 0.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 1.0f);
            glVertex2f(0.0f, 1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 1.0f);
            glVertex2f(1.0f, 1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 0.0f);
            glVertex2f(1.0f, 0.0f);
        glEnd();
        if (whichStopPoint == PRE_BLUR)
        {
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_BASE_LEVEL, 2);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAX_LEVEL, 2);
        }
        else
        {
            glBindTexture(GL_TEXTURE_2D, textureID[4]);
        }
        glBegin(GL_QUADS);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 0.0f);
            glVertex2f(-1.0f, -1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 1.0f);
            glVertex2f(-1.0f, 0.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 1.0f);
            glVertex2f(0.0f, 0.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 0.0f);
            glVertex2f(0.0f, -1.0f);
        glEnd();
        if (whichStopPoint == PRE_BLUR)
        {
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_BASE_LEVEL, 3);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAX_LEVEL, 3);
        }
        else
        {
            glBindTexture(GL_TEXTURE_2D, textureID[5]);
        }
        glBegin(GL_QUADS);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 0.0f);
            glVertex2f(0.0f, -1.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 0.0f, 1.0f);
            glVertex2f(0.0f, 0.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 1.0f);
            glVertex2f(1.0f, 0.0f);
            glMultiTexCoord2f(GL_TEXTURE0, 1.0f, 0.0f);
            glVertex2f(1.0f, -1.0f);
        glEnd();
        if (whichStopPoint == PRE_BLUR)
        {
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_BASE_LEVEL, 0);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAX_LEVEL, 1000);
        }
    }
    else
    {
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
}

// Called to draw scene
void RenderScene(void)
{
    if (!paused)
    {
        // spin objects
        animationAngle += angleIncrement;
        if (animationAngle == 360.0f) animationAngle = 0.0f;

        // slow down over time
        angleIncrement *= 0.99f;
        if (abs(angleIncrement) < 0.01f) angleIncrement = 0.0f;
    }

    // Track camera angle
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    if (windowWidth > windowHeight)
    {
        GLdouble ar = (GLdouble)windowWidth / (GLdouble)windowHeight;
        glFrustum(-ar * cameraZoom, ar * cameraZoom, -cameraZoom, cameraZoom, 1.0, 1000.0);
    }
    else
    {
        GLdouble ar = (GLdouble)windowHeight / (GLdouble)windowWidth;
        glFrustum(-cameraZoom, cameraZoom, -ar * cameraZoom, ar * cameraZoom, 1.0, 1000.0);
    }
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    gluLookAt(cameraPos[0], cameraPos[1], cameraPos[2], 
              0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);

    // Original Scene + Bright Pass
    FirstPass();

    // Generate mipmaps of the bright pass results:
    // we'll use levels 0 - 3 for blurring
    glBindTexture(GL_TEXTURE_2D, textureID[1]);
    glGenerateMipmapEXT(GL_TEXTURE_2D);

    SecondPass();

    FinalPass();

    // Read back frame for afterglow effect
    glBindBuffer(GL_PIXEL_PACK_BUFFER, pboID);
    glReadPixels(0, 0, fboWidth, fboHeight, GL_RGB, GL_UNSIGNED_BYTE, 0);
    glBindBuffer(GL_PIXEL_PACK_BUFFER, 0);
    afterGlowValid = GL_TRUE;

    // Reset state
    glUseProgram(0);

    if (glGetError() != GL_NO_ERROR)
        fprintf(stderr, "GL Error!\n");

    // Flush drawing commands
    glutSwapBuffers();
}

void SetupTextures(void)
{
    // Set up the render textures: 2 for 1st pass, 4 for 2nd
    glGenTextures(7, textureID);

    for (int i = 0; i < 2; i++)
    {
        glBindTexture(GL_TEXTURE_2D, textureID[i]);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB16F_ARB, fboWidth, fboHeight, 0, GL_RGB, GL_FLOAT, 0);
    }
    for (int i = 2; i < 7; i++)
    {
        glActiveTexture(GL_TEXTURE1 + i - 2);
        glBindTexture(GL_TEXTURE_2D, textureID[i]);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
        if (i < 6)
        {
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA8, fboWidth >> (i-2), fboHeight >> (i-2), 0, GL_RGBA, GL_UNSIGNED_BYTE, 0);
        }
        else
        {
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB8, fboWidth, fboHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, 0);
        }
    }
    glActiveTexture(GL_TEXTURE0);
}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
{
    GLint i;

    fprintf(stdout, "High Dynamic Range Bloom Demo\n\n");

    // Make sure required functionality is available!
    if (!GLEE_VERSION_2_0 && (!GLEE_ARB_draw_buffers || 
                              !GLEE_ARB_fragment_shader || 
                              !GLEE_ARB_vertex_shader || 
                              !GLEE_ARB_shader_objects || 
                              !GLEE_ARB_shading_language_100))
    {
        fprintf(stderr, "GLSL extensions not available!\n");
        Sleep(2000);
        exit(0);
    }

    // Make sure required functionality is available!
    if (!GLEE_EXT_framebuffer_object)
    {
        fprintf(stderr, "GL_EXT_framebuffer_object extension is unavailable!\n");
        Sleep(2000);
        exit(0);
    }

    if (!GLEE_ARB_texture_float)
    {
        fprintf(stderr, "GL_ARB_texture_float extension is not available!\n");
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

    // we'll use up to 4 render targets if they're available
    glGetIntegerv(GL_MAX_DRAW_BUFFERS, &maxDrawBuffers);
    glGetIntegerv(GL_MAX_COLOR_ATTACHMENTS_EXT, &maxColorAttachments);
    glGetIntegerv(GL_MAX_TEXTURE_IMAGE_UNITS, &maxTexUnits);
    maxDrawBuffers = (maxDrawBuffers > maxColorAttachments) ? maxColorAttachments : maxDrawBuffers;
    maxDrawBuffers = (maxDrawBuffers > (maxTexUnits-1)) ? (maxTexUnits-1) : maxDrawBuffers;
    maxDrawBuffers = (maxDrawBuffers > 4) ? 4 : maxDrawBuffers;
    if ((maxDrawBuffers != 4) || (maxTexUnits < 6))
    {
        fprintf(stderr, "Support for at least 4 draw buffers and 6 texture units is unavailable!\n");
        Sleep(2000);
        exit(0);
    }

    glGetIntegerv(GL_MAX_TEXTURE_SIZE, &maxTexSize);
    glGetIntegerv(GL_MAX_RENDERBUFFER_SIZE_EXT, &maxRenderbufferSize);
    maxTexSize = (maxRenderbufferSize > maxTexSize) ? maxTexSize : maxRenderbufferSize;

    fprintf(stdout, "Controls:\n");
    fprintf(stdout, "\tRight-click for menu\n\n");
    fprintf(stdout, "\tR/L arrows\t+/- rotate light\n\n");
    fprintf(stdout, "\tU/D arrows\t+/- increase/decrease tesselation\n\n");
    fprintf(stdout, "\tl/L\t\tdecrease/increase minimum brightness for bloom\n");
    fprintf(stdout, "\tx/X\t\tMove +/- in x direction\n");
    fprintf(stdout, "\ty/Y\t\tMove +/- in y direction\n");
    fprintf(stdout, "\tz/Z\t\tMove +/- in z direction\n\n");
    fprintf(stdout, "\tq\t\tExit demo\n\n");
    
    // Black background
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f );

    // Misc. state
    glDepthFunc(GL_LEQUAL);
    glShadeModel(GL_SMOOTH);
    glHint(GL_GENERATE_MIPMAP_HINT, GL_NICEST);

    // Load and compile shaders
    for (i = 0; i < TOTAL_SHADER_SETS; i++)
    {
        PrepareShader(i);
    }

    // Get uniform slots
    glUseProgram(progObj[HDRBALL]);
    lightPosLoc = glGetUniformLocation(progObj[HDRBALL], "lightPos");
    assert(lightPosLoc != -1);
    starIntensityLoc = glGetUniformLocation(progObj[HDRBALL], "starIntensity");
    assert(starIntensityLoc != -1);
    bloomLimitLoc = glGetUniformLocation(progObj[HDRBALL], "bloomLimit");
    assert(bloomLimitLoc != -1);
    glUniform1f(bloomLimitLoc, bloomLimit);
    glUseProgram(progObj[GAUSSIAN]);
    offsetsLoc = glGetUniformLocation(progObj[GAUSSIAN], "tc_offset");
    assert(offsetsLoc != -1);
    GLuint samplerLoc = glGetUniformLocation(progObj[GAUSSIAN], "sampler0");
    assert(samplerLoc != -1);
    glUniform1i(samplerLoc, 0);
    glUseProgram(progObj[COMBINE]);
    samplerLoc = glGetUniformLocation(progObj[COMBINE], "sampler0");
    assert(samplerLoc != -1);
    glUniform1i(samplerLoc, 0);
    samplerLoc = glGetUniformLocation(progObj[COMBINE], "sampler1");
    assert(samplerLoc != -1);
    glUniform1i(samplerLoc, 1);
    samplerLoc = glGetUniformLocation(progObj[COMBINE], "sampler2");
    assert(samplerLoc != -1);
    glUniform1i(samplerLoc, 2);
    samplerLoc = glGetUniformLocation(progObj[COMBINE], "sampler3");
    assert(samplerLoc != -1);
    glUniform1i(samplerLoc, 3);
    samplerLoc = glGetUniformLocation(progObj[COMBINE], "sampler4");
    assert(samplerLoc != -1);
    glUniform1i(samplerLoc, 4);
    samplerLoc = glGetUniformLocation(progObj[COMBINE], "sampler5");
    assert(samplerLoc != -1);
    glUniform1i(samplerLoc, 5);
    afterGlowLoc = glGetUniformLocation(progObj[COMBINE], "afterGlow");
    assert(afterGlowLoc != -1);
    glUseProgram(progObj[SHOW2D]);
    samplerLoc = glGetUniformLocation(progObj[SHOW2D], "sampler0");
    assert(samplerLoc != -1);
    glUniform1i(samplerLoc, 0);
    glUseProgram(0);

    // Render textures
    SetupTextures();

    // Set up a PBO for afterglow
    glGenBuffers(1, &pboID);
    glBindBuffer(GL_PIXEL_PACK_BUFFER, pboID);
    glBufferData(GL_PIXEL_PACK_BUFFER, 1, NULL, GL_STREAM_COPY);
    glBindBuffer(GL_PIXEL_PACK_BUFFER, 0);

    // Set up some renderbuffer state
    glGenRenderbuffersEXT(1, &renderbufferID);
    glBindRenderbufferEXT(GL_RENDERBUFFER_EXT, renderbufferID);
    glRenderbufferStorageEXT(GL_RENDERBUFFER_EXT, GL_DEPTH_COMPONENT32, fboWidth, fboHeight);

    glGenFramebuffersEXT(5, framebufferID);

    // in 1st pass we'll render to two 2D textures simultaneously
    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID[0]);
    GLenum buf[2] = {GL_COLOR_ATTACHMENT0_EXT, GL_COLOR_ATTACHMENT1_EXT};
    glDrawBuffers(2, buf);
    glFramebufferRenderbufferEXT(GL_FRAMEBUFFER_EXT, GL_DEPTH_ATTACHMENT_EXT, GL_RENDERBUFFER_EXT, renderbufferID);
    glFramebufferTexture2DEXT(GL_FRAMEBUFFER_EXT, GL_COLOR_ATTACHMENT0_EXT, GL_TEXTURE_2D, textureID[0], 0);
    glFramebufferTexture2DEXT(GL_FRAMEBUFFER_EXT, GL_COLOR_ATTACHMENT1_EXT, GL_TEXTURE_2D, textureID[1], 0);

    // in 2nd pass (actually 4 passes) we'll render to one 2D texture at a time
    for (i = 0; i < 4; i++)
    {
        glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID[1+i]);
        glFramebufferTexture2DEXT(GL_FRAMEBUFFER_EXT, GL_COLOR_ATTACHMENT0_EXT, GL_TEXTURE_2D, textureID[2+i], 0);
    }

    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, 0);
}

void ProcessMenu(int value)
{
    whichStopPoint = value - 1;

    if (whichStopPoint == JUST_AFTER_GLOW)
    {
        glActiveTexture(GL_TEXTURE1);
        glBindTexture(GL_TEXTURE_2D, 0);
        glActiveTexture(GL_TEXTURE2);
        glBindTexture(GL_TEXTURE_2D, 0);
        glActiveTexture(GL_TEXTURE3);
        glBindTexture(GL_TEXTURE_2D, 0);
        glActiveTexture(GL_TEXTURE4);
        glBindTexture(GL_TEXTURE_2D, 0);
    }
    else
    {
        glActiveTexture(GL_TEXTURE1);
        glBindTexture(GL_TEXTURE_2D, textureID[2]);
        glActiveTexture(GL_TEXTURE2);
        glBindTexture(GL_TEXTURE_2D, textureID[3]);
        glActiveTexture(GL_TEXTURE3);
        glBindTexture(GL_TEXTURE_2D, textureID[4]);
        glActiveTexture(GL_TEXTURE4);
        glBindTexture(GL_TEXTURE_2D, textureID[5]);
    }
    glActiveTexture(GL_TEXTURE0);

    // Refresh the Window
    glutPostRedisplay();
}

void KeyPressFunc(unsigned char key, int x, int y)
{
    switch (key)
    {
    case 'x':
        cameraPos[0] += 5.0f;
        break;
    case 'X':
         cameraPos[0] -= 5.0f;
        break;
    case 'y':
        cameraPos[1] += 5.0f;
        break;
    case 'Y':
        cameraPos[1] -= 5.0f;
        break;
    case 'z':
        cameraPos[2] += 5.0f;
        break;
    case 'Z':
        cameraPos[2] -= 5.0f;
        break;
    case 'l':
        bloomLimit -= 0.05f;
        glUseProgram(progObj[HDRBALL]);
        glUniform1f(bloomLimitLoc, bloomLimit);
        glUseProgram(0);
        break;
    case 'L':
        bloomLimit += 0.05f;
        glUseProgram(progObj[HDRBALL]);
        glUniform1f(bloomLimitLoc, bloomLimit);
        glUseProgram(0);
        break;
    case 'p':
    case 'P':
        paused = !paused;
        break;
    case 'q':
    case 'Q':
    case 27 : /* ESC */
        exit(0);
    }

    // Refresh the Window
    glutPostRedisplay();
}

void MouseMotion(int x, int y)
{
    float newIncrement = (float)(x - iCursorX) / 5.0f;
    if (((angleIncrement >= 0.0f) && (newIncrement < 0.0f)) ||
        ((angleIncrement <= 0.0f) && (newIncrement > 0.0f)) ||
        (abs(newIncrement) > abs(angleIncrement)))
    {
        angleIncrement = newIncrement;
    }
    iCursorX = x;
}

void SpecialKeys(int key, int x, int y)
{
    switch (key)
    {
    case GLUT_KEY_LEFT:
        lightRotation -= 5.0f;
        break;
    case GLUT_KEY_RIGHT:
        lightRotation += 5.0f;
        break;
    case GLUT_KEY_UP:
        tess += 5;
        break;
    case GLUT_KEY_DOWN:
        tess -= 5;
        if (tess < 5) tess = 5;
        break;
    default:
        break;
    }

    // Refresh the Window
    glutPostRedisplay();
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
        while ((1 << i) < windowWidth)
            i++;
        fboWidth = (1 << i);

        i = 0;
        while ((1 << i) < windowHeight)
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
        glBindBuffer(GL_PIXEL_PACK_BUFFER, pboID);
        glBufferData(GL_PIXEL_PACK_BUFFER, fboHeight * (((fboWidth*3)+3) & ~0x3), NULL, GL_STREAM_COPY);
        glBindBuffer(GL_PIXEL_PACK_BUFFER, 0);
        afterGlowValid = GL_FALSE;

        glRenderbufferStorageEXT(GL_RENDERBUFFER_EXT, GL_DEPTH_COMPONENT32, fboWidth, fboHeight);

        for (i = 0; i < 2; i++)
        {
            glBindTexture(GL_TEXTURE_2D, textureID[i]);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB16F_ARB, fboWidth, fboHeight, 0, GL_RGB, GL_FLOAT, 0);
        }
        for (i = 2; i < 7; i++)
        {
            glBindTexture(GL_TEXTURE_2D, textureID[i]);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA8, fboWidth >> (i-2), fboHeight >> (i-2), 0, GL_RGBA, GL_UNSIGNED_BYTE, 0);
        }

        for (int k = 0; k < 4; k++)
        {
            xInc = 1.0f / (GLfloat)(fboWidth >> k);
            yInc = 1.0f / (GLfloat)(fboHeight >> k);

            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    texCoordOffsets[k][(((i*5)+j)*2)+0] = (-1.0f * xInc) + ((GLfloat)i * xInc);
                    texCoordOffsets[k][(((i*5)+j)*2)+1] = (-1.0f * yInc) + ((GLfloat)j * yInc);
                }
            }
        }
    }
}

int main(int argc, char* argv[])
{
    GLint i;

    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_MULTISAMPLE);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("High Dynamic Range Bloom Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);
    glutIdleFunc(RenderScene);
    glutMotionFunc(MouseMotion);

    SetupRC();

    // Create the menus
    showMenu = glutCreateMenu(ProcessMenu);
    for (i = ORIG_SCENE; i <= FULL_SCENE; i++)
    {
        char menuEntry[128];
        switch (i)
        {
        case ORIG_SCENE:
            sprintf(menuEntry, "original scene");
            break;
        case BRIGHT_PASS:
            sprintf(menuEntry, "bright pass");
            break;
        case PRE_BLUR:
            sprintf(menuEntry, "pre-blur");
            break;
        case POST_BLUR:
            sprintf(menuEntry, "post-blur");
            break;
        case JUST_BLOOM:
            sprintf(menuEntry, "just bloom");
            break;
        case NO_AFTER_GLOW:
            sprintf(menuEntry, "no afterglow");
            break;
        case JUST_AFTER_GLOW:
            sprintf(menuEntry, "just afterglow");
            break;
        case FULL_SCENE:
            sprintf(menuEntry, "combined scene");
            break;
        default:
            assert(0);
            break;
        }
        glutAddMenuEntry(menuEntry, 1+i);
    }

    mainMenu = glutCreateMenu(ProcessMenu);
    {
        char menuEntry[128];
        sprintf(menuEntry, "Show intermediate results");
        glutAddSubMenu(menuEntry, showMenu);
    }
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    glutMainLoop();

    glDeleteTextures(7, textureID);
    if (glDeleteFramebuffersEXT)
        glDeleteFramebuffersEXT(5, framebufferID);
    if (glDeleteRenderbuffersEXT)
        glDeleteRenderbuffersEXT(1, &renderbufferID);

    if (glDeleteProgram && glDeleteShader)
    {
        for (i = 0; i < TOTAL_SHADER_SETS; i++)
        {
            glDeleteProgram(progObj[i]);
            glDeleteShader(vShader[i]);
            glDeleteShader(fShader[i]);
        }
    }

    return 0;
}
