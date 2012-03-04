;Written by Brent Strysko
;For use in The Cogito Project

symbol HEADER = 0xFB
symbol ACKNOWLEDGE = 0xFC
symbol RECEIVE = 0xFD
symbol SEND = 0xFE
symbol FOOTER = 0xFF

symbol _header = b0
symbol _command = b1
symbol _device = b2
symbol _data = b3
symbol _footer = b4

symbol _temp0 = b5
symbol _temp1 = b6
symbol _temp2 = b7

high d.0
main:
	serrxd _header
	serrxd _command
	serrxd _device
	serrxd _data
	serrxd _footer
	
	debug _header
	debug _command
	debug _device
	debug _data
	debug _footer
	
	gosub checkFlags
	
	gosub checkCommand
	
	reconnect
	
	goto main


checkFlags:
	if _header = HEADER then
		if _footer = FOOTER then
			return
		endif
	endif
	
	gosub failedPacket
	goto main
	
	
failedPacket:
	sertxd (HEADER)
	sertxd (0x00)
	sertxd (0x00)
	sertxd (0x00)
	sertxd (FOOTER)
	return
	

checkCommand:
	if _command = SEND then
		gosub writeData
	else if _command = RECEIVE then
		gosub readData
	else
		gosub failedPacket
	endif
	
	return 

writeData:
	if _data = 0 then
		low _device
	else if _data = 1 then
		high _device
	;else if
	
	endif
	
	_temp0 = ACKNOWLEDGE
	_temp1 = _device
	_temp2 = _data
	gosub sendCommand
	
	return
	
readData:
	return
	
sendCommand:
	sertxd (HEADER)
	sertxd (_temp0)
	sertxd (_temp1)
	sertxd (_temp2)
	sertxd (FOOTER)
	return

;high d.0