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
        TaakBalkInstellingen taakBalkInstellingen;
        public InstellingenPanel()
        {
            InitializeComponent();
            monitorInstellingen = new MonitorInstellingen(this.Handle);
            initializeBrightnessTrackbar();
            geluidsInstellingen = new GeluidsInstellingen();
            initializeSoundTrackbar();
            batterijInstellingen = new BatterijInstellingen();
            initializeBatterijGroupBox();
            taakBalkInstellingen = new TaakBalkInstellingen();
            initializeTaakBalkGroupBox();
            initializeTaakBalkBox();

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
        private void BatteryButtonPress(object sender, System.EventArgs e)
        {
            batterijInstellingen.changeBatterySettingsState();
        }
        //Taakbalk
        private void initializeTaakBalkGroupBox()
        {
           
            if (taakBalkInstellingen.isAutoHide())
            {
                this.AutoVerbergen.Checked = true;

            }
            else
            {
                this.NietVerbergen.Checked = true;
            }
            this.AutoVerbergen.CheckedChanged += new EventHandler(TaakbalkButtonPress);
        }
        private void TaakbalkButtonPress(object sender, System.EventArgs e)
        {
            Debug.WriteLine("this.AutoVerbergen.Checked: " + this.AutoVerbergen.Checked);
            taakBalkInstellingen.setAutoHide(this.AutoVerbergen.Checked);
        }
        //taakbalk positie
        private void initializeTaakBalkBox()
        {
            switch (taakBalkInstellingen.GetTaskBarLocation())
            {
                case TaakBalkInstellingen.TOP:
                    this.taakBalkBoven.Checked = true;
                    break;
                case TaakBalkInstellingen.RIGHT:
                    this.taakBalkRechts.Checked = true;
                    break;
                case TaakBalkInstellingen.BOTTOM:
                    this.taakBalkBeneden.Checked = true;
                    break;
                case TaakBalkInstellingen.LEFT:
                    this.taakBalkLinks.Checked = true;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;

            }

            this.taakBalkBoven.Click += new EventHandler(PositieTaakbalkButtonPress);
            this.taakBalkRechts.Click += new EventHandler(PositieTaakbalkButtonPress);
            this.taakBalkLinks.Click += new EventHandler(PositieTaakbalkButtonPress);
            this.taakBalkBeneden.Click += new EventHandler(PositieTaakbalkButtonPress);
        }

        private void PositieTaakbalkButtonPress(object sender, System.EventArgs e)
        {
            
           taakBalkInstellingen.setPositie((String)((RadioButton)sender).Tag);
                   
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
                //beide TaakBalk
                if (taakBalkInstellingen.isAutoHide())
                {
                    this.AutoVerbergen.Checked = true;
                } else
                {
                    this.NietVerbergen.Checked = true;
                }
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