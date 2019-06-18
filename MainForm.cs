using System;
using System.Windows.Forms;

namespace PrimeNumbers
{
    public partial class MainForm : Form
    {
        IPrimeCheckMethod method;
        public MainForm()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                method = new BustDivisors();
            }
            if (radioButton2.Checked)
            {
                // Здесь тест Миллера-Рабина
                method = new MillerRabin();
            }
            if (radioButton3.Checked)
            {
                // Здесь Решето Эратосфена
                method = new SieveOfEratosthenes();
            }
            label3.Text = Convert.ToString(method.IsPrime((int)numericUpDown1.Value));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
