namespace MY_WINDOWS_APP
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private Microsoft.Expression.Encoder.ScreenCapture.ScreenCaptureJob ScreenCaptureJob { get; set; }

		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		private static extern int GetDeviceCaps(System.IntPtr hdc, int nIndex);

		private enum DeviceCap
		{
			VERTRES = 10,
			DESKTOPVERTRES = 117,

			// http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
		}

		private static float GetScreenScalingFactor()
		{
			System.Drawing.Graphics g =
				System.Drawing.Graphics.FromHwnd(System.IntPtr.Zero);

			System.IntPtr desktop = g.GetHdc();

			int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
			int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

			float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

			return ScreenScalingFactor; // 1.25 = 125%
		}

		public float ScreenScalingFactor { get; set; }

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			ScreenScalingFactor =
				GetScreenScalingFactor();

			stopButton.Enabled = false;
		}

		private void InitializeScreenCaptureJob()
		{
			// **************************************************
			System.Windows.Forms.Screen screen =
				System.Windows.Forms.Screen.AllScreens[0];

			int width = (int)(screen.Bounds.Width * ScreenScalingFactor);
			int height = (int)(screen.Bounds.Height * ScreenScalingFactor);

			System.Drawing.Rectangle captureRectangle =
				new System.Drawing.Rectangle(x: 0, y: 0, width: width, height: height);
			// **************************************************

			ScreenCaptureJob =
				new Microsoft.Expression.Encoder.ScreenCapture.ScreenCaptureJob();

			// **************************************************
			var audioDeviceSources =
				Microsoft.Expression.Encoder.Devices.EncoderDevices
				.FindDevices(Microsoft.Expression.Encoder.Devices.EncoderDeviceType.Audio);

			foreach (var currentAudioDeviceSource in audioDeviceSources)
			{
				string message =
					$"Name: { currentAudioDeviceSource.Name }\r\nCategory: { currentAudioDeviceSource.Category }\r\n Device Path: { currentAudioDeviceSource.DevicePath }";

				//System.Windows.Forms.MessageBox.Show(message);

				if (string.Compare(currentAudioDeviceSource.Category.ToString(), "Capture", ignoreCase: true) == 0)
				{
					ScreenCaptureJob.AddAudioDeviceSource(source: currentAudioDeviceSource);
				}
			}
			// **************************************************

			// Default Value: [false]
			ScreenCaptureJob.CaptureFollowCursor = false;

			// Default Value: [false]
			ScreenCaptureJob.CaptureLargeMouseCursor = false;

			// Default Value: [true]
			ScreenCaptureJob.CaptureLayeredWindow = true;

			// Default Value: [true]
			ScreenCaptureJob.CaptureMouseCursor = true;

			ScreenCaptureJob.CaptureRectangle = captureRectangle;

			System.TimeSpan maxDuration =
				new System.TimeSpan(hours: 2, minutes: 0, seconds: 0);

			// Default Value: [00:00:00] - Seconds
			//screenCaptureJob.Duration = maxDuration;

			ScreenCaptureJob.OutputError +=
				ScreenCaptureJob_OutputError;

			//screenCaptureJob.OutputPath = ""; // Default: [""]

			string pathName =
				$"D:\\_TEMP\\CAPTURE_{ System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") }.mp4";

			ScreenCaptureJob.OutputScreenCaptureFileName = pathName; // Default: [null]

			// Default Value: [192]
			Microsoft.Expression.Encoder.Profiles.Bitrate
				audioBitrate = new Microsoft.Expression.Encoder.Profiles.ConstantBitrate(bitrate: 192);

			// Default Value: [30000]
			Microsoft.Expression.Encoder.Profiles.Bitrate
				videoBitrate = new Microsoft.Expression.Encoder.Profiles.ConstantBitrate(bitrate: 30000);

			ScreenCaptureJob.ScreenCaptureAudioProfile.Bitrate = audioBitrate;

			// Default Value: [16]
			ScreenCaptureJob.ScreenCaptureAudioProfile.BitsPerSample = 16;

			// Default Value: [2]
			ScreenCaptureJob.ScreenCaptureAudioProfile.Channels = 2;

			// Default Value: [Wma]
			ScreenCaptureJob.ScreenCaptureAudioProfile.Codec =
				Microsoft.Expression.Encoder.Profiles.AudioCodec.Wma;

			bool isValid =
				ScreenCaptureJob.ScreenCaptureAudioProfile.IsValid;

			// Default: [48000]
			ScreenCaptureJob.ScreenCaptureAudioProfile.SamplesPerSecond = 48000;

			ScreenCaptureJob.ScreenCaptureCommandFinished +=
				ScreenCaptureJob_ScreenCaptureCommandFinished;

			string pathNameTemp =
				ScreenCaptureJob.ScreenCaptureFileName;

			ScreenCaptureJob.ScreenCaptureFinished +=
				ScreenCaptureJob_ScreenCaptureFinished;

			ScreenCaptureJob.ScreenCaptureStart +=
				ScreenCaptureJob_ScreenCaptureStart;

			// Default Value: []
			//screenCaptureJob.ScreenCaptureVideoProfile.AspectRatio = null;

			// Default Value: [true]
			ScreenCaptureJob.ScreenCaptureVideoProfile.AutoFit = true;

			ScreenCaptureJob.ScreenCaptureVideoProfile.Bitrate = videoBitrate;

			var currentVideoCodec =
				ScreenCaptureJob.ScreenCaptureVideoProfile.Codec;

			// Default Value: [false]
			ScreenCaptureJob.ScreenCaptureVideoProfile.Force16Pixels = true;

			// Default Value: [15]
			ScreenCaptureJob.ScreenCaptureVideoProfile.FrameRate = 15;

			// Default Value: [00:00:06] (Seconds)
			System.TimeSpan keyFrameDistance =
				new System.TimeSpan(hours: 0, minutes: 0, seconds: 6);

			ScreenCaptureJob.ScreenCaptureVideoProfile.KeyFrameDistance = keyFrameDistance;

			// Default Value: [0]
			ScreenCaptureJob.ScreenCaptureVideoProfile.NumberOfEncoderThreads = 0;

			// Default Value: [95]
			ScreenCaptureJob.ScreenCaptureVideoProfile.Quality = 95;

			// Default Value: [true]
			ScreenCaptureJob.ScreenCaptureVideoProfile.SeparateFilesPerStream = true;

			//System.Drawing.Size size =
			//	new System.Drawing.Size(width: screen.Bounds.Width, height: screen.Bounds.Height);

			System.Drawing.Size size =
				new System.Drawing.Size(width: 320, height: 240);

			ScreenCaptureJob.ScreenCaptureVideoProfile.Size = size;

			// Default Value: [false]
			ScreenCaptureJob.ScreenCaptureVideoProfile.SmoothStreaming = false;

			// Default Value: [false]
			ScreenCaptureJob.ShowCountdown = true;

			// Default Value: [true]
			ScreenCaptureJob.ShowFlashingBoundary = false;

			//screenCaptureJob.VideoDeviceSource

			ScreenCaptureJob.WebcamError +=
				ScreenCaptureJob_WebcamError;

			//ScreenCaptureJob.WebcamFileName
			//ScreenCaptureJob.WebcamVideoProfile
		}

		private void ScreenCaptureJob_WebcamError(object sender, Microsoft.Expression.Encoder.ScreenCapture.WebcamErrorEventArgs e)
		{
		}

		private void ScreenCaptureJob_ScreenCaptureStart(object sender, Microsoft.Expression.Encoder.ScreenCapture.ScreenCaptureEventArgs e)
		{
		}

		private void ScreenCaptureJob_ScreenCaptureFinished(object sender, Microsoft.Expression.Encoder.ScreenCapture.ScreenCaptureEventArgs e)
		{
		}

		private void ScreenCaptureJob_ScreenCaptureCommandFinished(object sender, Microsoft.Expression.Encoder.ScreenCapture.ScreenCaptureCommandFinishedEventArgs e)
		{
		}

		private void ScreenCaptureJob_OutputError
			(object sender, Microsoft.Expression.Encoder.ScreenCapture.OutputErrorEventArgs e)
		{
			System.Windows.Forms.MessageBox.Show(e.ErrorCode.ToString());
		}

		private void StartButton_Click(object sender, System.EventArgs e)
		{
			stopButton.Enabled = true;
			startButton.Enabled = false;

			InitializeScreenCaptureJob();

			ScreenCaptureJob.Start();
		}

		private void StopButton_Click(object sender, System.EventArgs e)
		{
			stopButton.Enabled = false;
			startButton.Enabled = true;

			ScreenCaptureJob.Stop();

			ScreenCaptureJob.Dispose();
			ScreenCaptureJob = null;
		}
	}
}
