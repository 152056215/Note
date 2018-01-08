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
using MySql.Data.MySqlClient;

namespace NOTE
{
    public partial class Forget : Form
    {
        public Forget()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conn = "server=localhost;port=3306;User Id=root;password=123123;Database=note";
            MySqlConnection mycon = new MySqlConnection(conn);
            DataSet dt = SQLHelper.GetDataSet("select * from UsersInfo ", null);
            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            {
                string _name = Convert.ToString(dt.Tables[0].Rows[i]["UserName"]);
                string _password = Convert.ToString(dt.Tables[0].Rows[i]["Password"]);

                if (txtUserName.Text == _name && txtOldName.Text == _password)
                {
                    mycon.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = mycon;
                        cmd.CommandText = "UPDATE UsersInfo  SET Password =" + txtNewPassword.Text + " WHERE UserName=" + txtUserName.Text + "";
                        cmd.ExecuteNonQuery();
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("修改成功！");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("修改失败！");
                            return;
                        }
                }
                else
                {
                    MessageBox.Show("用户名或旧密码错误，请重新输入！");
                }
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

  
