using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String strcnn = "Data Source=LAPTOP-HF25TITB;Initial Catalog=QLSV;Integrated Security=True";
        BindingSource bs = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            if( cnn == null)
                cnn = new SqlConnection(strcnn);    
            SqlDataAdapter adt = new SqlDataAdapter("Select *from SinhVien",cnn);
            SqlCommandBuilder buider = new SqlCommandBuilder(adt);
            DataSet ds = new DataSet();
            adt.Fill(ds, "SinhVien");
            bs = new BindingSource(ds, "SinhVien");
            txtma.DataBindings.Add("text", bs, "MSSV");
            txttensv.DataBindings.Add("text", bs, "TENSV");
            txtdiem.DataBindings.Add("text", bs, "DTB");
            txtmakhoa.DataBindings.Add("text", bs, "MAKHOA");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(bs.Position >0) { bs.Position--; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bs.Position < bs.Count - 1) { bs.Position++; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            MessageBox.Show(" LUU THANH CONG");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bs.AddNew();
            MessageBox.Show("them THANH CONG");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bs.RemoveCurrent();
            MessageBox.Show("xoa THANH CONG");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = (bs.Position +1) + "/" + bs.Count;
        }
    }
}

