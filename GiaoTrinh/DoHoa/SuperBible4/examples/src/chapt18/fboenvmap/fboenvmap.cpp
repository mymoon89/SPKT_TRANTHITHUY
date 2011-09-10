// fboenvmap.cpp
// OpenGL SuperBible, Chapter 18
// Demonstrates environment mapping with FBOs
// Program by Benjamin Lipchak

#include "../../shared/gltools.h"   // OpenGL toolkit
#include "../../shared/stopwatch.h" // General purpose stop watch class

#include <assert.h>
#include <stdio.h>

GLboolean npotTexturesAvailable = GL_FALSE;
GLboolean useEnvMap = GL_TRUE;          // just basemap
GLboolean showEnvMap = GL_FALSE;        // show the envmap texture
GLboolean useFBO = GL_FALSE;            // Use FBO texture image for envmap

GLint windowWidth = 512;                // window size
GLint windowHeight = 512;

GLint envMapSize = 512;                 // set based on window size
GLuint wallTextureID[5];                // textures for walls + 1 for displaying envmap
GLuint envMapTextureID;                 // envmap name
GLint maxCubeTexSize;                   // maximum allowed size for cube map texture

GLuint framebufferID;                   // FBO name
GLuint renderbufferID;                  // renderbuffer object name
GLint maxRenderbufferSize;              // maximum allowed size for FBO renderbuffer

GLfloat ambientLight[] = { 0.4f, 0.4f, 0.4f, 1.0f};
GLfloat diffuseLight[] = { 0.6f, 0.6f, 0.6f, 1.0f};
GLfloat specularLight[] = { 1.0f, 1.0f, 1.0f, 1.0f};
GLfloat lightPos[]     = { 0.0f, 125.0f, 0.0f, 1.0f};

GLfloat cameraPos[]    = { 50.0f, 50.0f, 100.0f, 1.0f};
GLdouble cameraZoom = 1.5;

GLfloat animationAngle = 0.0f;          // used to spin objects

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
        if (useEnvMap)
        {
            GLfloat mv[16], invMV[16];

            glEnable(GL_TEXTURE_CUBE_MAP);
            glEnable(GL_TEXTURE_GEN_S);
            glEnable(GL_TEXTURE_GEN_T);
            glEnable(GL_TEXTURE_GEN_R);

            // we need to put the eye space reflection vector
            // back into world space by multiplying by the
            // transpose of the modelview matrix
            glGetFloatv(GL_MODELVIEW_MATRIX, mv);
            // only the top-left 3x3 is used for transforming 3-vec normal
            // the rest should be identity
            invMV[0]  = mv[0]; invMV[1]  = mv[4]; invMV[2]  = mv[8];  invMV[3]  = 0;
            invMV[4]  = mv[1]; invMV[5]  = mv[5]; invMV[6]  = mv[9];  invMV[7]  = 0;
            invMV[8]  = mv[2]; invMV[9]  = mv[6]; invMV[10] = mv[10]; invMV[11] = 0;
            invMV[12] = 0;     invMV[13] = 0;     invMV[14] = 0;      invMV[15] = 1;
            glMatrixMode(GL_TEXTURE);
            glPushMatrix();
            glLoadMatrixf(invMV);
            glMatrixMode(GL_MODELVIEW);
        }
        glFrontFace(GL_CW);
        glutSolidTeapot(25.0f);
        glFrontFace(GL_CCW);
        if (useEnvMap)
        {
            glDisable(GL_TEXTURE_CUBE_MAP);
            glDisable(GL_TEXTURE_GEN_S);
            glDisable(GL_TEXTURE_GEN_T);
            glDisable(GL_TEXTURE_GEN_R);
            glMatrixMode(GL_TEXTURE);
            glPopMatrix();
            glMatrixMode(GL_MODELVIEW);
        }
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

