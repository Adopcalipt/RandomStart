using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace RandomStartSettings
{
    public partial class Form1 : Form
    {
        private int _lastFormSize;
        private SettingsXML YourSets = null;
        private readonly string sSettings = "" + Directory.GetCurrentDirectory() + "/RSettings.Xml";

        public class SettingsXML
        {
            public Keys MenuKey { get; set; }
            public bool Locate { get; set; }
            public bool Spawn { get; set; }
            public bool Saved { get; set; }
            public bool DisableRecord { get; set; }
            public bool KeepWeapons { get; set; }
            public bool BeltUp { get; set; }
            public bool Reincarn { get; set; }
            public bool ReCritter { get; set; }
            public bool ReSave { get; set; }
            public bool ReCurr { get; set; }
            public bool BeachPart { get; set; }
            public int Version { get; set; }
            public int LangSupport { get; set; }

            public bool BeachPed { get; set; }
            public bool Tramps { get; set; }
            public bool Highclass { get; set; }
            public bool Midclass { get; set; }
            public bool Lowclass { get; set; }
            public bool Business { get; set; }
            public bool Bodybuilder { get; set; }
            public bool GangStars { get; set; }
            public bool Epsilon { get; set; }
            public bool Jogger { get; set; }
            public bool Golfer { get; set; }
            public bool Hiker { get; set; }
            public bool Methaddict { get; set; }
            public bool Rural { get; set; }
            public bool Cyclist { get; set; }
            public bool LGBTWXYZ { get; set; }
            public bool PoolPeds { get; set; }
            public bool Workers { get; set; }
            public bool Jetski { get; set; }
            public bool BikeATV { get; set; }
            public bool Services { get; set; }
            public bool Pilot { get; set; }
            public bool Animals { get; set; }
            public bool Yankton { get; set; }
            public bool Cayo { get; set; }

            public List<int> RandStarts { get; set; }

            public List<WeaponSaver> YourWeaps { get; set; }

            public SettingsXML()
            {
                YourWeaps = new List<WeaponSaver>();
                RandStarts = new List<int>();
            }
        }
        public class WeaponSaver
        {
            public string PlayWeaps { get; set; }
            public List<string> PlayCompsList { get; set; }
            public int Ammos { get; set; }

            public WeaponSaver()
            {
                PlayCompsList = new List<string>();
            }
        }
        public SettingsXML LoadSettings(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(SettingsXML));
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (SettingsXML)xml.Deserialize(sr);
            }
        }
        public void SaveSetMain(SettingsXML config, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(SettingsXML));
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                xml.Serialize(sw, config);
            }
        }
        public List<int> BuildRandStartsList()
        {
            List<int> iSel = new List<int>();

            for (int i = 1; i < 26; i++)
                iSel.Add(i);

            return iSel;
        }
        private void LoadSetXML()
        {
            if (File.Exists(sSettings))
                YourSets = LoadSettings(sSettings);
            else
            {
                YourSets = new SettingsXML
                {
                    MenuKey = Keys.L,
                    Spawn = false,
                    Locate = true,
                    Saved = false,
                    DisableRecord = false,
                    KeepWeapons = false,
                    BeltUp = false,
                    Version = 0,
                    LangSupport = 0,
                    Reincarn = false,
                    ReCritter = true,
                    ReCurr = false,
                    ReSave = false,
                    YourWeaps = new List<WeaponSaver>(),
                    BeachPart = true,

                    BeachPed = true,
                    Tramps = true,
                    Highclass = true,
                    Midclass = true,
                    Lowclass = true,
                    Business = true,
                    Bodybuilder = true,
                    GangStars = true,
                    Epsilon = true,
                    Jogger = true,
                    Golfer = true,
                    Hiker = true,
                    Methaddict = true,
                    Rural = true,
                    Cyclist = true,
                    LGBTWXYZ = true,
                    PoolPeds = true,
                    Workers = true,
                    Jetski = true,
                    BikeATV = true,
                    Services = true,
                    Pilot = true,
                    Animals = true,
                    Yankton = true,
                    Cayo = true,
                    RandStarts = BuildRandStartsList()
                };
            }
        }
        private int GetFormArea(Size size)
        {
            return size.Height * size.Width;
        }
        private void ResizeAlize(object sender, EventArgs e)
        {
            if (GetFormArea(this.Size) > _lastFormSize + 100 || GetFormArea(this.Size) < _lastFormSize - 100)
            {
                Control control = (Control)sender;
                float scaleFactor = (float)GetFormArea(control.Size) / (float)_lastFormSize;
                ResizeFont(this.Controls, scaleFactor);
                _lastFormSize = GetFormArea(control.Size);
            }
        }
        private void ResizeFont(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls, scaleFactor);
                }
                else
                {
                    if (true)
                    {
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor);
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

            this.Resize += new EventHandler(ResizeAlize);
            _lastFormSize = GetFormArea(this.Size);
            Loadup();
        }
        private void Loadup()
        {
            LoadSetXML();
            checkBox6.Checked = YourSets.Locate;
            checkBox2.Checked = YourSets.Saved;
            checkBox3.Checked = YourSets.DisableRecord;
            checkBox4.Checked = YourSets.KeepWeapons;
            checkBox5.Checked = YourSets.BeltUp;
            checkBox1.Checked = YourSets.Spawn;
            checkBox7.Checked = YourSets.Reincarn;
            checkBox8.Checked = YourSets.ReCritter;
            checkBox9.Checked = YourSets.ReSave;
            checkBox10.Checked = YourSets.ReCurr;
            checkBox11.Checked = YourSets.BeachPart;
            checkBox12.Checked = YourSets.BeachPed;
            checkBox13.Checked = YourSets.Tramps;
            checkBox14.Checked = YourSets.Highclass;
            checkBox15.Checked = YourSets.Midclass;
            checkBox16.Checked = YourSets.Lowclass;
            checkBox17.Checked = YourSets.Business;
            checkBox18.Checked = YourSets.Bodybuilder;
            checkBox19.Checked = YourSets.GangStars;
            checkBox20.Checked = YourSets.Epsilon;
            checkBox21.Checked = YourSets.Jogger;
            checkBox22.Checked = YourSets.Golfer;
            checkBox23.Checked = YourSets.Hiker;
            checkBox24.Checked = YourSets.Methaddict;
            checkBox25.Checked = YourSets.Rural;
            checkBox26.Checked = YourSets.Cyclist;
            checkBox27.Checked = YourSets.LGBTWXYZ;
            checkBox28.Checked = YourSets.PoolPeds;
            checkBox29.Checked = YourSets.Workers;
            checkBox30.Checked = YourSets.Jetski;
            checkBox31.Checked = YourSets.BikeATV;
            checkBox32.Checked = YourSets.Services;
            checkBox33.Checked = YourSets.Pilot;
            checkBox34.Checked = YourSets.Animals;
            checkBox35.Checked = YourSets.Yankton;
            checkBox36.Checked = YourSets.Cayo;
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Locate = checkBox6.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                    YourSets.Saved = checkBox2.Checked;
                }
            }
            YourSets.Spawn = checkBox1.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                    YourSets.Spawn = checkBox1.Checked;
                }
            }
            YourSets.Saved = checkBox2.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.DisableRecord = checkBox3.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.KeepWeapons = checkBox4.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.BeltUp = checkBox5.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Reincarn = checkBox7.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                if (checkBox9.Checked)
                {
                    checkBox9.Checked = false;
                    YourSets.ReSave = checkBox9.Checked;
                }
                if (checkBox10.Checked)
                {
                    checkBox10.Checked = false;
                    YourSets.ReCurr = checkBox10.Checked;
                }
            }
            YourSets.ReCritter = checkBox8.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                    YourSets.ReCritter = checkBox8.Checked;
                }
                if (checkBox10.Checked)
                {
                    checkBox10.Checked = false;
                    YourSets.ReCurr = checkBox10.Checked;
                }
            }
            YourSets.ReSave = checkBox9.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                    YourSets.ReCritter = checkBox8.Checked;
                }
                if (checkBox9.Checked)
                {
                    checkBox9.Checked = false;
                    YourSets.ReSave = checkBox9.Checked;
                }
            }
            YourSets.ReCurr = checkBox10.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.BeachPart = checkBox11.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.BeachPed = checkBox12.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Tramps = checkBox13.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Highclass = checkBox14.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Midclass = checkBox15.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Lowclass = checkBox16.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Business = checkBox17.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Bodybuilder = checkBox18.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.GangStars = checkBox19.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Epsilon = checkBox20.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Jogger = checkBox21.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Golfer = checkBox22.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Hiker = checkBox23.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Methaddict = checkBox24.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Rural = checkBox25.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Cyclist = checkBox26.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.LGBTWXYZ = checkBox27.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.PoolPeds = checkBox28.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Workers = checkBox29.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Jetski = checkBox30.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.BikeATV = checkBox31.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Services = checkBox32.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Pilot = checkBox33.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Animals = checkBox34.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Yankton = checkBox35.Checked;
            SaveSetMain(YourSets, sSettings);
        }
        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            YourSets.Cayo = checkBox36.Checked;
            SaveSetMain(YourSets, sSettings);
        }
    }
}
