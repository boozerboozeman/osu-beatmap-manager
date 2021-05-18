using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace osu_beatmap_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public bool detectBinary()
        {
            string directory = @"C:\Users\" + Environment.UserName + "\\AppData\\Local\\osu!\\osu!.exe";
            
            if (File.Exists(directory)){
                return true;
            }
            else {
                return false;
            }

        }

        public int findBeatmaps(string directory)
        {
            string[] files = Directory.GetFileSystemEntries(directory, "*");
            return files.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (detectBinary()){

            
                label1.Text += "Detected";
                label2.Text += findBeatmaps( @"C:\Users\" + Environment.UserName + "\\AppData\\Local\\osu!\\Songs\\").ToString();
            }
            else { 
                label1.Text += "Couldn't detect your install of osu!.";
                button1.Enabled = false;
            }
        }

        public void backupMaps(string[] maps)
        {

            for(int i = 0; i < maps.Length; i++){
                ZipFile.CreateFromDirectory(maps[i], maps[i] + ".osz");

                int actualValue = i + 1;
                label3.Text = "Backing up beatmap " + actualValue.ToString() + " out of " + maps.Length.ToString();
                
            }
            MessageBox.Show("Your beatmaps have been restored to their original state at:" + " C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\osu!\\Songs\\");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFileSystemEntries(@"C:\Users\" + Environment.UserName + "\\AppData\\Local\\osu!\\Songs\\", "*");
            backupMaps(files);
        }
    }
}
