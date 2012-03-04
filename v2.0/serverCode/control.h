#ifndef CONTROL_H
#define CONTROL_H

#include <usb.h>
#include "opendevice.h"
#include "../firmware/usbconfig.h"

class Control
{
	private:
		static usb_dev_handle* handle;
 
	public:
		static bool initialize();
		static char command(char port,char pin,char status,char* buffer);
		static void release();
};


#endif
