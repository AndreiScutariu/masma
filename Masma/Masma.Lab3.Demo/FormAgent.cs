using System;
using System.Windows.Forms;

namespace AgentServices
{
    public partial class FormAgent : Form
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
            Environment.Exit(0); // inchide TOATE ferestrele si aplicatia Jade
        }
    }
}