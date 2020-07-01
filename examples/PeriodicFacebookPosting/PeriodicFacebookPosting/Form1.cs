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
using System.Threading;

using Automation.Facebook;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PeriodicFacebookPosting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FacebookCrawler fcbCrawler;
        private bool loggedIn = false;
        private void BeginPosting_Click(object sender, EventArgs e)
        {
            if (groups == null)
            {
                MessageBox.Show("To post you have to attach a file with the targeted groups!", "Groups are missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(Message.Text))
            {
                MessageBox.Show("To post a message in a group you need a message!", "Message is missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int delay = 600;
            try
            {
                delay = int.Parse(DelayBetweenPosting.Text);
            }
            catch
            {
                MessageBox.Show("The delay must be an integer and in seconds!", "Delay error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fcbCrawler = new FacebookCrawler(new FirefoxDriver());
            if (!fcbCrawler.LogIn(EmailTxtBox.Text, PasswordTxtBox.Text))
            {
                MessageBox.Show("Couldn't log in successfully!", "Log in error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            loggedIn = true;

            StreamWriter sw = new StreamWriter("post log.txt");
            for (int i = 0; i < groups.Length; ++i)
            {
                if (fcbCrawler.PostTextInGroup(groups[i], Message.Text))
                    sw.WriteLine("Successfully posted in " + groups[i]);
                else
                    sw.WriteLine("Posting in " + groups[i] + " was not successful!");
                Thread.Sleep(delay * 1000);
            }
            sw.Close();

            fcbCrawler.LogOut();
            loggedIn = false;
        }

        private string[] groups;
        private void AttachFileWithGroups_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Txt File with groups|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                    if (File.Exists(ofd.FileName))
                        groups = File.ReadAllLines(ofd.FileName);
            }
        }

        private void FacebookAutomatedPostingService_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loggedIn)
                fcbCrawler.LogOut();
            loggedIn = false;
        }

        private void FacebookAutomatedPostingService_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (loggedIn)
                fcbCrawler.LogOut();
            loggedIn = false;
        }
    }
}
