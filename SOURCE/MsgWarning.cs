using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Vanara.PInvoke.Kernel32;

namespace Exsperian
{
    public partial class MsgWarning : Form
    {
        public MsgWarning()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            Process[] app = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Application.ExecutablePath));
            {
                if (app.Length > 0)
                {
                    foreach (var process in app)
                    {
                        process.Kill();
                    }
                }
            }
        }

        private void exec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
