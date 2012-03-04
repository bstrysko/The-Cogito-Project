using System;

namespace CogitoProject.Communication.Electronics.Microcontroller
{
    /**
     * Creates a Picaxe with 31 IO pins and a baud rate of 9600.
     * 
     * @author Brent Strysko
     * @date 2/13/10
     */
    public class Picaxe40X2 : Picaxe
    {
        /**
         * Creates a picaxe with 31 IO pins and a baud rate of 9600.
         * 
         * @param comPort the com port for data transfer ex.) "COM1"
         */
        public Picaxe40X2(String comPort) : base(comPort, 9600, 31)
        {
        }
    }
}