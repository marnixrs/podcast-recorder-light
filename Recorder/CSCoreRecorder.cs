using System;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.MediaFoundation;
using CSCore.SoundOut;
using CSCore.Streams;
using CSCore.Codecs;
using CSCore;
using System.IO;
using System.Windows.Forms;

namespace Recorder
{
    class CSCoreRecorder
    {
        private WasapiCapture micCapture;
        private WasapiLoopbackCapture speakCapture;
        private WasapiOut soundout;
        private SoundInSource micSource;
        private SoundInSource speakSource;
        private MediaFoundationEncoder micWriter;
        private MediaFoundationEncoder speakWriter;
        private string micFileName, speakFileName;
        private MainWindow window;
        private bool isRecording = false;

        public CSCoreRecorder(MainWindow window) {
            this.window = window;
        }

        private void playSilence()
        {
            soundout = new WasapiOut();
            var source = CodecFactory.Instance.GetCodec("silence.wav");
            soundout.Initialize(source.Loop());
            soundout.Play();
        }

        public void startRecording(MMDevice micDevice, MMDevice speakDevice)
        {
            isRecording = true;
            window.LockUI();
            playSilence();
            makeFileNames();

            micCapture = new WasapiCapture();
            micCapture.Device = micDevice;
            micCapture.Initialize();

            speakCapture = new WasapiLoopbackCapture();
            speakCapture.Device = speakDevice;
            speakCapture.Initialize();

            micSource = new SoundInSource(micCapture);

            micWriter = MediaFoundationEncoder.CreateMP3Encoder(micSource.WaveFormat, micFileName);
            byte[] micBuffer = new byte[micSource.WaveFormat.BytesPerSecond];
            micSource.DataAvailable += (s, e) =>
            {
                int read = micSource.Read(micBuffer, 0, micBuffer.Length);
                micWriter.Write(micBuffer, 0, read);
            };

            micCapture.Start();

            speakSource = new SoundInSource(speakCapture);
            speakWriter = MediaFoundationEncoder.CreateMP3Encoder(speakSource.WaveFormat, speakFileName);
            byte[] speakBuffer = new byte[speakSource.WaveFormat.BytesPerSecond];
            speakSource.DataAvailable += (s, e) =>
            {
                int read = speakSource.Read(speakBuffer, 0, speakBuffer.Length);
                speakWriter.Write(speakBuffer, 0, read);
            };

            speakCapture.Start();
        }

        public void stopRecording()
        {
            isRecording = false;
            micCapture.Stop();
            speakCapture.Stop();
            micWriter.Dispose();
            speakWriter.Dispose();
            micCapture.Dispose();
            speakCapture.Dispose();
            soundout.Stop();
            soundout.Dispose();

            string micSize = "-", speakSize = "-";

            if (File.Exists(micFileName))
            {
                FileInfo f = new FileInfo(micFileName);
                int mbytes = (int)(f.Length / 1024 / 1024);
                micSize = mbytes.ToString();
            }
            else
            {
                MessageBox.Show("No file with name\n   " + micFileName + "\nexists.\n\nMicrophone may not have been recorded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (File.Exists(speakFileName))
            {
                FileInfo f = new FileInfo(speakFileName);
                int mbytes = (int)(f.Length / 1024 / 1024);
                speakSize = mbytes.ToString();
            }

            window.updateInfo(micFileName, micSize, speakFileName, speakSize);

            window.UnlockUI();
        }

        private void makeFileNames()
        {
            string parse = "yyyy-MM-dd_hhmmss";
            micFileName = "" + DateTime.Now.ToString(parse) + "_mic.mp3";
            speakFileName = "" + DateTime.Now.ToString(parse) + "_speak.mp3";
        }
    }
}
