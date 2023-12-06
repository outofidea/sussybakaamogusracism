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

        private void btnConfClickedHandler(object sender, EventArgs e)
        {
            btnConfclicked = true;
        }

        private void btnCancClickedHandler(object sender, EventArgs e)
        {
            btnCanclicked = true;
        }

        private void checkButtons()
        {
            if (btnConfclicked == true)
            {

            }
            else if(btnCanclicked == true){

            }
        }

        private bool btnConfclicked = false;
        private bool btnCanclicked = false;


    }

}
