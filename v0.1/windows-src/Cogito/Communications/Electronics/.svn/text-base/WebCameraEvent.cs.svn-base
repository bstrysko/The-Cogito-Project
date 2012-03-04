using System;

namespace CogitoProject.Communication.Electronics
{
    public class WebCameraEvent : System.EventArgs
    {
        private System.Drawing.Image _image;
        private ulong _frameNumber = 0;

        public WebCameraEvent()
        {
        }

        public System.Drawing.Image image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
            }
        }

        public ulong frameNumber
        {
            get
            {
                return _frameNumber;
            }

            set
            {
                _frameNumber = value;
            }
        }
    }
}
