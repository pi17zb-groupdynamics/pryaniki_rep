using System;
using System.Threading;
using System.Windows.Forms;

namespace PrimeNumbers
{
    public partial class MainForm : Form
    {
        Thread thread;
        IPrimeCheckMethod method;
        public MainForm()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            progressBar1.Visible = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // Здесь метод перебора делителей
                method = new BustDivisors();
                progressBar1.Visible = true;

                //Реализация progressBar
                thread = new Thread(new ParameterizedThreadStart(progress));
                thread.IsBackground = true;
                thread.Start(method);

                label3.Text = Convert.ToString(method.Result);
            }
            if (radioButton2.Checked)
            {
                // Здесь тест Миллера-Рабина
                //method = new MillerRabin();
                //label3.Text = Convert.ToString(method.IsPrime((int)numericUpDown1.Value));
            }
            if (radioButton3.Checked)
            {
                // Здесь Решето Эратосфена
                //method = new SieveOfEratosthenes();
                //label3.Text = Convert.ToString(method.IsPrime((int)numericUpDown1.Value));
            }
        }

        private void progress(object method)
        {
            IPrimeCheckMethod Method = (IPrimeCheckMethod)method;
            Progress pp;
            pp = progress;
        }

        private void progress(int p)
        {
            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Visible = true));
            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = p));
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
