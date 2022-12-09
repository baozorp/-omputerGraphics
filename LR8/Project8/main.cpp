#include <windows.h>
#include <GL/glut.h>
#include <math.h>

GLfloat turnKoef = 0.0f;
int refreshMills = 5;
float koefx;
bool mouseClicked = false;

float func(float x, float y)
{
    return cos(x) - 2 * sin(y);
}

void display() {
    if (mouseClicked) {
        koefx = 0.5;
    }
    else {
        koefx = 1.5;
    }
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glMatrixMode(GL_MODELVIEW);

    glLoadIdentity();
    glTranslatef(0.0f, 0.0f, -70.0f);
    glRotatef(turnKoef, 1.0f, 1.0f, 1.0f);

    glColor3f(0.4, 0.5, 0.4);
    for (float y = -50; y < 50; y += koefx)
    {
        glBegin(GL_QUAD_STRIP);
        for (float x = -50; x < 50; x += koefx)
        {
            glVertex3f(x, y, func(x, y));
            glVertex3f(x + 0.5, y, func(x + 0.5, y));
            glVertex3f(x, y + 0.5, func(x, y + 0.5));
            glVertex3f(x + 0.5, y + 0.5, func(x + 0.5, y + 0.5));
        }
        glEnd();
    }

    glutSwapBuffers();
    turnKoef -= 0.15f;
}

void mouse_click(int button, int state, int x, int y)
{
    if (button == 0)
    {
        mouseClicked = true;
    }
    else {
        mouseClicked = false;
    }
}

void timer(int value) {
    glutPostRedisplay();
    glutTimerFunc(refreshMills, timer, 0);
}

void initGL() {
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
    glClearDepth(1.0f);
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LEQUAL);
    glShadeModel(GL_SMOOTH);
    glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);
}

void reshape(GLsizei width, GLsizei height) {
    if (height == 0) height = 1;
    GLfloat aspect = (GLfloat)width / (GLfloat)height;
    glViewport(0, 0, width, height);

    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluPerspective(120.0f, aspect, 0.1f, 100.0f);
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE);
    glutInitWindowSize(640, 480);
    glutInitWindowPosition(50, 50);
    glutCreateWindow("LR8");
    glutMouseFunc(mouse_click);
    glutDisplayFunc(display);
    glutReshapeFunc(reshape);
    initGL();
    glutTimerFunc(0, timer, 0);
    glutMainLoop();
    return 0;
}