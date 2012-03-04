#include <avr/interrupt.h>
#include <avr/io.h>
#include <util/delay.h>

volatile unsigned char command;

#define CMD_RESET					0x01

#define CMD_BLOCKUNITRELAY0_OFF		0x41
#define CMD_BLOCKUNITRELAY0_ON		0x42
 
#define CMD_BLOCKUNITRELAY1_OFF		0x43
#define CMD_BLOCKUNITRELAY1_ON		0x44

#define CMD_UNITRELAY0_OFF			0x45
#define CMD_UNITRELAY0_ON			0x46
#define CMD_UNITRELAY1_OFF			0x47
#define CMD_UNITRELAY1_ON			0x48

#define CMD_SLIGHT0_OFF				0x49
#define CMD_SLIGHT0_ON				0x50
#define CMD_SLIGHT1_OFF				0x51
#define CMD_SLIGHT1_ON				0x52

void delay(char ds)
{
	char counter = 0;
	
	while(counter < (ds*10))
	{
		_delay_ms(10);
		counter++;
	}
}

void init_I2C(char address)
{
	TWAR = (address << 1) | (1 << TWGCE);
	TWCR = (1 << TWEA) | (1 << TWEN) | (1 << TWIE);
}

ISR(TWI_vect)
{
	command = TWDR;
	TWCR |= (1 << TWINT) | (1 << TWEA);
}

void init_devices()
{	
	MCUCR = (1 << PUD);
	DDRA = (1 << DDA1) | (1 << DDA3) | (1 << DDA4) | (1 << DDA5) | (1 << DDA6) | (1 << DDA7);
}

int main(void)
{	
	char temp = 0;
	
	init_I2C(0x01);
	init_devices();
	
	sei();
	
	for(;;)
	{
		switch (command) 
		{
			case CMD_RESET:
			{
				//reset microcontroller
				break;
			}
			case CMD_BLOCKUNITRELAY0_OFF:
			{
				temp = 0;
				PORTA &= ~(1 << PA0); //since PUD is set we just need to switch DDRA to go from low to HIGH-Z
				
				while(temp < 10) //on and off 5 times in 5 sec
				{
					DDRA ^= (1 << DDA0); 
					delay(5);
					temp++;
				}
				
				DDRA &= ~(1 << DDA0); //make port output again
				PORTA &= ~((1 << PA0) | (1 << PA1)); //turn off relay and led
				
				break;
			}
			case CMD_BLOCKUNITRELAY0_ON:
			{
				temp = 0;
				DDRA |= (1 << DDA0);
				PORTA |= (1 << PA0); //since PUD is set we just need to switch DDRA to go from high to HIGH-Z
				
				while(temp < 10) //on and off 5 times in 5 sec
				{
					DDRA ^= (1 << DDA0); 
					delay(5);
					temp++;
				}
				
				PORTA |= (1 << PA0) | (1 << PA1); //turn on relay and green led
				
				break;
			}
			case CMD_BLOCKUNITRELAY1_OFF:
			{
				temp = 0;
				PORTA &= ~(1 << PA2); //since PUD is set we just need to switch DDRA to go from low to HIGH-Z
				
				while(temp < 10) //on and off 5 times in 5 sec
				{
					DDRA ^= (1 << DDA2); 
					delay(5);
					temp++;
				}
				
				DDRA &= ~(1 << DDA2); //make port output again
				PORTA &= ~((1 << PA2) | (1 << PA3)); //turn off relay and led
				
				break;
			}
			case CMD_BLOCKUNITRELAY1_ON:
			{
				temp = 0;
				DDRA |= (1 << DDA2);
				PORTA |= (1 << PA2); //since PUD is set we just need to switch DDRA to go from high to HIGH-Z
				
				while(temp < 10) //on and off 5 times in 5 sec
				{
					DDRA ^= (1 << DDA2); 
					delay(5);
					temp++;
				}
				
				DDRA |= (1 << DDA2); //make port output again
				PORTA |= (1 << PA2) | (1 << PA3); //turn on relay and green led
				
				break;
			}
			case CMD_UNITRELAY0_OFF:
			{
				PORTA &= ~(1 << PA4); 
				break;
			}
			case CMD_UNITRELAY0_ON:
			{
				PORTA |= (1 << PA4); 
				break;
			}
			case CMD_UNITRELAY1_OFF	:
			{
				PORTA &= ~(1 << PA5); 
				break;
			}
			case CMD_UNITRELAY1_ON:
			{
				PORTA |= (1 << PA5); 
				break;
			}
			case CMD_SLIGHT0_OFF:
			{
				PORTA &= ~(1 << PA6);
				break;
			}
			case CMD_SLIGHT0_ON:
			{
				PORTA &= ~(1 << PA7);
				PORTA |= (1 << PA6);
				break;
			}
			case CMD_SLIGHT1_OFF:	
			{
				PORTA &= ~(1 << PA7);
				break;
			}
			case CMD_SLIGHT1_ON:
			{
				PORTA &= ~(1 << PA6);
				PORTA |= (1 << PA7);
				break;
			}
		}
	}
}