// Called to regenerate the envmap
void RegenerateEnvMap(void)
{
    // generate 6 views from origin of teapot (0,0,0)

    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluPerspective(90.0f, 1.0f, 1.0f, 125.0f);
    glViewport(0, 0, envMapSize, envMapSize);

    if (useFBO)
        glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID);

    for (GLenum i = GL_TEXTURE_CUBE_MAP_POSITIVE_X; i < GL_TEXTURE_CUBE_MAP_POSITIVE_X+6; i++)
    {
        glMatrixMode(GL_MODELVIEW);
        glLoadIdentity();

        switch (i)
        {
        case GL_TEXTURE_CUBE_MAP_POSITIVE_X:
            // +X
            gluLookAt(0.0f, 0.0f, 0.0f, 
                      1.0f, 0.0f, 0.0f, 0.0f, -1.0f, 0.0f);
            break;
        case GL_TEXTURE_CUBE_MAP_NEGATIVE_X:
            // -X
            gluLookAt(0.0f, 0.0f, 0.0f, 
                      -1.0f, 0.0f, 0.0f, 0.0f, -1.0f, 0.0f);
            break;
        case GL_TEXTURE_CUBE_MAP_POSITIVE_Y:
            // +Y
            gluLookAt(0.0f, 0.0f, 0.0f, 
                      0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f);
            break;
        case GL_TEXTURE_CUBE_MAP_NEGATIVE_Y:
            // -Y
            gluLookAt(0.0f, 0.0f, 0.0f, 
                      0.0f, -1.0f, 0.0f, 0.0f, 0.0f, -1.0f);
            break;
        case GL_TEXTURE_CUBE_MAP_POSITIVE_Z:
            // +Z
            gluLookAt(0.0f, 0.0f, 0.0f, 
                      0.0f, 0.0f, 1.0f, 0.0f, -1.0f, 0.0f);
            break;
        case GL_TEXTURE_CUBE_MAP_NEGATIVE_Z:
            // -Z
            gluLookAt(0.0f, 0.0f, 0.0f, 
                      0.0f, 0.0f, -1.0f, 0.0f, -1.0f, 0.0f);
            break;
        default:
            assert(0);
            break;
        }
        
        if (useFBO)
            glFramebufferTexture2DEXT(GL_FRAMEBUFFER_EXT, GL_COLOR_ATTACHMENT0_EXT, i, envMapTextureID, 0);

        // Clear the window with current clearing color
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        // Draw objects in the scene except for the teapot
        DrawModels(GL_FALSE);

        if (!useFBO)
            glCopyTexImage2D(i, 0, GL_RGBA8, 0, 0, envMapSize, envMapSize, 0);
    }

    if (useFBO)
    {
        glGenerateMipmapEXT(GL_TEXTURE_CUBE_MAP);
        GLenum fboStatus = glCheckFramebufferStatusEXT(GL_FRAMEBUFFER_EXT);
        if (fboStatus != GL_FRAMEBUFFER_COMPLETE_EXT)
        {
            fprintf(stderr, "FBO Error!\n");
        }

        glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, 0);
    }
}

