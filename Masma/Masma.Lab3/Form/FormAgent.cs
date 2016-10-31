using System;
using System.Windows.Forms;

namespace Masma.Lab3.Form
{
    public partial class FormAgent : System.Windows.Forms.Form
    {
        public FormAgent()
        {
            InitializeComponent();
        }

        public void DoEvents()
        {
            Application.DoEvents();
        }

        public void AddTextLine(string s)
        {
            textBoxMessages.AppendText(s + Environment.NewLine);
        }

        private void FormAgent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}