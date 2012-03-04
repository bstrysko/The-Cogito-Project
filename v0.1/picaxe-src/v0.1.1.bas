;Written by Brent Strysko
;For use in The Cogito Project

;where the serial command is stored for processing
symbol _buffer = b0

;if 1 then when returning from strobe mode the command should
;not be checked again
symbol strobeFlag = b1

; light 1 pin
symbol light1 = d.0

;light 2 pin
symbol light2 = d.1

symbol remote = d.2

symbol remoteLight_h = d.3

symbol remoteLight_l = c.4

;sets strobe mode to off
start:
	high light1
	high light2
	strobeFlag = 0

main:
	if strobeFlag = 0 then
		serrxd _buffer
	endif
	
	strobeFlag = 0
	
	if _buffer = 0 then
		reset
	else if _buffer = 1 then
		low light1
		low light2
	else if _buffer = 2 then
		high light1
		high light2
	else if _buffer = 3 then
		gosub strobe
		
	else if _buffer = 4 then
		high remote
		pause 500
		low remote
	endif

	reconnect
	goto main

	
strobe:
	high light1
	low light2
			
	pause 120
			
	low light1
	high light2
			
	strobeFlag = 1
			
	serrxd[120,strobe],_buffer
		
	reconnect
	strobeFlag = 1
	return