// Called to draw scene
void RenderScene(void)
{
    static int iFrames = 0;           // Frame count
    static CStopWatch frameTimer;     // Render time
 
    // Reset the stopwatch on first time
    if(iFrames == 0)
    {
        frameTimer.Reset();
        iFrames++;
    }

    // spin objects
    animationAngle += 1.0f;
    if (animationAngle == 360.0f) animationAngle = 0.0f;

    // generate the environment map
    if (useEnvMap)
        RegenerateEnvMap();

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

    glViewport(0, 0, windowWidth, windowHeight);
    
    // Clear the window with current clearing color
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    if (showEnvMap)
    {
        // Display envmap for educational purposes
        glMatrixMode(GL_PROJECTION);
        glPushMatrix();
        glLoadIdentity();
        glMatrixMode(GL_MODELVIEW);
        glPushMatrix();
        glLoadIdentity();

        glEnable(GL_TEXTURE_2D);
        glBindTexture(GL_TEXTURE_2D, wallTextureID[4]);
        glDisable(GL_LIGHTING);

        glColor4f(1.0f, 1.0f, 1.0f, 1.0f);

        GLubyte *texels = (GLubyte *)malloc(envMapSize * envMapSize * 4);
        assert(texels);

        for (GLenum i = GL_TEXTURE_CUBE_MAP_POSITIVE_X; i < GL_TEXTURE_CUBE_MAP_POSITIVE_X+6; i++)
        {
            // Grab the cubemap face
            glGetTexImage(i, 0, GL_RGBA, GL_UNSIGNED_BYTE, texels);
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA8, envMapSize, envMapSize,0, GL_RGBA, GL_UNSIGNED_BYTE, texels);

            glPushMatrix();

            // position the cube face for display
            switch (i)
            {
            case GL_TEXTURE_CUBE_MAP_POSITIVE_X:
                glTranslatef(0.25f, 0.0f, 0.0f);
                break;
            case GL_TEXTURE_CUBE_MAP_NEGATIVE_X:
                glTranslatef(-0.75f, 0.0f, 0.0f);
                break;
            case GL_TEXTURE_CUBE_MAP_POSITIVE_Y:
                glTranslatef(-0.25f, -0.5f, 0.0f);
                break;
            case GL_TEXTURE_CUBE_MAP_NEGATIVE_Y:
                glTranslatef(-0.25f, 0.5f, 0.0f);
                break;
            case GL_TEXTURE_CUBE_MAP_POSITIVE_Z:
                glTranslatef(-0.25f, 0.0f, 0.0f);
                break;
            case GL_TEXTURE_CUBE_MAP_NEGATIVE_Z:
                glTranslatef(+0.75f, 0.0f, 0.0f);
                break;
            default:
                assert(0);
                break;
            }

            glScalef(0.25f, 0.25f, 0.25f);

            glBegin(GL_QUADS);
                glTexCoord2f(0.0f, 0.0f);
                glVertex2f(-1.0f, -1.0f);
                glTexCoord2f(1.0f, 0.0f);
                glVertex2f(1.0f, -1.0f);
                glTexCoord2f(1.0f, 1.0f);
                glVertex2f(1.0f, 1.0f);
                glTexCoord2f(0.0f, 1.0f);
                glVertex2f(-1.0f, 1.0f);
            glEnd();

            glPopMatrix();
        }

        free(texels);

        glDisable(GL_TEXTURE_2D);
        glEnable(GL_LIGHTING);

        glPopMatrix();
        glMatrixMode(GL_PROJECTION);
        glPopMatrix();
        glMatrixMode(GL_MODELVIEW);
    }
    else
    {
        // Draw objects in the scene, including teapot
        DrawModels(GL_TRUE);
    }
    
    if (glGetError() != GL_NO_ERROR)
        fprintf(stderr, "GL Error!\n");

    // Flush drawing commands
    glutSwapBuffers();

    // Increment the frame count
    iFrames++;

    // Do periodic frame rate calculation
    if (iFrames == 101)
    {
        float fps;
        char cBuffer[64];

        fps = 100.0f / frameTimer.GetElapsedSeconds();
        if (useFBO)
            sprintf(cBuffer,"Draw scene with FBOs %.1f fps", fps);
        else
            sprintf(cBuffer,"Draw scene without FBOs %.1f fps", fps);

        glutSetWindowTitle(cBuffer);
        frameTimer.Reset();
        iFrames = 1;
    }
}

void SetupTextures(void)
{
    // Create 5 texture objects and load up 4 of them
    glGenTextures(5, wallTextureID);

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

    // This texture will be used for displaying the envmap for education purposes
    glBindTexture(GL_TEXTURE_2D, wallTextureID[4]);
    glTexParameteri(GL_TEXTURE_2D, GL_GENERATE_MIPMAP, 1);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

    // Set up some more texture state that never changes
    glGenTextures(1, &envMapTextureID);
    glBindTexture(GL_TEXTURE_CUBE_MAP, envMapTextureID);
    glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_GENERATE_MIPMAP, 1);
    glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
    glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
    glTexParameteri(GL_TEXTURE_CUBE_MAP, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    glTexGeni(GL_S, GL_TEXTURE_GEN_MODE, GL_REFLECTION_MAP);
    glTexGeni(GL_T, GL_TEXTURE_GEN_MODE, GL_REFLECTION_MAP);
    glTexGeni(GL_R, GL_TEXTURE_GEN_MODE, GL_REFLECTION_MAP);

    // this may change with window size changes
    for (GLenum i = GL_TEXTURE_CUBE_MAP_POSITIVE_X; i < GL_TEXTURE_CUBE_MAP_POSITIVE_X+6; i++)
    {
        glTexImage2D(i, 0, GL_RGBA8, envMapSize, envMapSize, 0, GL_RGBA, GL_UNSIGNED_BYTE, 0);
    }
}

