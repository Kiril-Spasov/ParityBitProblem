using System;
using System.IO;
using System.Windows.Forms;

namespace ParityBitProblem
{
    public partial class FormParityBit : Form
    {
        public FormParityBit()
        {
            InitializeComponent();
        }

        int countOnes;
        string binary;

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\parity.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    CheckParity(FindBinaryBits(Convert.ToInt32(line)));

                    if (countOnes % 2 == 0)
                    {
                        TxtResult.Text += line + " - " + binary + " - 0" + Environment.NewLine;
                    }
                    else
                    {
                        TxtResult.Text += line + " - " + binary + " - 1" + Environment.NewLine;
                    }
                }
            }
        }

        private int[] FindBinaryBits(int number)
        {
            int[] bits = new int[] { 0, 1, 2, 4, 8, 16, 32, 64 };
            int[] bitsCount = new int[65];

            binary = "";

            //Per assignment input is 0 <= N <= 128.
            //First we divide the number by 64, if result is >= 1,
            //we add 1 in the array counter to the corresponding bit.
            //We do this for all 7 bits.
            for (int i = bits.Length - 1; i >= 1; i--)
            {
                if (number / bits[i] >= 1)
                {
                    bitsCount[bits[i]] += 1;
                    number = number - bits[i];
                    binary += "1";
                }
                else
                {
                    binary += "0";
                }
            }
            return bitsCount;
        }

        private void CheckParity(int[] bitsCount)
        {
            countOnes = 0;

            for (int i = 0; i < bitsCount.Length; i++)
            {
                if (bitsCount[i] == 1)
                    countOnes++;
            }
        }
    }
}
