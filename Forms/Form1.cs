using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowMover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void buttonDetailedView_Click(object sender, EventArgs e)
        {
            LoadView(new DetailedView() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true });
        }

        private void buttonStandardView_Click(object sender, EventArgs e)
        {
            LoadView(new StandardView() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true });
        }

        private void LoadView(Form form)
        {
            this.formLoader.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None;
            this.formLoader.Controls.Add(form);
            form.Show();
        }
    }
}
