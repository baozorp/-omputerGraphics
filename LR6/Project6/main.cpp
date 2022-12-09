#include <windows.h>
#include <GL/glut.h> 


static GLfloat spin = 0;

void display()
{
    GLUquadricObj* figure = gluNewQuadric();
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    glTranslatef(0.0, 0.0, -12.0);
    glRotatef(spin, 2.0, 0.5, 1.0);

    //glColor3f(0.45, 0.55, 0.45);
    //gluCylinder(figure, 2, 2, 5, 5, 1);

    //glColor3f(0.4, 0.5, 0.4);
    //gluDisk(figure, 0, 2, 5, 1);
    //glTranslatef(0.0, 0.0, 5.0);
    //gluDisk(figure, 0, 2, 5, 1);
    glBegin(GL_POLYGON);
    glColor3f(0.5f, 0.4f, 0.4f);
    glVertex3f(-2.5f, 4.0f, 3.0f);
    glVertex3f(-7.0f, 4.0f, 0.0f);
    glVertex3f(-5.0f, 4.0f, -4.0f);
    glVertex3f(0.0f, 4.0f, -4.0f);
    glVertex3f(2.0f, 4.0f, 0.0f);
    glEnd();

    glBegin(GL_POLYGON);
    glColor3f(0.5f, 0.4f, 0.4f);
    glVertex3f(-2.5f, -4.0f, 3.0f);
    glVertex3f(-7.0f, -4.0f, 0.0f);
    glVertex3f(-5.0f, -4.0f, -4.0f);
    glVertex3f(0.0f, -4.0f, -4.0f);
    glVertex3f(2.0f, -4.0f, 0.0f);
    glEnd();

    glBegin(GL_QUADS);
    glColor3f(0.4f, 0.4f, 0.4f);
    glVertex3f(-5.0f, -4.0f, -4.0f);
    glVertex3f(-7.0f, -4.0f, 0.0f);
    glVertex3f(-7.0f, 4.0f, 0.0f);
    glVertex3f(-5.0f, 4.0f, -4.0f);

    glColor3f(0.4f, 0.4f, 0.45f);
    glVertex3f(-2.5f, -4.0f, 3.0f);
    glVertex3f(-7.0f, -4.0f, 0.0f);
    glVertex3f(-7.0f, 4.0f, 0.0f);
    glVertex3f(-2.5f, 4.0f, 3.0f);

    glColor3f(0.4f, 0.4f, 0.35f);
    glVertex3f(-2.5f, -4.0f, 3.0f);
    glVertex3f(2.0f, -4.0f, 0.0f);
    glVertex3f(2.0f, 4.0f, 0.0f);
    glVertex3f(-2.5f, 4.0f, 3.0f);

    glColor3f(0.4f, 0.35f, 0.4f);
    glVertex3f(0.0f, -4.0f, -4.0f);
    glVertex3f(2.0f, -4.0f, 0.0f);
    glVertex3f(2.0f, 4.0f, 0.0f);
    glVertex3f(0.0f, 4.0f, -4.0f);

    glColor3f(0.4f, 0.4f, 0.45f);
    glVertex3f(0.0f, -4.0f, -4.0f);
    glVertex3f(-5.0f, -4.0f, -4.0f);
    glVertex3f(-5.0f, 4.0f, -4.0f);
    glVertex3f(0.0f, 4.0f, -4.0f);
    glEnd();


    Sleep(10);
    glLoadIdentity();
    glutSwapBuffers();
}

void reshape(int width, int height) {
    if (height == 0) height = 1;
    GLfloat aspect = width / height;
    glViewport(0, 0, width, height);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluPerspective(-100.0, aspect, 0.1, 100.0);
}

void init() {
    glClearColor(0.2, 0.4, 0.5, 0.0);
    glClearDepth(1.0);
    glEnable(GL_DEPTH_TEST);
    glDepthFunc(GL_LEQUAL);
    glShadeModel(GL_SMOOTH);
    glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);
}

void spinDisplay(void)
{
    spin = spin + 1.5;
    if (spin > 360.0)
        spin = spin - 360.0;
    glutPostRedisplay();
}

void mouseClickEvent(int buttom, int state, int x, int y)
{
    switch (buttom)
    {
    case GLUT_LEFT_BUTTON:
    {
        if (state == GLUT_DOWN)
            glutIdleFunc(spinDisplay);
        break;
    }

    case GLUT_RIGHT_BUTTON:
    {
        if (state == GLUT_DOWN)
            glutIdleFunc(NULL);
        break;
    }
    default:break;
    }
}

int main(int argc, char** argv)
{
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE);
    glutInitWindowSize(600, 600);
    glutInitWindowPosition(100, 100);
    glutCreateWindow("LR6");
    init();
    glutMouseFunc(mouseClickEvent);
    glutDisplayFunc(display);
    glutReshapeFunc(reshape);
    glutMainLoop();
    return 0;
}