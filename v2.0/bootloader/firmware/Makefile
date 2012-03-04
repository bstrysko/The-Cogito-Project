# Name: Makefile
# Project: bootloadHID
# Author: Christian Starkjohann
# Creation Date: 2007-03-19
# Tabsize: 4
# Copyright: (c) 2007 by OBJECTIVE DEVELOPMENT Software GmbH
# License: GNU GPL v2 (see License.txt)
# This Revision: $Id: Makefile 788 2010-05-30 20:54:41Z cs $

DEVICE = atmega88
BOOTLOADER_ADDRESS = 0x1800
F_CPU = 16000000
FUSEH = 0xD7
FUSEL = 0xF7

AVRDUDE = avrdude -c avrispmkII -P usb -p atmega88 -F

LDFLAGS += -Wl,--relax,--gc-sections -Wl,--section-start=.text=$(BOOTLOADER_ADDRESS)

# Omit -fno-* options when using gcc 3, it does not support them.
COMPILE = avr-gcc -Wall -Os -fno-move-loop-invariants -fno-tree-scev-cprop -fno-inline-small-functions -Iusbdrv -I. -mmcu=$(DEVICE) -DF_CPU=$(F_CPU) -DDEBUG_LEVEL=0
# NEVER compile the final product with debugging! Any debug output will
# distort timing so that the specs can't be met.

OBJECTS =  usbdrv/usbdrvasm.o usbdrv/oddebug.o main.o


# symbolic targets:
all:	main.hex

.c.o:
	$(COMPILE) -c $< -o $@

.S.o:
	$(COMPILE) -x assembler-with-cpp -c $< -o $@
# "-x assembler-with-cpp" should not be necessary since this is the default
# file type for the .S (with capital S) extension. However, upper case
# characters are not always preserved on Windows. To ensure WinAVR
# compatibility define the file type manually.

.c.s:
	$(COMPILE) -S $< -o $@

flash:	all
	$(AVRDUDE) -U flash:w:main.hex:i

readflash:
	$(AVRDUDE) -U flash:r:read.hex:i

fuse:
	$(AVRDUDE) -U hfuse:w:$(FUSEH):m -U lfuse:w:$(FUSEL):m -U efuse:w:0xF8:m	

lock:
	$(AVRDUDE) -U lock:w:0x2f:m

read_fuses:
	$(UISP) --rd_fuses

clean:
	rm -f main.hex main.bin *.o usbdrv/*.o main.s usbdrv/oddebug.s usbdrv/usbdrv.s

# file targets:
main.bin:	$(OBJECTS)
	$(COMPILE) -o main.bin $(OBJECTS) $(LDFLAGS)

main.hex:	main.bin
	rm -f main.hex main.eep.hex
	avr-objcopy -j .text -j .data -O ihex main.bin main.hex
	avr-size main.hex

disasm:	main.bin
	avr-objdump -d main.bin

cpp:
	$(COMPILE) -E main.c
