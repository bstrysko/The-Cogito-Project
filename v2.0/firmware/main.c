/* The Cogito Project v2.0 Firmware
 * Written by Brent Strysko
 * Code based off of custom-class example from V-USB
 * License: GPL V2
 */

#include <avr/io.h>
#include <avr/wdt.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <avr/pgmspace.h>
#include "usbdrv.h"
#include "oddebug.h"

#define PERIPHERAL_DDR DDRC
#define PERIPHERAL_PORT PORTC
#define PERIPHERAL_PIN PINC

#define SIGNALS_DDR DDRD
#define SIGNALS_PORT PORTD
#define SIGNALS_PIN PIND

#define PIN_LOW 1
#define PIN_HIGH 2
#define PIN_HIGHZ 3

usbMsgLen_t usbFunctionSetup(uchar data[8])
{
	usbRequest_t *rq = (void *)data;
	static uchar dataBuffer[4];
	uchar pinPosition;
	
	usbMsgPtr = dataBuffer;
	
	//rq->bRequest = port #
	//rq->wIndex[0] = pin
	//rq->wValue[0] = pin value
	
	//if port # <0 or >3,pin # <1 or >2, pin value <1 or >3 return error status
	if((rq->bRequest < 0) || (rq->bRequest > 3) || (rq->wIndex.bytes[0] < 1) || (rq->wIndex.bytes[0] > 2) || (rq->wValue.bytes[0] < PIN_LOW) || (rq->wValue.bytes[0] > PIN_HIGHZ+1))
	{
		dataBuffer[0] = 127;
		return 1;
	}
	else if(rq->bRequest == 0)
	{	
		pinPosition = rq->wIndex.bytes[0]-1;
		
		if(rq->wValue.bytes[0] == PIN_HIGHZ)
		{
			SIGNALS_DDR &= ~(_BV(pinPosition));
		}
		else if(rq->wValue.bytes[0] == PIN_LOW)
		{
			SIGNALS_DDR |= _BV(pinPosition);
			SIGNALS_PORT &= (~_BV(pinPosition));
		}
		else if(rq->wValue.bytes[0] == PIN_HIGH)
		{
			SIGNALS_DDR |= _BV(pinPosition);
			SIGNALS_PORT |= _BV(pinPosition);
		}
		
		dataBuffer[0] = (SIGNALS_DDR & _BV(pinPosition));
		dataBuffer[1] = (SIGNALS_PORT & _BV(pinPosition));

	}
	else
	{
		pinPosition = (rq->bRequest-1) * 2 + (rq->wIndex.bytes[0]-1);
	
		if(rq->wValue.bytes[0] == PIN_HIGHZ) //turning the pin highz
		{
			PERIPHERAL_DDR &= ~_BV(pinPosition);
		}
		else if(rq->wValue.bytes[0] == PIN_LOW)
		{
			PERIPHERAL_DDR |= _BV(pinPosition);
			PERIPHERAL_PORT &= ~_BV(pinPosition);
		}
		else if(rq->wValue.bytes[0] == PIN_HIGH)
		{
			PERIPHERAL_DDR |= _BV(pinPosition);
			PERIPHERAL_PORT |= _BV(pinPosition);
		}
	
		dataBuffer[0] = (PERIPHERAL_DDR & _BV(pinPosition));
		dataBuffer[1] = (PERIPHERAL_PORT & _BV(pinPosition));
	}
	
	return 2;
}

int __attribute__((noreturn)) main(void)
{
	uchar i;
	usbInit();
    usbDeviceDisconnect();  /* enforce re-enumeration, do this while interrupts are disabled! */
    
	i = 0;
    while(--i)
	{             /* fake USB disconnect for > 250 ms */
        _delay_ms(1);
    }
	
    usbDeviceConnect();
	
	MCUCR |= _BV(PUD);
	
	sei(); //enable interrupts
	
	for(;;)
	{
        usbPoll();
    }
}