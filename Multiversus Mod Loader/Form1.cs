using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using Multiversus_Mod_Loader.Properties;
using System.Threading;

using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace Multiversus_Mod_Loader
{

    public partial class Form1 : Form
    {
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
        private void LogError(string message)
        {

            string source;
            string log;
            source = "RollbarDotNetGuide";
            Console.Write(source + " error: " + message);

        }

            // dotnet moment
            private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
            Shown += new System.EventHandler(Form1_Shown);


            button7.Hide();




            
            CressPC.InitializeRPC();
            // if BackgroundColor is transparent change to black



            string dir = @"C:\CressSettings";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string mods = Application.UserAppDataPath + @"\CressMods";
            // If directory does not exist, create it
            if (!Directory.Exists(mods))
            {
                Directory.CreateDirectory(mods);
            }



            WebClient webClient = new WebClient();

            try
            {
                if (!webClient.DownloadString("https://pastebin.com/raw/XWBw7Y1m").Contains("1.0.0"))
                {
                    if (MessageBox.Show("There is a update please wait while we install", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        using (var client = new WebClient())
                        {
                            Thread.Sleep(2000);
                            Process.Start("Vresil.exe");
                            this.Close();
                            Close();
                        }
                }
            }
            catch
            {

            }


            pictureBox1.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/Vector/VectorIcon.png?raw=true";
            pictureBox2.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/Homer/HomerIcon.png?raw=true";
            pictureBox3.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/Carly/CarlyIcon.png?raw=true";
            pictureBox4.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/GorillaTag/Monkey.png?raw=true";
            pictureBox5.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/LinkV1/LinkIcon.png?raw=true";
            pictureBox6.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/HeadLessLebron/LebronIcon.png?raw=true";
            pictureBox7.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/CrunnieIconMod/CrunnieIcon.png?raw=true";
            pictureBox8.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/Homelander/Homelander.png?raw=true";
            pictureBox9.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/Optimus%20Prime/OptimusPrimeIcon.png?raw=true";
            pictureBox10.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/BlumaVelma/BlumaVelmaIcon.png?raw=true";
            pictureBox10.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/BlumaVelma/BlumaVelmaIcon.png?raw=true";
            pictureBox11.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/Batcave%20Background/CrunnieBackgroundIcon.png?raw=true";
            pictureBox12.ImageLocation = "https://github.com/Oxuu1/MultiVersus-Mods/blob/main/Kermit/KermitIcon.png?raw=true";
        }


        private async void Form1_Shown(object sender, EventArgs e)
        {

            pictureBox13.Width = Form1.ActiveForm.Width;
            pictureBox13.Height = Form1.ActiveForm.Height;
            pictureBox13.BringToFront();
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox13.Location = new Point(-7, -36);
            pictureBox13.ImageLocation = "https://c.tenor.com/CyfdVqDgO0QAAAAd/multiversus-bugs-bunny.gif";
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Parent = pictureBox13;
            label3.BringToFront();



            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            pictureBox13.Hide();
            label3.Hide();

            /*Thread.Sleep(5000);
            label3.Visible = false;
            pictureBox13.Visible = false;*/
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Vector/VectorInfo.meta");
            DialogResult result = MessageBox.Show("This Changes Shaggy Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Vector/Vector_P.pak", $"{textBox1.Text}\\Vector_P.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\Vector_P.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // listen for a error event

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This Changes SuperMan Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Homer/pakchunk99-Homer.pak", $"{textBox1.Text}\\pakchunk99-Homer.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\pakchunk99-Homer.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This Changes Velma Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Carly/Carly_P.pak", $"{textBox1.Text}\\Carly_P.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\Carly_P.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/GorillaTag/GorillaInfo.meta");
            DialogResult result = MessageBox.Show("This Changes Fin Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/GorillaTag/Gorilla_P.pak", $"{textBox1.Text}\\Gorilla_P.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\Gorilla_P.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This Changes Wonder Woman Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/LinkV1/pakchunk99-WindowsNoEditor-link_P.pak", $"{textBox1.Text}\\pakchunk99-WindowsNoEditor-link_P.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\pakchunk99-WindowsNoEditor-link_P.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/HeadLessLebron/LebronInfo.meta");
            DialogResult result = MessageBox.Show("This Changes Lebron Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/HeadLessLebron/HeadlessActionFigureLebron_P.pak", $"{textBox1.Text}\\HeadlessActionFigureLebron_P.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\HeadlessActionFigureLebron_P.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.label1.Visible = false;

            foreach (Control ctl in this.GetAllCtls(typeof(Button)))
            {
                GraphicsPath p = new GraphicsPath();
                
                p.AddEllipse(0, 0, ctl.Width - 3, ctl.Height - 3);
                ctl.Region = new Region(p);
            }



            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.ImageLocation = "https://cdn-icons-png.flaticon.com/512/25/25231.png";

            panel2.Location = new Point(-10, -3);




            label1.Visible = false;

            GitUpdate.Update();


            textBox1.Text = Properties.Settings.Default.ModsPath;
           

            if (!Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("Please Select a Folder", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (Settings.Default.CRPCON == true)
            {
                CressPC.InitializeRPC();
            }
            else if (Settings.Default.CRPCOFF == true)
            {
                CressPC.Destroy();

            }
            Settings.Default.Upgrade();






        }


        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\Steam\steamapps\common\MultiVersus\MultiVersus");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Oxuu1/MultiVersus-Mods");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String myPath = $"{textBox1.Text}\\pakchunk99-Homer.pak";
            File.Delete(myPath);
            String myPath2 = $"{textBox1.Text}\\Vector_P.pak";
            File.Delete(myPath2);
            String myPath3 = $"{textBox1.Text}\\Carly_P.pak";
            File.Delete(myPath3);
            String myPath4 = $"{textBox1.Text}\\Gorilla_P.pak";
            File.Delete(myPath4);
            String myPath5 = $"{textBox1.Text}\\HeadlessActionFigureLebron_P.pak";
            File.Delete(myPath5);
            String myPath6 = $"{textBox1.Text}\\pakchunk99-WindowsNoEditor-link_Pak";
            File.Delete(myPath6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String myPath = $"{textBox1.Text}\\pakchunk99-Homer.pak";
            File.Delete(myPath);
            String myPath2 = $"{textBox1.Text}\\Vector_P.pak";
            File.Delete(myPath2);
            String myPath3 = $"{textBox1.Text}\\Carly_P.pak";
            File.Delete(myPath3);
            String myPath4 = $"{textBox1.Text}\\Gorilla_P.pak";
            File.Delete(myPath4);
            String myPath5 = $"{textBox1.Text}\\HeadlessActionFigureLebron_P.pak";
            File.Delete(myPath5);
            String myPath6 = $"{textBox1.Text}\\Megatron_PD.pak";
            File.Delete(myPath6);
            String myPath11 = $"{textBox1.Text}\\Megatron_P.pak";
            File.Delete(myPath11);
            String myPath9 = $"{textBox1.Text}\\pakchunk99-WindowsNoEditor-link_Pak";
            File.Delete(myPath9);
            String myPath7 = $"{textBox1.Text}\\pakchunkAndrew-WindowsNoEditor.pak";
            File.Delete(myPath7);
            String myPath8 = $"{textBox1.Text}\\Homelander_P.pak";
            File.Delete(myPath8);
            String myPath10 = $"{textBox1.Text}\\Velma_edit_test.pak";
            File.Delete(myPath10);
            String myPath12 = $"{textBox1.Text}\\Kermit_P.pak";
            File.Delete(myPath12);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/CrunnieIconMod/CrunnieIModInfo.meta");
            DialogResult result = MessageBox.Show("This Changes Default Icon Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/CrunnieIconMod/pakchunkAndrew-WindowsNoEditor.pak", $"{textBox1.Text}\\pakchunkAndrew-WindowsNoEditor.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\pakchunkAndrew-WindowsNoEditor.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Homelander/HomeLanderInfo.meta");

            DialogResult result = MessageBox.Show("This Changes SuperMan Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Homelander/Homelander_P.pak", $"{textBox1.Text}\\Homelander_P.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\Homelander_P.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Optimus%20Prime/MegaTronInfo.meta");

            DialogResult result = MessageBox.Show("This Changes Iron Giant Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Optimus%20Prime/Megatron_PD.pak", $"{textBox1.Text}\\Megatron_PD.pak");
                    MessageBox.Show("Change complete Mod", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\Megatron_PD.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openFolder = new CommonOpenFileDialog();
            openFolder.AllowNonFileSystemItems = true;
            openFolder.Multiselect = true;
            openFolder.IsFolderPicker = true;
            openFolder.Title = "Select your ~mods folder.";

            if (openFolder.ShowDialog() != CommonFileDialogResult.Ok)
            {
                MessageBox.Show("No Folder selected! make sure it is the ~mods folder!");
                return;
            }


            // get path of selected folder
            var path = openFolder.FileName;
            textBox1.Text = path;

            if (!path.EndsWith("~mods"))
            {
                MessageBox.Show("This folder is not the ~mods folder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                Properties.Settings.Default.ModsPath = $"{path}";
                Properties.Settings.Default.Save();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/BlumaVelma/BlumaInfo.meta");

            DialogResult result = MessageBox.Show("This Changes Velma Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/BlumaVelma/Velma_edit_test.pak", $"{textBox1.Text}\\Velma_edit_test.pak");
                    MessageBox.Show("Change complete Mod ", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\Velma_edit_test.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Batcave%20Background/CrunnieBackgroundInfo.meta");
            DialogResult result = MessageBox.Show("This Changes Default Background Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Batcave%20Background/pakchunkOldBG-WindowsNoEditor.pak", $"{textBox1.Text}\\pakchunkOldBG-WindowsNoEditor.pak");
                    MessageBox.Show("Change complete Mod  ", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\pakchunkOldBG-WindowsNoEditor.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {



        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CressPC.client.ClearPresence();
            Settings.Default.CRPCOFF = true;
            Settings.Default.CRPCON = false;
            Settings.Default.Save();
            Settings.Default.Reload();
            Thread.Sleep(4000);
            button6.Hide();
            button7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            CressPC.InitializeRPC();
            Settings.Default.CRPCON = true;
            Settings.Default.CRPCOFF = false;
            Settings.Default.Save();
            Settings.Default.Reload();
            Thread.Sleep(4000);
            button6.Show();
            button7.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            label2.Text = new WebClient().DownloadString("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Kermit/KermitInfo.meta ");
            DialogResult result = MessageBox.Show("This Changes Default Background Do you want Change", "Github", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/Oxuu1/MultiVersus-Mods/raw/main/Kermit/Kermit_P.pak", $"{textBox1.Text}\\Kermit_P.pak");
                    MessageBox.Show("Change complete Mod  ", "Github", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                String myPath = $"{textBox1.Text}\\Kermit_P.pak";
                File.Delete(myPath);
                MessageBox.Show("Changes not Made", "Github", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            GitUpdate.Update();


        }


        private void pictureBox13_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            OpenUrl("https://github.com/CressIndustries/CressMods");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var s = $@"{textBox1.Text}";
            var r = s.Substring(s.IndexOf(@"\") - 2);
            MessageBox.Show(r);

            string exe = r + @"\Binaries\Win64\MultiVersus-Win64-Shipping.exe";

            try
            {
                Process.Start(exe);
            } catch
            {
                MessageBox.Show("Could not Start! Please make sure you have selected a folder!");
            }
            



            // go back 2 exe 




            /*Process.Start(textBox1.Text + @"");*/
        }
    }

    public static class ControlExtensions
    {
        public static IEnumerable<Control> GetAllCtls(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllCtls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }

}