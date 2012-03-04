#ifndef SYSTEMLIGHTS_H
#define SYSTEMLIGHTS_H

#include "port.h"

class SystemLights : Port
{
	private:
		bool cathode,warning;
	
	public:
		SystemLights(char port);
	
		void turnCathode(bool on);
		void toggleCathode();
	
		void turnWarning(bool on);
		void toggleWarning();
};


#endif
