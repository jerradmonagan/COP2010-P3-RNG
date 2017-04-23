using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3jmonagan
{
    //Jerrad Monagan
    //COP2010
    //Project3
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int intLowerBound = 0;
        int intUpperBound = 0;
        int intMax;
        
        private Boolean ValidateNumber()
        {
            intLowerBound = int.Parse(txtLowerBound.Text);
            intUpperBound = int.Parse(txtUpperBound.Text);
            intMax = int.Parse(txtNumberGenerate.Text);
            if ((intLowerBound < intUpperBound)&(intMax>=1))
                return true;
            else
                return false;
        }//end ValidateNumber

        private void SetBounds()
        {
            try
            {
                intLowerBound = int.Parse(txtLowerBound.Text);
                intUpperBound = int.Parse(txtUpperBound.Text);
                intMax = int.Parse(txtNumberGenerate.Text);
                int[] countArray = new int[(intUpperBound - intLowerBound) + 1];
                int[] rngArray = new int[intMax];
                int[] displayArray=new int[(intUpperBound - intLowerBound) + 1];
                int intSetIndex = intLowerBound;

                Random rng = new Random();
                if (ValidateNumber())
                    for (int intI = 0; intI < (intUpperBound - intLowerBound) + 1; intI++)
                    {
                        countArray[intI] = intSetIndex;
                        intSetIndex++;
                    }//end if

                else
                    MessageBox.Show("Lower Bounds must be less than or equal to Upper Bounds and numbers to generate must be greater than 1", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                for (int intJ = 0; intJ < rngArray.Length; intJ++)
                {
                    int intGenNumber = rng.Next(intLowerBound, intUpperBound);
                    rngArray[intJ] = intGenNumber;
                }//end for
                for(int intK=0; intK < countArray.Length-1; intK++)
                    for (int intL=0; intL< rngArray.Length; intL++)
                        if ((countArray[intK]).Equals(rngArray[intL]))
                        {
                        displayArray[intK] = (displayArray[intK])+1;
                        }//end if           
                for (int intK = 0; intK < countArray.Length; intK++)
                    lstDisplay.Items.Add("The number "+countArray[intK]+" has been selected "+displayArray[intK]);
                
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end catch
        }//end setBounds

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnExit

        private void btnGenerateNumber_Click(object sender, EventArgs e)
        {
            SetBounds();
        }//end btnGenerateNumber

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNumberGenerate.Clear();
            lstDisplay.Items.Clear();
            txtNumberGenerate.Focus();
        }//end btnReset
    }
}