// This function does any needed initialization on the rendering
// context. 
void SetupRC()
{
    fprintf(stdout, "FBO Environment Mapping Demo\n\n");

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
        fprintf(stderr, "Environment map will be lower resolution (lower quality).\n\n");
    }

    if (!GLEE_EXT_framebuffer_object)
    {
        fprintf(stderr, "GL_EXT_framebuffer_object extension is unavailable!\n");
        Sleep(2000);
        exit(0);
    }

    glGetIntegerv(GL_MAX_CUBE_MAP_TEXTURE_SIZE, &maxCubeTexSize);
    glGetIntegerv(GL_MAX_RENDERBUFFER_SIZE_EXT, &maxRenderbufferSize);
    maxCubeTexSize = (maxRenderbufferSize > maxCubeTexSize) ? maxCubeTexSize : maxRenderbufferSize;
    // performance suffers too much at higher texture sizes
 //   maxCubeTexSize = (maxCubeTexSize > 1024) ? 1024 : maxCubeTexSize;

    fprintf(stdout, "Controls:\n");
    fprintf(stdout, "\tRight-click for menu\n\n");
    fprintf(stdout, "\tx/X\t\tMove +/- in x direction\n");
    fprintf(stdout, "\ty/Y\t\tMove +/- in y direction\n");
    fprintf(stdout, "\tz/Z\t\tMove +/- in z direction\n\n");
    fprintf(stdout, "\tf/F\t\tChange polygon offset factor +/-\n\n");
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

    // Set up textures
    SetupTextures();

    // Set up some renderbuffer state
    glGenFramebuffersEXT(1, &framebufferID);
    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, framebufferID);
    glGenRenderbuffersEXT(1, &renderbufferID);
    glBindRenderbufferEXT(GL_RENDERBUFFER_EXT, renderbufferID);
    glRenderbufferStorageEXT(GL_RENDERBUFFER_EXT, GL_DEPTH_STENCIL_EXT, envMapSize, envMapSize);
    glFramebufferRenderbufferEXT(GL_FRAMEBUFFER_EXT, GL_DEPTH_ATTACHMENT_EXT, GL_RENDERBUFFER_EXT, renderbufferID);
    glFramebufferRenderbufferEXT(GL_FRAMEBUFFER_EXT, GL_STENCIL_ATTACHMENT_EXT, GL_RENDERBUFFER_EXT, renderbufferID);
    glBindFramebufferEXT(GL_FRAMEBUFFER_EXT, 0);
}

void ChangeSize(int w, int h)
{
    GLint origEnvMapSize = envMapSize;
    GLint i;
    windowWidth = w;
    windowHeight = h;

    if (useFBO)
    {
        // env map is limited by max supported renderbuffer size
        envMapSize = maxCubeTexSize;
    }
    else
    {
        // env map is limited to size of window
        envMapSize = (w > h) ? h : w;
    }
    
    if (!npotTexturesAvailable)
    {
        // Find the largest power of two that will fit in window.

        // Try each size until we get one that's too big
        i = 0;
        while ((1 << i) <= envMapSize)
            i++;
        envMapSize = (1 << (i-1));
    }

    if (envMapSize > maxCubeTexSize)
    {
        envMapSize = maxCubeTexSize;
    }

    if (origEnvMapSize != envMapSize)
    {
        glRenderbufferStorageEXT(GL_RENDERBUFFER_EXT, GL_DEPTH_COMPONENT32, envMapSize, envMapSize);

        for (GLenum i = GL_TEXTURE_CUBE_MAP_POSITIVE_X; i < GL_TEXTURE_CUBE_MAP_POSITIVE_X+6; i++)
        {
            glTexImage2D(i, 0, GL_RGBA8, envMapSize, envMapSize, 0, GL_RGBA, GL_UNSIGNED_BYTE, 0);
        }
    }
}

