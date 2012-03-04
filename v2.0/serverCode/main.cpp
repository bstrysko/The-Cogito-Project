#include <iostream>
#include <stdlib.h>
#include "systemlights.h"

using namespace std;

void sleep_ns(long ns)
{
	long temp = clock() + ns;
	
	while(clock() < temp){}
}

void speak(string message)
{
	//calling festival from the command line requires the use of both single and double quotes within the string
	//because first you must tell the command line the stuff inside the () is an argument and then you must use double quotes
	//to specify what it should speak

	string temp = "festival -b '(SayText \""+message+"\")'\0";

	system(temp.c_str());
}

int main(int argc,char** argv)
{
	Control::initialize();
	
	SystemLights l(0);
	
	int i=0;
	
	while(1)
	{
		l.toggleWarning();
		sleep_ns(20000);
		l.toggleCathode();
		sleep_ns(20000);
		i++;
	}
	Control::release();
	//speak("Hello World");
}
