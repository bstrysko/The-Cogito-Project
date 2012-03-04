# Use the following 3 lines on Unix (uncomment the framework on Mac OS X):
USBFLAGS = -I/opt/local/include
USBLIBS = -L/opt/local/lib -lusb
EXE_SUFFIX =

NAME = main

OBJECTS = opendevice.o $(NAME).o port.o control.o systemlights.o

CC		= g++
CFLAGS	= $(CPPFLAGS) $(USBFLAGS) -O -g -Wall
LIBS	= $(USBLIBS)

PROGRAM = $(NAME)$(EXE_SUFFIX)


all: $(PROGRAM)

.c.o:
	$(CC) $(CFLAGS) -c $<

.cpp.o:
	$(CC) $(CFLAGS) -c $<

$(PROGRAM): $(OBJECTS)
	$(CC) -o $(PROGRAM) $(OBJECTS) $(LIBS)

strip: $(PROGRAM)
	strip $(PROGRAM)

clean:
	rm -f *.o $(PROGRAM)
