using SqlViewer.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlViewer.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            HideError();
        }

        private void HideError() => lbError.Visible = false;

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                HideError();
                Repository.Login(
                   tbServer.Text.Trim(),
                   tbUserName.Text.Trim(),
                   tbPassword.Text.Trim()
                );
                new MainForm().Show();
                Hide();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                lbError.Visible = true;
            }
        }
    }
}
