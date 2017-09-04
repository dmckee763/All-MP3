using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertAllMP3
{
	public partial class frmMain : Form
	{
		Converter converter;
		public frmMain()
		{
			InitializeComponent();
			converter = new Converter();
		}


        #region Button Events        

        private void btnSelectInput_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInputPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnSelectOutput_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //converter.Convert(txtInputPath.Text, txtOutputPath.Text);
            converter.ConvertDirectory(txtOutputPath.Text.Trim());
        }

        #endregion

    }
}
