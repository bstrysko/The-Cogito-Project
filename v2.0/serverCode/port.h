#ifndef PORT_H
#define PORT_H

#include <usb.h>
#include "opendevice.h"
#include "control.h"

class Port
{
	private:
		char port;

	protected:
		void initPort(char _port);
		char controlPin(char pin,char state);
		char getPin(char pin);
};


#endif
