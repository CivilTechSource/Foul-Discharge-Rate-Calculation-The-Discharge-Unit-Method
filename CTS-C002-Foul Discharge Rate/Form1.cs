using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace CTS_C002_Foul_Discharge_Rate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
       
        //Typical Frequency
        void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                //MessageBox.Show(rb.Name);
                switch (rb.Name)
                {
                    case "radioButton_Dwelling":
                        TextBox_KDU.Text = "0.5";
                        break;
                    case "radioButton_Hospital":
                        TextBox_KDU.Text = "0.7";
                        break;
                    case "radioButton_Toilets":
                        TextBox_KDU.Text = "1.0";
                        break;
                    case "radioButton_Labs":
                        TextBox_KDU.Text = "1.2";
                        break;
                }
            }
        }

        //Custom KDU value - CheckBox
        void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked==true)
            {
                TextBox_KDU.Enabled = true;
            }
            else if (cb.Checked==false)
            {
                TextBox_KDU.Enabled = false;
                //Code required to revert back to radiobutton value
            }
             
        }

        private void Button_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                double Q;
                double Sum_DU;


                double kdu = Convert.ToDouble(TextBox_KDU.Text);

                double No_Washbasin = double.Parse(TextBox_NoWashbasin.Text);
                double DU_Washbasin = double.Parse(TextBox_DUWashbasin.Text);

                double No_Urinal = double.Parse(TextBox_NoUrinal.Text);
                double DU_Urinal = double.Parse(TextBox_DUUrinal.Text);

                double No_Bath = double.Parse(TextBox_NoBath.Text);
                double DU_Bath = double.Parse(TextBox_DUBath.Text);

                double No_Dishwasher = double.Parse(TextBox_NoDishwasher.Text);
                double DU_Dishwasher = double.Parse(TextBox_DUDishwasher.Text);

                double No_Household = double.Parse(TextBox_NoHousehold.Text);
                double DU_Household = double.Parse(TextBox_DUHousehold.Text);

                double No_Commercial = double.Parse(TextBox_NoCommercial.Text);
                double DU_Commercial = double.Parse(TextBox_DUCommercial.Text);

                double No_WC = double.Parse(TextBox_NoWC.Text);
                double DU_WC = double.Parse(TextBox_DUWC.Text);

                double No_Floor = double.Parse(TextBox_NoFloor.Text);
                double DU_Floor = double.Parse(TextBox_DUFloor.Text);

                Sum_DU = No_Washbasin * DU_Washbasin + No_Urinal * DU_Urinal + No_Bath * DU_Bath
                    + No_Dishwasher * DU_Dishwasher + No_Household * DU_Household + No_Commercial * No_Commercial
                    + No_WC * DU_WC + No_Floor * DU_Floor;

                Q = Math.Round(kdu * Math.Sqrt(Sum_DU), 3);
                Label_Result.Text = Convert.ToString(Q) + " l/s";
            }
            catch (Exception)
            {
                MessageBox.Show("Please make sure the input is in the right format!", "Oops! Something went wrong..");
            }

        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            TextBox_NoWashbasin.Text = "0";
            TextBox_DUWashbasin.Text = "0.6";

            TextBox_NoUrinal.Text = "0";
            TextBox_DUUrinal.Text = "0.8";

            TextBox_NoBath.Text = "0";
            TextBox_DUBath.Text = "1.3";

            TextBox_NoDishwasher.Text = "0";
            TextBox_DUDishwasher.Text = "0.8";

            TextBox_NoHousehold.Text = "0";
            TextBox_DUHousehold.Text = "0.8";

            TextBox_NoCommercial.Text = "0";
            TextBox_DUCommercial.Text = "1.5";

            TextBox_NoWC.Text = "0";
            TextBox_DUWC.Text = "2.5";

            TextBox_NoFloor.Text = "0";
            TextBox_DUFloor.Text = "2.0";

            TextBox_KDU.Text = "0.5";
            radioButton_Dwelling.Checked = true;
            CheckBox_CustomKDU.Checked = false;
        }

        void CTS_Hyperlink(object sender, EventArgs e)
        {
            Process.Start("https://civiltechsource.com/");
        }


    }
}
