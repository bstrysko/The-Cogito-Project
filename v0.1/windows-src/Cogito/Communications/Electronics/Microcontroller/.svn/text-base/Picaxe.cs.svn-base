using System;
using System.IO.Ports;

namespace CogitoProject.Communication.Electronics.Microcontroller
{
    /**
     * The abstract Picaxe class sets up the basic connection to the physicsl picaxe.
     * 
     * @author Brent Strysko
     * @date 2/13/10
     */
    public abstract class Picaxe
    {
        /**
         * The Serial connection from the computer to the serial Picaxe. 
         */
        private SerialPort serialPort;

        /**
         * A boolean array of whether the Picaxe's IO pin is taken by a peripheral. 
         */
        private bool[] ports;

        /**
         * Creates a connection to the Picaxe and initializes the port tracking
         * array.
         * 
         * @param comPort the com port to be used ex.) "COM1"
         * @param baudRate the rate of transfer between the Picaxe and computer
         * @param ports count of IO pins on the Picaxe
         */
        protected Picaxe(String comPort, int baudRate, byte ports)
        {
            this.ports = new bool[ports];
            serialPort = new SerialPort(comPort, baudRate, Parity.None, 8, StopBits.One);
            serialPort.Open();
        }

        /**
         * Sends the specified command to the Picaxe.
         * 
         * @param command the command number
         */
        public void sendCommand(byte command)
        {
            byte[] temp = new byte[1];
            temp[0] = command;
            serialPort.Write(temp,0,1);
        }

        /**
         * Registers the ports contained in the passed in array.
         * 
         * @param _ports an array of ports to be registered
         */
        public void registerPorts(byte[] _ports)
        {
            for (int i = 0; i < _ports.Length; i++)
            {
                if (_ports[i] >= ports.Length)
                {
                    throw new Exception("Port outside Picaxe's range : "+_ports[i]);
                }

                if (ports[_ports[i]])
                {
                    throw new Exception("Microcontroller port already registered to another device: Port" + ports[i]);
                }
                else
                {
                    ports[_ports[i]] = true;
                }
            }
        }
    }
}