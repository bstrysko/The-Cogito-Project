using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CogitoProject.Communication.Electronics
{
	public class WebCamera: System.Windows.Forms.UserControl
	{
		//private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timer1;

		private int m_TimeToCapture_milliseconds = 100;
		private int m_Width = 320;
		private int m_Height = 240;
		private int mCapHwnd;
		private ulong m_FrameNumber = 0;

		private WebCameraEvent x = new WebCameraEvent();
		private IDataObject tempObj;
		private System.Drawing.Bitmap tempImg;
		private bool bStopped = true;

		// event delegate
		public delegate void WebCamEventHandler (object source,WebCameraEvent e);
		// fired when a new image is captured
		public event WebCamEventHandler ImageCaptured; 

		#region API Declarations

		[DllImport("user32", EntryPoint="SendMessage")]
		public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

		[DllImport("avicap32.dll", EntryPoint="capCreateCaptureWindowA")]
		public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

		[DllImport("user32", EntryPoint="OpenClipboard")]
		public static extern int OpenClipboard(int hWnd);

		[DllImport("user32", EntryPoint="EmptyClipboard")]
		public static extern int EmptyClipboard();

		[DllImport("user32", EntryPoint="CloseClipboard")]
		public static extern int CloseClipboard();

		#endregion

		#region API Constants

		public const int WM_USER = 1024;

		public const int WM_CAP_CONNECT = 1034;
		public const int WM_CAP_DISCONNECT = 1035;
		public const int WM_CAP_GET_FRAME = 1084;
		public const int WM_CAP_COPY = 1054;

		public const int WM_CAP_START = WM_USER;

		public const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41;
		public const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42;
		public const int WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43;
		public const int WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44;
		public const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
		public const int WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46;
		public const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;

		#endregion

		/*
		 * If you want to allow the user to change the display size and 
		 * color format of the video capture, call:
		 * SendMessage (mCapHwnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0);
		 * You will need to requery the capture device to get the new settings
		*/


		public WebCamera(int width,int height)
		{
            this.m_Width = width;
            this.m_Height = height;
			InitializeComponent();
		}

		~WebCamera()
		{
			this.Stop();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{

				//if( components != null )
				//	components.Dispose();
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
			this.timer1 = new System.Windows.Forms.Timer();
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			this.Name = "WebCamCapture";
			this.Size = new System.Drawing.Size(342, 252);

		}

		#region Control Properties

		/// <summary>
		/// The time intervale between frame captures
		/// </summary>
        public int TimeToCapture_milliseconds
        {
            get
            { return m_TimeToCapture_milliseconds; }

            set
            { m_TimeToCapture_milliseconds = value; }
        }

		/// <summary>
		/// The sequence number to start at for the frame number. OPTIONAL
		/// </summary>
		public ulong FrameNumber
		{
			get
			{ return m_FrameNumber; }

			set
			{ m_FrameNumber = value; }
		}

		#endregion

		#region Start and Stop Capture Functions

		/// <summary>
		/// Starts the video capture
		/// </summary>
		/// <param name="FrameNumber">the frame number to start at. 
		/// Set to 0 to let the control allocate the frame number</param>
		public void Start(ulong FrameNum)
		{
			try
			{
				// for safety, call stop, just in case we are already running
				this.Stop();

				// setup a capture window
				mCapHwnd = capCreateCaptureWindowA("WebCap", 0, 0, 0, 0, m_Height, this.Handle.ToInt32(), 0);

				// connect to the capture device
				Application.DoEvents();
				SendMessage(mCapHwnd, WM_CAP_CONNECT, 0, 0);
				SendMessage(mCapHwnd, WM_CAP_SET_PREVIEW, 0, 0);

				// set the frame number
				m_FrameNumber = FrameNum;

				// set the timer information
				this.timer1.Interval = m_TimeToCapture_milliseconds;
				bStopped = false;
				this.timer1.Start();
			}

			catch (Exception)
			{ 
				this.Stop();
			}
		}

		/// <summary>
		/// Stops the video capture
		/// </summary>
		public void Stop()
		{
			try
			{
				// stop the timer
				bStopped = true;
				this.timer1.Stop();

				// disconnect from the video source
				Application.DoEvents();
				SendMessage(mCapHwnd, WM_CAP_DISCONNECT, 0, 0);
			}
			catch (Exception){}

		}

		#endregion

		#region Video Capture Code

		/// <summary>
		/// Capture the next frame from the video feed
		/// </summary>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				// pause the timer
				this.timer1.Stop();

				// get the next frame;
				SendMessage(mCapHwnd, WM_CAP_GET_FRAME, 0, 0);

				// copy the frame to the clipboard
				SendMessage(mCapHwnd, WM_CAP_COPY, 0, 0);

				// paste the frame into the event args image
				if (ImageCaptured != null)
				{
					// get from the clipboard
					tempObj = Clipboard.GetDataObject();
					tempImg = (System.Drawing.Bitmap) tempObj.GetData(System.Windows.Forms.DataFormats.Bitmap);

                    Bitmap buffer = (System.Drawing.Bitmap)tempObj.GetData(System.Windows.Forms.DataFormats.Bitmap);

                    for (int y_ = 0; y_ < buffer.Height; y_++)
                    {
                        for (int x_ = 0; x_ < buffer.Width; x_++)
                        {
                            
                        }
                    }

                        /*
                        * For some reason, the API is not resizing the video
                        * feed to the width and height provided when the video
                        * feed was started, so we must resize the image here
                        */
                        x.image = tempImg.GetThumbnailImage(m_Width, m_Height, null, System.IntPtr.Zero);
                    
                        
					// raise the event
					this.ImageCaptured(this, x);
				}		

				// restart the timer
				Application.DoEvents();
				if (! bStopped)
					this.timer1.Start();
			}

			catch (Exception)
			{ 
			}
		}

		#endregion
	}
}

