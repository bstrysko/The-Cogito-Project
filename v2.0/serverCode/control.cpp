#include "control.h"

usb_dev_handle* Control::handle = 0;

bool Control::initialize()
{
	const unsigned char rawVid[2] = {USB_CFG_VENDOR_ID}, rawPid[2] = {USB_CFG_DEVICE_ID};	
	char vendor[] = {USB_CFG_VENDOR_NAME, 0}, product[] = {USB_CFG_DEVICE_NAME, 0};
	int vid, pid;
	
	usb_init();
	
    vid = rawVid[1] * 256 + rawVid[0];
    pid = rawPid[1] * 256 + rawPid[0];
	
    return usbOpenDevice(&handle, vid, vendor, pid, product,NULL,NULL,NULL)?false:true;
}

char Control::command(char port,char pin,char status,char* buffer)
{
	return usb_control_msg(handle, USB_TYPE_VENDOR | USB_RECIP_DEVICE | USB_ENDPOINT_IN,port,status,pin,buffer,sizeof(buffer),5000);
}


void Control::release()
{
	usb_close(handle);
}
