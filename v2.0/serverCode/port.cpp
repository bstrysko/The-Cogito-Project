#include "port.h"

void Port::initPort(char _port)
{
	port = _port;
}

char Port::controlPin(char pin,char status)
{
	char buffer[2];
	
	char bytes = Control::command(port,pin,status,buffer);
	
	if(bytes == 1)
	{
		return buffer[0];
	}
	else 
	{
		if(buffer[0])
		{
			if(buffer[1])
			{
				return 2;
			}
			else 
			{
				return 1;
			}

		}
		else
		{
			return 3;
		}
	}
}

char Port::getPin(char pin)
{
	return controlPin(pin,4);
}
