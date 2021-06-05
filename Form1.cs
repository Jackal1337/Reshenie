using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nelin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 2;

            dataGridView2.RowCount = 2;
            dataGridView3.RowCount = 2;
        }

        double foo1(double x)
        {
            return Math.Sqrt(2-x*x);
        }

        double foo2(double x)
        {
            return 0.25 * x * x * x - 1;
        }

        double Norma(DataGridView a, DataGridView b)
        {
            double c1 = 0, c2 = 0;
            for(int i =0;i<2;i++)
            {
                c1 = Convert.ToDouble(a.Rows[0].Cells[0].Value.ToString()) - Convert.ToDouble(b.Rows[0].Cells[0].Value.ToString());
                c2 = Convert.ToDouble(a.Rows[1].Cells[0].Value.ToString()) - Convert.ToDouble(b.Rows[1].Cells[0].Value.ToString());
            }
            c1 = c1 * c1;
            c2 = c2 * c2;
            return Math.Sqrt(c1 + c2);
        }


       private void button1_Click(object sender, EventArgs e)
       {
            int k = 1;
            double EPS = Convert.ToDouble(textBox1.Text);
            double x1 = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value);
            double x2 = Convert.ToDouble(dataGridView1.Rows[1].Cells[0].Value);
            dataGridView2.Rows[0].Cells[0].Value = foo1(x2);
            dataGridView2.Rows[1].Cells[0].Value = foo2(x1);
            dataGridView3.Rows[0].Cells[0].Value = dataGridView2.Rows[0].Cells[0].Value;
            dataGridView3.Rows[1].Cells[0].Value = dataGridView2.Rows[1].Cells[0].Value;
            x1 = Convert.ToDouble(dataGridView3.Rows[0].Cells[0].Value);
            x2 = Convert.ToDouble(dataGridView3.Rows[1].Cells[0].Value);
            dataGridView2.Rows[0].Cells[0].Value = foo1(x2);
            dataGridView2.Rows[1].Cells[0].Value = foo2(x1);
            k++;
            while (Norma(dataGridView2, dataGridView3)>EPS)
            {
                dataGridView3.Rows[0].Cells[0].Value = dataGridView2.Rows[0].Cells[0].Value;
                dataGridView3.Rows[1].Cells[0].Value = dataGridView2.Rows[1].Cells[0].Value;
                x1 = Convert.ToDouble(dataGridView3.Rows[0].Cells[0].Value);
                x2 = Convert.ToDouble(dataGridView3.Rows[1].Cells[0].Value);
                dataGridView2.Rows[0].Cells[0].Value = foo1(x2);
                dataGridView2.Rows[1].Cells[0].Value = foo2(x1);
                k++;
            }
            textBox2.Text = k + "";
        }

        private void button2_Click(object sender, EventArgs e) // коорд
        {
            int k = 1;
            double EPS = Convert.ToDouble(textBox1.Text);
            double x2 = Convert.ToDouble(dataGridView1.Rows[1].Cells[0].Value);
            dataGridView2.Rows[0].Cells[0].Value = foo1(x2);// счет нового х1
            double x1 = Convert.ToDouble(dataGridView2.Rows[0].Cells[0].Value);// взяли новый х1
            dataGridView2.Rows[1].Cells[0].Value = foo2(x1); // счет нового х2
            dataGridView3.Rows[0].Cells[0].Value = dataGridView2.Rows[0].Cells[0].Value; // кинули в промежуточный
            dataGridView3.Rows[1].Cells[0].Value = dataGridView2.Rows[1].Cells[0].Value; // кинули в промежуточный
            x2 = Convert.ToDouble(dataGridView3.Rows[1].Cells[0].Value);
            dataGridView2.Rows[0].Cells[0].Value = foo1(x2);// счет нового х1
            x1 = Convert.ToDouble(dataGridView2.Rows[0].Cells[0].Value);// взяли новый х1
            dataGridView2.Rows[1].Cells[0].Value = foo2(x1); // счет нового х2
            k++;
            while (Norma(dataGridView2, dataGridView3) > EPS)
            {
                dataGridView3.Rows[0].Cells[0].Value = dataGridView2.Rows[0].Cells[0].Value; // кинули в промежуточный
                dataGridView3.Rows[1].Cells[0].Value = dataGridView2.Rows[1].Cells[0].Value; // кинули в промежуточный
                x2 = Convert.ToDouble(dataGridView3.Rows[1].Cells[0].Value);
                dataGridView2.Rows[0].Cells[0].Value = foo1(x2);// счет нового х1
                x1 = Convert.ToDouble(dataGridView2.Rows[0].Cells[0].Value);// взяли новый х1
                dataGridView2.Rows[1].Cells[0].Value = foo2(x1); // счет нового х2
                k++;
            }
        textBox2.Text = k + "";
        }
    }
}
