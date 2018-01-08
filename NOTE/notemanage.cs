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
    public partial class notemanage : Form
    {
        public notemanage()
        {
            InitializeComponent();
        }

        //private void notemanage_Load(object sender, EventArgs e)
        //{
        //    // TODO: 这行代码将数据加载到表“noteDataSet1.NoteInfo”中。您可以根据需要移动或删除它。
        //    this.noteInfoTableAdapter.Fill(this.noteDataSet1.NoteInfo);

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dt = SQLHelper.GetDataSet("select * from NoteInfo ", null);
            string conn = "server=localhost;port=3306;User Id=root;password=123123;Database=note";
            MySqlConnection mycon = new MySqlConnection(conn);
            mycon.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = mycon;
            cmd.CommandText = "UPDATE NoteInfo SET note = '" + textBox3.Text + "'WHERE Classify='" + textBox1.Text + "' and Title='" + textBox2.Text + "'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    DataSet dt = SQLHelper.GetDataSet("select * from NoteInfo ", null);
        //    string conn = "server=localhost;port=3306;User Id=root;password=123123;Database=note";
        //    MySqlConnection mycon = new MySqlConnection(conn);
        //    mycon.Open();
        //    MySqlCommand cmd = new MySqlCommand();
        //    cmd.Connection = mycon;
        //    //cmd.CommandText = "UPDATE NoteInfo SET note = '" + textBox3.Text + "'WHERE Classify='" + textBox1.Text + "' and Title='" + textBox2.Text + "'";
        //    try {
        //        textBox3.Text=(cmd.CommandText = "select note from NoteInfo WHERE Classify='" + textBox1.Text + "' and Title='" + textBox2.Text + "'");
                
        //    }catch(MySqlException mse){
        //        MessageBox.Show(mse.Message);
        //        return;
        //    }
        //}
    }
}
