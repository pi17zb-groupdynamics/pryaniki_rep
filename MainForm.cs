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
                method = new MillerRabin();
            }
            if (radioButton3.Checked)
            {
                method = new SieveOfEratosthenes();
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (numericUpDown1 == null)
                numericUpDown1.Value = 1;

            var isPrime = method.IsPrime((int)numericUpDown1.Value) ? "простое" : "не простое";
            watch.Stop();

            label3.Text = $"Число {isPrime}, вычисление заняло {watch.Elapsed.TotalSeconds} секунд";
            
        }
    }
}
