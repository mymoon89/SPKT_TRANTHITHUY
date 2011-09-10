// shaders.h
// OpenGL SuperBible
// Demonstrates GLSL shaders
// Program by Benjamin Lipchak

#include "../../shared/SuperbibleSample.h"

class Shaders : public SuperbibleSample
{
private:
    GLboolean useVertexShader;
    GLboolean useFragmentShader;
    GLboolean doBlink;

    GLboolean needsValidation;

    GLint flickerLocation;

public:
    GLuint vShader, fShader, progObj;

    Shaders();
    ~Shaders();

    // static callbacks
    static void MyProcessMenu(int value);

    void ProcessMenu(int value);

    void Link(GLboolean firstTime);
    void Relink();
    void InsideRender();
    void DrawModels();
    void SetupRC();
};
