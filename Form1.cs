using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.CodeDom.Compiler;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using StormLauncher.Utils;
using System.Reflection;
using StormLauncher.files;

namespace StormLauncher
{
    public partial class Form1 : Form
    {
        private string exchange = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.exchange = new RestClient("https://e01a4dfd-fc0a-4703-a22a-cd2bc83bfaf1.id.repl.co/").Execute(new RestRequest("/exchange?code=" + this.AuthCode.Text)).Content;
            if (this.exchange.ToString() == "[]")
            {
                int num = (int)MessageBox.Show("The authorization code you supplied was invalid, please try again with a valid code!");
            }
            else
            {
                MessageBox.Show("Successfully Logged in to Storm! You can launch now!");
                CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
                commonOpenFileDialog.Title = "Please select the path you want to use";
                commonOpenFileDialog.IsFolderPicker = true;
                commonOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                commonOpenFileDialog.AddToMostRecentlyUsedList = false;
                commonOpenFileDialog.AllowNonFileSystemItems = false;
                commonOpenFileDialog.DefaultDirectory = "Desktop";
                commonOpenFileDialog.EnsureFileExists = true;
                commonOpenFileDialog.EnsurePathExists = true;
                commonOpenFileDialog.EnsureReadOnly = false;
                commonOpenFileDialog.EnsureValidNames = true;
                commonOpenFileDialog.Multiselect = false;
                commonOpenFileDialog.ShowPlacesList = true;
                if (commonOpenFileDialog.ShowDialog() != CommonFileDialogResult.Ok)
                    return;
                string fileName1 = commonOpenFileDialog.FileName;
                string str1 = fileName1 + "\\FortniteGame\\Binaries\\Win64";
                if (!System.IO.File.Exists(str1 + "/FortniteClient-Win64-Shipping.exe"))
                {
                    int num = (int)MessageBox.Show("The path selected does not have Fortnite installed correctly: " + fileName1 + "\\nPlease retry with a valid path");
                }
                if (!System.IO.File.Exists(str1 + "/FortniteClient-Win64-Shipping.exe"))
                    return;
                Process.Start("https://discord.gg/stormfn");
                string fileName4 = Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
                string str2 = Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe");
                string str3 = Path.Combine(fileName1, "FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe");
                string arguments = "-AUTH_LOGIN=unused -AUTH_PASSWORD=" + this.exchange + " -AUTH_TYPE=exchangecode -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -nobe -fromfl=eac -fltoken=3db3ba5dcbd2e16703f3978d -caldera=eyJhbGciOiJFUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiYmU5ZGE1YzJmYmVhNDQwN2IyZjQwZWJhYWQ4NTlhZDQiLCJnZW5lcmF0ZWQiOjE2Mzg3MTcyNzgsImNhbGRlcmFHdWlkIjoiMzgxMGI4NjMtMmE2NS00NDU3LTliNTgtNGRhYjNiNDgyYTg2IiwiYWNQcm92aWRlciI6IkVhc3lBbnRpQ2hlYXQiLCJub3RlcyI6IiIsImZhbGxiYWNrIjpmYWxzZX0.VAWQB67RTxhiWOxx7DBjnzDnXyyEnX7OljJm-j2d88G_WgwQ9wrE6lwMEHZHjBd1ISJdUO1UVUqkfLdU5nofBQ - skippatchcheck";
                Process process1 = new Process()
                {
                    StartInfo = new ProcessStartInfo(fileName4, arguments)
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    }
                };
                Process process2 = new Process();
                process2.StartInfo.FileName = str3;
                process2.Start();
                foreach (ProcessThread thread in (ReadOnlyCollectionBase)process2.Threads)
                    win32.SuspendThread(win32.OpenThread(2, false, thread.Id));
                Process process3 = new Process();
                process3.StartInfo.FileName = str2;
                process3.StartInfo.Arguments = "-epiclocale = en - nobe - fromfl = eac - fltoken = 3db3ba5dcbd2e16703f3978d - caldera = eyJhbGciOiJFUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiYmU5ZGE1YzJmYmVhNDQwN2IyZjQwZWJhYWQ4NTlhZDQiLCJnZW5lcmF0ZWQiOjE2Mzg3MTcyNzgsImNhbGRlcmFHdWlkIjoiMzgxMGI4NjMtMmE2NS00NDU3LTliNTgtNGRhYjNiNDgyYTg2IiwiYWNQcm92aWRlciI6IkVhc3lBbnRpQ2hlYXQiLCJub3RlcyI6IiIsImZhbGxiYWNrIjpmYWxzZX0.VAWQB67RTxhiWOxx7DBjnzDnXyyEnX7OljJm - j2d88G_WgwQ9wrE6lwMEHZHjBd1ISJdUO1UVUqkfLdU5nofBQ";
                process3.Start();
                foreach (ProcessThread thread in (ReadOnlyCollectionBase)process3.Threads)
                    win32.SuspendThread(win32.OpenThread(2, false, thread.Id));
                process1.Start();
                inject.InjectDll(process1.Id, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), stringvalues.dll)); // change this in the stringvalues.cs or do "Yourdll.dll"
                Thread.Sleep(2000);
                Thread.Sleep(6000);
                System.IO.File.Delete(fileName1 + "\\FortniteGame\\Binaries\\Win64\\Injector.exe");
                process1.WaitForInputIdle();
                process1.WaitForExit();
                try
                {
                    process2.Close();
                    process3.Close();
                }
                catch
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://rebrand.ly/authcode");
        }
    }
}