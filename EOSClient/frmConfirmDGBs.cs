using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EOSClient
{
    public partial class frmConfirmDGBs : Form
    {
        public frmConfirmDGBs()
        {
            InitializeComponent();
        }


        bool isconfirmed = false;
        public string ExamPath
        {
            get { return txtLoadExam.Text; }
        }

        public bool IsConfirmed
        {
            get { return isconfirmed; }
        }

        private void btnConfClickedHandler(object sender, EventArgs e)
        {
            isconfirmed = true;
            this.Close();
        }

        private void btnCancClickedHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// File Browse button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "All files (*.*)|*.*";
            DialogResult result = dlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                string filepath = dlg.FileName.Trim();
                txtLoadExam.Text = filepath;
            }
        }

        /// <summary>
        /// txtbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoadExam_TextChanged(object sender, EventArgs e)
        {
            if(txtLoadExam.Text.Length > 0)
            {
                var path = txtLoadExam.Text;
                bool PathValid = System.IO.File.Exists(path);
                if (PathValid)
                {
                    btnConf.Enabled = true;
                }
                else
                {
                    btnConf.Enabled = false;
                }
            }

            else
            {
                btnConf.Enabled = false;
            }
        }

        /// <summary>
        /// Load Exam Checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLoad.Checked)
            {
                txtLoadExam.Enabled = true;
                btnBrowseFile.Enabled = true;   
                btnConf.Enabled = false;
            }
            else
            {
                txtLoadExam.Enabled=false;
                btnBrowseFile.Enabled=false;    
                btnConf.Enabled=true;
            }
        }
    }

}
