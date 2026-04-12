using AwladAli_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwladAli.User
{
    public partial class ctrlUserCard : UserControl
    {
        clsUser _User;
        private int _UserID = -1;

        //useing UserID in forms 
        public int UserID
        {
            get { return _UserID; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }


        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.Find(UserID);
            _UserID = _User.UserID;
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("Error, user is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.UserName.ToString();
            lblRole.Text = _User.Role.ToString();
        }

        private void _ResetUserInfo()
        {
            lblUserID.Text = "[???]";
            lblUsername.Text = "[???]";
            lblRole.Text = "[???]";
        }
    }
}
