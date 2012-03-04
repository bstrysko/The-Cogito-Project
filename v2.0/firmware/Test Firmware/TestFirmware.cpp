/* The Cogito Project v2.0 Test Firmware Program
 * Written by Brent Strysko
 * Code based off of custom-class example from V-USB
 * License: GPL V2
 */

#include <iostream>

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <usb.h>
#include "opendevice.h"

#include "../usbconfig.h"

using namespace std;

void sleep_ns(long ns)
{
	long temp = clock() + ns;
	
	while(clock() < temp){}
}

int main(int argc, char **argv)
{
	usb_dev_handle* handle;
	const unsigned char rawVid[2] = {USB_CFG_VENDOR_ID}, rawPid[2] = {USB_CFG_DEVICE_ID};	
	char vendor[] = {USB_CFG_VENDOR_NAME, 0}, product[] = {USB_CFG_DEVICE_NAME, 0};
	char buffer[4];
	int cnt, vid, pid;
	char cmd;
	char count[3];
	
	int port,pin,status;
	
	usb_init();

    vid = rawVid[1] * 256 + rawVid[0];
    pid = rawPid[1] * 256 + rawPid[0];
		
    if(usbOpenDevice(&handle, vid, vendor, pid, product,NULL,NULL,NULL))
	{
		cout << "Control board not detected" << endl;
		exit(1);
    }
	
	cout << "Enter Port #(0-3):";
	cin >> port;
	cout << "Enter Pin #(1-2):";
	cin >> pin;
	cout << "Enter Pin Status(1-3):";
	cin >> status;
				
	cnt = usb_control_msg(handle, USB_TYPE_VENDOR | USB_RECIP_DEVICE | USB_ENDPOINT_IN,port,status,pin,buffer,sizeof(buffer),5000);
	
	cout << "Bytes Received:" << cnt << endl;
	cout << "Output DDR:"<<((int)buffer[0]) << endl;
	cout << "Output Port:"<<((int)buffer[1]) << endl;
	
    usb_close(handle);
    return 0;
}