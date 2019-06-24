using System;
using System.Threading;
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
            Thread thread;
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

            thread = new Thread(implementation);
            thread.IsBackground = true;
            thread.Start();
        }

        private void implementation()
        {
            button1.Invoke((MethodInvoker)(() => button1.Enabled = false));
            var watch = System.Diagnostics.Stopwatch.StartNew();
        
            if (numericUpDown1 == null)
                numericUpDown1.Value = 1;

            var isPrime = method.IsPrime((int)numericUpDown1.Value) ? "простое" : "не простое";
            watch.Stop();
            label3.Invoke((MethodInvoker)(() => label3.Text = $"Число {isPrime}, вычисление заняло {Math.Round(watch.Elapsed.TotalSeconds, 6)} секунд"));
            button1.Invoke((MethodInvoker)(() => button1.Enabled = true));
        }
    }
}
