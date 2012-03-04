using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;


namespace CogitoProject.Graphics
{
    /**
     * The Abstract Insight Base Class is responsible for setting up all basic components 
     * of the DirectX Visual Library.  Insight then extends InsightBase to provide
     * more specific program features.
     * 
     * @author Brent Strysko
     * @date 2/11/10
     */
    public abstract class InsightBase : UserControl
    {
        /** 
        * Contains the information needed to draw to the buffer.
        */
        private Device _device;

        /**
         * The position of the DirectX frame. 
         */
        private Point _position;

        /**
         * The size of the DirectX frame.
         */
        private Size _size;

        /**
         * This constructor constructs the base device and buffer for DirectX
         * rendering.  Hardware buffering is used.
         * 
         * @param position the position of the DirectX frame
         * @param size the width and height of the DirectX frame.
         */
        protected InsightBase(Point position, Size size)
        {
            this._position = position;
            this._size = size;

            SetBounds(position.X, position.Y, size.Width, size.Height);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.UserPaint, true);
            UpdateStyles();

            try
            {
                PresentParameters parameters = new PresentParameters();
                parameters.Windowed = true;
                parameters.SwapEffect = SwapEffect.Discard;
                //parameters.PresentFlag = PresentFlag.LockableBackBuffer;
                _device = new Device(0, DeviceType.Hardware, this , CreateFlags.SoftwareVertexProcessing, parameters);
            }
            catch (DirectXException e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
        }

        /**
         * Returns the display device for use by Insight.
         * @return the display device
         */
        public Device device
        {
            get
            {
                return _device;
            }
        }

        /**
         * This method very generic.  Essentially all it does is clear the
         * device, and call render() 
         */
        public void _render()
        {
            process();

            _device.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);
            _device.BeginScene();

            render();

            _device.EndScene();
            _device.Present();
        }

        /**
         * This method is called before the necessary methods to lock the buffer are
         * called.  This is where the rendering logic is performed before being
         * written over to the graphics card.
         */
        protected abstract void process();

        /**
         * This method is defined in the Insight class and writes information to the
         * device to be displayed next render cycle.
         */
        protected abstract void render();
    }
}
