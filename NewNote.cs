using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using JKLibrary;
using MySql.Data.MySqlClient;

namespace NOTE
{

    public partial class NewNote : Form
    {
        public NewNote()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                Clipboard.SetDataObject(richTextBox1.SelectedText); 
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                richTextBox1.Text = richTextBox1.Text + (String)iData.GetData(DataFormats.Text);
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file2 = new OpenFileDialog();
            file2.Filter = "文本文件|*.txt";
            if (file2.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = File.OpenText(file2.FileName);
                while (sr.EndOfStream != true)
                {
                    richTextBox1.Text = sr.ReadLine();
                    MessageBox.Show("您已成功打开!");
                }
            }
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file1 = new SaveFileDialog();
            file1.Filter = "文本文件|*.txt";
            if (file1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = File.AppendText(file1.FileName);
                sw.WriteLine(richTextBox1.Text);
                sw.Flush();
                sw.Close();
                MessageBox.Show("保存成功!");
            }
        }

        //private void NewNote_Load(object sender, EventArgs e)
        //{
        //    this.noteInfoTableAdapter.Fill(this.noteDataSet1.NoteInfo);
        //    DataSet dt = SQLHelper.GetDataSet("select * from NoteInfo ", null);
        //    string conn = "server=localhost;port=3306;User Id=root;password=123123;Database=note";
        //    string Sql = "select distinct Classify from NoteInfo";
        //    DataSet Ds = new DataSet();
        //    MySqlDataAdapter Da = new MySqlDataAdapter(Sql, conn);
        //    Da.Fill(Ds, "NoteInfo");
        //    comboBox1.DataSource = Ds.Tables["NoteInfo"];
        //    comboBox1.DisplayMember = "Classify";
        //}


        //private void SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();      //每次事件开始就清空控件 
        //    MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;User Id=root;password=123123;Database=note");
        //    conn.Open();//打开连接 
        //    MySqlCommand cmd = new MySqlCommand("select * from NoteInfo where Classify= '" + comboBox1.Text + "'", conn);
        //    MySqlDataReader sdr = cmd.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        listBox1.Items.Add((sdr["Title"].ToString().Trim()));
        //    }
        //    sdr.Close();
        //    conn.Close();   //关闭数据库连接
        //}


        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;   //提供自己给定的颜色   
            colorDialog1.CustomColors = new int[] { 6916092, 15195440, 16107657, 1836924 };
            colorDialog1.ShowHelp = true;
            colorDialog1.ShowDialog();
            richTextBox1.ForeColor = colorDialog1.Color;
        }

        private void fontDialog1_Apply(object sender, EventArgs e){}

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Color = richTextBox1.ForeColor;
            fontDialog.AllowScriptChange = true;
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog()!= DialogResult.Cancel)
            {
                richTextBox1.SelectionFont = fontDialog.Font;//将当前选定的文字改变字体
            }
        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a1 = new About();
            a1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClassify.Text.ToString().Trim() != "" && txttitle.Text.ToString().Trim() != "")
            {
                string conn = "server=localhost;port=3306;User Id=root;password=123123;Database=note";
                MySqlConnection mycon = new MySqlConnection(conn);
                mycon.Open();
                String s="陈林朋";
                string sql = "insert into NoteInfo(Classify,Title,note) values('" + txtClassify.Text.ToString() + "','" + txttitle.Text.ToString() + "','" + richTextBox1.Text.ToString() + "')";
                //string sql = "insert into NoteInfo(Classify,Title,note) values('"+s+"','简单','" + richTextBox1.Text.ToString() + "')";
                try
                {
                    MySqlCommand mycom = new MySqlCommand(sql, mycon);           //定义对象并连接数据库
                     mycom.ExecuteNonQuery();
                }
                catch (MySqlException mse)
                {
                    MessageBox.Show(mse.Message);
                    return;
                }
                mycon.Close();                //关闭对象并释放所占内存空间    
                mycon.Dispose();
                MessageBox.Show("保存成功");
                return;
            }
            else
            {
                MessageBox.Show("保存失败！");
                return;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.txtClassify.Clear();
            this.txttitle.Clear();
            this.richTextBox1.Clear();
        }

        //private void listBox1_SelectedIndexChanged(object sender, EventArgs e){}

        //private void listBox1_Click(object sender, EventArgs e)
        //{
        //    MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;User Id=root;password=123123;Database=note");
        //    conn.Open();//打开连接 
        //    MySqlCommand cmd = new MySqlCommand("select * from NoteInfo where Title= '" + listBox1.Text + "'", conn);
        //    MySqlDataReader sdr = cmd.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        richTextBox1.Text = sdr[2].ToString();
        //    } sdr.Close();
        //    conn.Close();   //关闭数据库连接
        //}

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClassify_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttitle_TextChanged(object sender, EventArgs e)
        {

        }


       
        }

     
    }