void ProcessMenu(int value)
{
    switch(value)
    {
    case 1:
        useEnvMap = !useEnvMap;
        showEnvMap = GL_FALSE;
        if (useEnvMap)
        {
            glutChangeToMenuEntry(1, "Toggle envmap (currently ON)", 1);
        }
        else
        {
            glutChangeToMenuEntry(1, "Toggle envmap (currently OFF)", 1);
        }
        glutChangeToMenuEntry(2, "Toggle show envmap (currently OFF)", 2);
        break;

    case 2:
        showEnvMap = !showEnvMap;
        useEnvMap = GL_TRUE;
        if (showEnvMap)
        {
            glutChangeToMenuEntry(2, "Toggle show envmap (currently ON)", 2);
        }
        else
        {
            glutChangeToMenuEntry(2, "Toggle show envmap (currently OFF)", 2);
        }
        glutChangeToMenuEntry(1, "Toggle envmap (currently ON)", 1);
        break;

    case 3:
        useFBO = !useFBO;
        if (useFBO)
        {
            glutChangeToMenuEntry(3, "Toggle FBO usage (currently ON)", 3);
        }
        else
        {
            glutChangeToMenuEntry(3, "Toggle FBO usage (currently OFF)", 3);
        }
        ChangeSize(windowWidth, windowHeight);
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
    case 'e':
    case 'E':
        useEnvMap = !useEnvMap;
        showEnvMap = GL_FALSE;
        if (useEnvMap)
        {
            glutChangeToMenuEntry(1, "Toggle envmap (currently ON)", 1);
        }
        else
        {
            glutChangeToMenuEntry(1, "Toggle envmap (currently OFF)", 1);
        }
        glutChangeToMenuEntry(2, "Toggle show envmap (currently OFF)", 2);
        break;
    case 'f':
    case 'F':
        useFBO = !useFBO;
        if (useFBO)
        {
            glutChangeToMenuEntry(3, "Toggle FBO usage (currently ON)", 3);
        }
        else
        {
            glutChangeToMenuEntry(3, "Toggle FBO usage (currently OFF)", 3);
        }
        ChangeSize(windowWidth, windowHeight);
        break;
    case 's':
    case 'S':
        showEnvMap = !showEnvMap;
        useEnvMap = GL_TRUE;
        if (showEnvMap)
        {
            glutChangeToMenuEntry(2, "Toggle show envmap (currently ON)", 2);
        }
        else
        {
            glutChangeToMenuEntry(2, "Toggle show envmap (currently OFF)", 2);
        }
        glutChangeToMenuEntry(1, "Toggle envmap (currently ON)", 1);
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
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH | GLUT_MULTISAMPLE);
    glutInitWindowSize(windowWidth, windowHeight);
    glutCreateWindow("FBO Environment Mapping Demo");
    glutReshapeFunc(ChangeSize);
    glutKeyboardFunc(KeyPressFunc);
    glutSpecialFunc(SpecialKeys);
    glutDisplayFunc(RenderScene);
    glutIdleFunc(RenderScene);

    // Create the Menu
    glutCreateMenu(ProcessMenu);
    glutAddMenuEntry("Toggle envmap (currently ON)", 1);
    glutAddMenuEntry("Toggle show envmap (currently OFF)", 2);
    glutAddMenuEntry("Toggle FBO usage (currently OFF)", 3);
    glutAttachMenu(GLUT_RIGHT_BUTTON);

    SetupRC();

    glutMainLoop();

    glDeleteTextures(1, &envMapTextureID);
    glDeleteTextures(5, wallTextureID);
    if (glDeleteFramebuffersEXT)
        glDeleteFramebuffersEXT(1, &framebufferID);
    if (glDeleteRenderbuffersEXT)
        glDeleteRenderbuffersEXT(1, &renderbufferID);

    return 0;
}
