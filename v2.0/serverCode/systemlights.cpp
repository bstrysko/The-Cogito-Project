#include "systemlights.h"

SystemLights::SystemLights(char port)
{
	initPort(port);
	cathode = false;
	warning = false;
}

void SystemLights::turnCathode(bool on)
{
	controlPin(1,on?2:1);
	cathode = on;
}

void SystemLights::toggleCathode()
{
	turnCathode(!cathode);
}

void SystemLights::turnWarning(bool on)
{
	controlPin(2,on?2:1);
	warning = on;
}

void SystemLights::toggleWarning()
{
	turnWarning(!warning);
}
