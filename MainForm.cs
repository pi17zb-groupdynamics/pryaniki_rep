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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            var isPrime = method.IsPrime((int)numericUpDown1.Value) ? "простое" : "не простое";
            //label3.Text = Convert.ToString();
            watch.Stop();

            label3.Text = $"Число {isPrime}, вычисление заняло {watch.Elapsed.TotalSeconds} секунд";
            
        }
    }
}
