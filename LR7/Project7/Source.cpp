#include <windows.h> 
#include <GL/glut.h>  
#include <SOIL.h>


float k = 5;
float lightDif[3] = { 1, 1, 1 };
float lightPos[4] = { -30.0, -30.0, 10.0, 0.0 };
int w, h;
bool textureEnabled = true;
bool isFilled = true;
bool mouseClicked = true;
int spin = 250, spinh = -90;
GLubyte* image;


void display()
{
	GLUquadricObj* figure = gluNewQuadric();
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glMatrixMode(GL_MODELVIEW);
	glEnable(GL_LIGHTING);
	glTranslatef(0, 0, -60.0);
	glRotatef(spin, 1, 1, 0);
	glRotatef(spinh, 0, 0, 1);

	if (mouseClicked) {
		glEnable(GL_LIGHT1);
		gluQuadricTexture(figure, GL_TRUE);
	}
	else {
		glDisable(GL_LIGHT1);
		gluQuadricTexture(figure, GL_TRUE);
	}
	if (textureEnabled)
	{
		glEnable(GL_TEXTURE_2D);
		gluQuadricTexture(figure, GL_TRUE);
	}
	else
	{
		glDisable(GL_TEXTURE_2D);
		gluQuadricTexture(figure, GL_FALSE);
	}
	if (isFilled)
	{
		glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
		gluQuadricDrawStyle(figure, GLU_FILL);
	}
	else
	{
		glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
		gluQuadricDrawStyle(figure, GLU_LINE);
	}
	GLuint texture;
	glGenTextures(1, &texture);
	glBindTexture(GL_TEXTURE_2D, texture);
	gluBuild2DMipmaps(GL_TEXTURE_2D, 3, w, h, GL_RGB, GL_UNSIGNED_BYTE, image);

	glTranslatef(0.0, 0.0, 0.0);
	gluCylinder(figure, 2, 2, 3, 5, 1);
	gluDisk(figure, 0, 2, 5, 1);

	glTranslatef(0.0, 0.0, 3.0);
	gluDisk(figure, 0, 2, 5, 1);

	glTranslatef(0.0, 0.0, -10.0);
	gluSphere(figure, 1.5, 30, 30);
	
	glTranslatef(-5.0, 3.0, -3.0);
	glLightfv(GL_LIGHT1, GL_POSITION, lightPos);
	glLightfv(GL_LIGHT1, GL_DIFFUSE, lightDif);
	glLoadIdentity();
	glutSwapBuffers();


}

void OnKeyIvent(int key, int x, int y)
{
	if (key == GLUT_KEY_LEFT)
	{
		spin -= 10 + 360;
		spin %= 360;
	}

	if (key == GLUT_KEY_RIGHT)
	{
		spin += 10;
		spin %= 360;
	}

	if (key == GLUT_KEY_UP)
	{
		spinh -= 10 + 360;
		spinh %= 360;
	}

	if (key == GLUT_KEY_DOWN)
	{
		spinh += 10;
		spinh %= 360;
	}
	glutPostRedisplay();
}

void init()
{
	glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
	glClearDepth(1.0f);
	glutSpecialFunc(OnKeyIvent);
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LEQUAL);
	glShadeModel(GL_SMOOTH);
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);
}

void Reshape(int w, int h)
{
	glViewport(0, 0, w, h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(20.0f, w / h, 0.1f, 100.0f);
}


void mouse_click(int button, int state, int x, int y)
{
	if (!mouseClicked)
	{
		if (button == 0)
		{
			textureEnabled = !textureEnabled;
		}

		else if (button == 2)
		{
			isFilled = !isFilled;
		}
		mouseClicked = true;
	}
	else
	{
		mouseClicked = false;
	}


	if (button == 3)
	{
		lightPos[0]--;
	}
	else if (button == 4)
	{
		lightPos[0]++;
	}

	glutPostRedisplay();
}


int main(int argc, char** argv)
{
	image = SOIL_load_image("31.jpg", &w, &h, 0, SOIL_LOAD_RGB);
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE);
	glutInitWindowSize(700, 700);
	glutInitWindowPosition(50, 50);
	glutCreateWindow("LR7");
	init();
	glutMouseFunc(mouse_click);
	glutDisplayFunc(display);
	glutReshapeFunc(Reshape);
	glLightModeli(GL_LIGHT_MODEL_TWO_SIDE, GL_TRUE);
	glutMainLoop();
	return 0;
}


    
