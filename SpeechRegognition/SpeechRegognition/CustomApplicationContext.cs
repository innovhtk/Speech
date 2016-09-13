using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpeechRegognition
{
    public class CustomApplicationContext : ApplicationContext
    {
   
        private NotifyIcon notifyIcon = null;
        private System.ComponentModel.IContainer components = null;
        private Form introForm = null;
        public CustomApplicationContext()
        {
            InitializeContext();
        }
        private void InitializeContext()
        {
            components = new System.ComponentModel.Container();
            notifyIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new System.Drawing.Icon(@"C:\Users\Eleazar\Documents\DEV.INNOVACION\htk.ico"),
                Text = "Host Switcher",
                Visible = true
            };
            notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;

        }

        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowIntroForm();
        }

        void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;

            notifyIcon.ContextMenuStrip.Items.Clear();

            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add("Salir");

        }

        private void ShowIntroForm()
        {
            if (introForm == null)
            {
                introForm = new Form1();
                introForm.Closed += mainForm_Closed;
                introForm.Show();
            }
            else { introForm.Activate(); }
        }

        private void mainForm_Closed(object sender, EventArgs e)
        {
            introForm = null;
        }
    }
}
