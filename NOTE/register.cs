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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button1_rigister(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                string conn = "server=localhost;port=3306;User Id=root;password=123123;Database=note";
                MySqlConnection mycon = new MySqlConnection(conn);
                mycon.Open();
                string sql = "insert into UsersInfo(UserName,Password,Name) values('" + txtUserName.Text + "','" + txtPassword.Text + "','" + txtTel.Text + "')";
                MySqlCommand mycom = new MySqlCommand(sql, mycon);           //定义对象并连接数据库
                mycom.ExecuteNonQuery();                           //执行插入语句
                mycon.Close();                //关闭对象并释放所占内存空间    
                mycon.Dispose();
                MessageBox.Show("注册成功");
                return;
            }
            else
            {
                MessageBox.Show("输入错误！");
                return;
            }     
        }
            
        private void button2_exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e){}

        private void label1_Click(object sender, EventArgs e) {}

        private void label2_Click(object sender, EventArgs e) {}

        private void label3_Click(object sender, EventArgs e){}

        private void label4_Click(object sender, EventArgs e){}

        private void txtUserName_TextChanged(object sender, EventArgs e){ }

    }
}
