using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using JKLibrary;

namespace NOTE
{
    public partial class Login : Form
    {
        public int i;
        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            DataSet dt = SQLHelper.GetDataSet("select * from UsersInfo ", null);
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                string _name = Convert.ToString(dt.Tables[0].Rows[i]["UserName"]);
                string _password = Convert.ToString(dt.Tables[0].Rows[i]["Password"]);

                if (txtUserName.Text == _name && txtPassword.Text == _password)
                {
                    MessageBox.Show("登录成功！欢迎您使用Freedom&Note记事本");
                    Main m1 = new Main();
                    m1.ShowDialog();
                    return;
                }else{
                    MessageBox.Show("登录失败，请重新输入！");
                 }
            }
        }

        private void button1_Click(object sender, EventArgs e)  
        {
            this.Close();
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            register r1 = new register();
            r1.ShowDialog();
        }

        
        private void button_forget_Click(object sender, EventArgs e)
        {
            Forget f1 = new Forget();
            f1.ShowDialog();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

    

     
    }
}
