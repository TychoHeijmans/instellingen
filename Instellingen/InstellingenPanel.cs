using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Instellingen
{

    public partial class InstellingenPanel : Form
    {
        Timer controlsUpdateTimer;
        MonitorInstellingen monitorInstellingen;
        GeluidsInstellingen geluidsInstellingen;
        BatterijInstellingen batterijInstellingen;
        public InstellingenPanel()
        {
            InitializeComponent();
            monitorInstellingen = new MonitorInstellingen(this.Handle);
            initializeBrightnessTrackbar();
            geluidsInstellingen = new GeluidsInstellingen();
            initializeSoundTrackbar();
            batterijInstellingen = new BatterijInstellingen();
            initializeBatterijGroupBox();

            StartTimerControlsUpdate();

        }
        // Brightness
        private void initializeBrightnessTrackbar()
        {
            this.trackBrightness.ValueChanged += new System.EventHandler(TrackBar1_ValueChanged);
            this.Controls.Add(this.trackBrightness);
            this.trackBrightness.Value = getTrackbarBrightnessValue();
        }
        private void TrackBar1_ValueChanged(object sender, System.EventArgs e)
        {
            int trackbarValue = this.trackBrightness.Value;
            int brightnessPercentage = (int)Math.Round(trackbarValue * 100.0 / this.trackBrightness.Maximum);

            monitorInstellingen.setBrightness(brightnessPercentage);
        }
        // Sound
        private void initializeSoundTrackbar()
        {
            this.trackSound.ValueChanged += new System.EventHandler(trackSound_ValueChanged);
            this.Controls.Add(this.trackSound);
            this.trackSound.Value = getTrackbarSoundValue();
        }

        private void trackSound_ValueChanged(object sender, System.EventArgs e)
        {
            int trackbarValue = this.trackSound.Value;
            int soundPercentage = (int)Math.Round(trackbarValue * 100.0 / this.trackSound.Maximum);

            geluidsInstellingen.setVolume(soundPercentage);
        }
        //Battery
        private void initializeBatterijGroupBox()
        {

        }
        //plaseholder
        private void BatteryButtonPress(object sender, System.EventArgs e)
        {
            batterijInstellingen.changeBatterySettingsState();
        }




        public void StartTimerControlsUpdate()
        {
            controlsUpdateTimer = new Timer(1000);
            controlsUpdateTimer.Elapsed += new ElapsedEventHandler(controlsUpdateTimerTriggered);
            controlsUpdateTimer.Enabled = true;
        }
        void controlsUpdateTimerTriggered(object sender, ElapsedEventArgs e)
        {
            this.trackBrightness.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                this.trackBrightness.Value = getTrackbarBrightnessValue();
                this.trackSound.Value = getTrackbarSoundValue();
            });
        }

        private int getTrackbarBrightnessValue()
        {
            return (int)Math.Round((double)monitorInstellingen.getBrightnessPercentage() / this.trackBrightness.Maximum);
        }
        private int getTrackbarSoundValue()
        {
            return (int)Math.Round((double)geluidsInstellingen.getVolume() / this.trackSound.Maximum);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}