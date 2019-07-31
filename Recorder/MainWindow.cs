using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;

namespace Recorder
{
    public partial class MainWindow : Form
    {

        private MMDevice selectedMicDevice;
        private MMDevice selectedSpeakDevice;
        private MMDevice[] micDevices;
        private MMDevice[] speakDevices;
        private CSCoreRecorder recorder;
        private int seconds = 0, minutes = 0, hours = 0;
        private Timer timer;
        private bool isRecording;

        public MainWindow()
        {
            InitializeComponent();
            RefreshDevices();
            isRecording = false;
            recorder = new CSCoreRecorder(this);
        }

        private void RefreshDevices()
        {
            btn_start.Enabled = false;
            cb_micDevices.Items.Clear();
            cb_speakDevices.Items.Clear();

            micDevices = new MMDevice[0];
            speakDevices = new MMDevice[0];

            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDeviceCollection micCollection = enumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active);
            if (micCollection.Count > 0)
            {
                micDevices = new MMDevice[micCollection.Count];
                int i = 0;
                foreach (MMDevice device in micCollection)
                {
                    micDevices[i] = device;
                    cb_micDevices.Items.Insert(i, device.FriendlyName);
                    i++;
                }
                selectedMicDevice = micDevices[0];
                cb_micDevices.SelectedIndex = 0;
            }


            enumerator = new MMDeviceEnumerator();
            MMDeviceCollection speakCollection = enumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);
            if (speakCollection.Count > 0)
            {
                speakDevices = new MMDevice[speakCollection.Count];
                int i = 0;
                foreach (MMDevice device in speakCollection)
                {
                    speakDevices[i] = device;
                    cb_speakDevices.Items.Insert(i, device.FriendlyName);
                    i++;
                }
                selectedSpeakDevice = speakDevices[0];
                cb_speakDevices.SelectedIndex = 0;
            }

            if (micDevices.Length > 0 && speakDevices.Length > 0)
            {
                if (selectedMicDevice != null && selectedSpeakDevice != null)
                    btn_start.Enabled = true;
            }

        }

        public void ResetTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            hours = 0;
            minutes = 0;
            seconds = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;
                if (minutes >= 60)
                {
                    minutes = 0;
                    hours += 1;
                }
            }
            string time = hours.ToString() + ":";
            if (minutes >= 10)
            {
                time += minutes.ToString() + ":";
            }
            else
            {
                time += "0" + minutes.ToString() + ":";
            }
            if (seconds >= 10)
            {
                time += seconds.ToString();
            }
            else
            {
                time += "0" + seconds.ToString();
            }

            lbl_time.Text = time;
        }

        public void updateInfo(string micFileName, string micSize, string speakFileName, string speakSize) {
            lbl_lastRec.Text = "Last recorded: " + micFileName + " (" + micSize + " MB), " + speakFileName + " (" + speakSize + " MB)";
        }

        public void LockUI()
        {
            btn_refresh.Enabled = false;
            btn_start.Enabled = false;
            cb_micDevices.Enabled = false;
            cb_speakDevices.Enabled = false;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 10;

        }

        public void UnlockUI() {
            btn_refresh.Enabled = true;
            btn_start.Enabled = true;
            cb_micDevices.Enabled = true;
            cb_speakDevices.Enabled = true;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 0;
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            selectedMicDevice = micDevices[cb_micDevices.SelectedIndex];
            selectedSpeakDevice = speakDevices[cb_speakDevices.SelectedIndex];
            recorder.startRecording(selectedMicDevice,selectedSpeakDevice);
            ResetTimer();
            lbl_lastRec.Text = "Recording";
            timer.Start();
            isRecording = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRecording)
            {
                recorder.stopRecording();
                UnlockUI();
            }
        }

        private void Btn_stop_Click(object sender, EventArgs e)
        {
            if (isRecording)
            { 
                recorder.stopRecording();
                timer.Stop();
                isRecording = false;
            }
        }

        private void Btn_showfiles_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Directory.GetCurrentDirectory());
        }
    }
}
