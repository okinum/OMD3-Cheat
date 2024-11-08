using Swed64;
using System.Collections;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices;


namespace Cheat
{
    public partial class Form1 : Form
    {

        IntPtr baseModule;

        Swed swed;

        public bool ManaFreeze = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            swed = new Swed("OMD-Win64-Shipping");
            baseModule = swed.GetModuleBase("OMD-Win64-Shipping.exe");

            Thread mainThread = new Thread(delegate ()
            {
                while (baseModule != IntPtr.Zero)
                {
                    if (checkBox1.Checked)
                    {
                        IntPtr ManaAddress = swed.ReadPointer(baseModule, 0x04F34CB8, 0x20, 0x110, 0x120, 0x8, 0xE0, 0x50);
                        swed.WriteFloat(ManaAddress, 0x8B0, (float)125.0);
                    }
                    if (checkBox2.Checked)
                    {
                        IntPtr HealthAddress = swed.ReadPointer(baseModule, 0x04FB76B0, 0x30, 0x260, 0x750, 0x20, 0xF8, 0x20);
                        swed.WriteFloat(HealthAddress, 0x51C, (float)175.0);
                    }

                    Thread.Sleep(100);
                }
            });
            mainThread.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr MoneyAddress = swed.ReadPointer(baseModule, 0x04FC2BE0, 0x10, 0x120, 0x0, 0x20);
            swed.WriteInt(MoneyAddress, 0x644, Int32.Parse(textBox1.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}