using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom_Calculator_Backend_class;


namespace Custom_Calculator
{
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        Calculator calc = new Calculator();
        
        public void UpdateUI(bool equal = false, bool special = false)
        {
            if (equal)
            {
                txtDisplay1.Text = calc.eq.answer.ToString();
                txtDisplay2.Text = calc.eq.frtNumber.ToString() + " " + calc.eq.operation + " "
                    + calc.eq.secNumber.ToString() + " = ";

                return;
            }
            
            if(special) 
            {
                txtDisplay1.Text = calc.eq.answer.ToString();

                if (calc.eq.operation == "^2")
                {
                    txtDisplay2.Text = calc.eq.frtNumber + calc.eq.operation;
                }
                else
                {
                    txtDisplay2.Text = calc.eq.operation + calc.eq.frtNumber;
                }

                return;
            }

            txtDisplay1.Text = calc.CurrentNumber;
            txtDisplay2.Text = calc.ConvertLastEquationToString();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(350, 570);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("0");
            UpdateUI();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("1");
            UpdateUI();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("2");
            UpdateUI();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("3");
            UpdateUI();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("4");
            UpdateUI();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("5");
            UpdateUI();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("6");
            UpdateUI();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("7");
            UpdateUI();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("8");
            UpdateUI();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            calc.ReadNumber("9");
            UpdateUI();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if(calc.CurrentNumber == string.Empty)
                calc.ReadNumber("0.");
            else
                calc.ReadNumber(".");
            UpdateUI();
        }

        private void btnChangeSign_Click(object sender, EventArgs e)
        {
            if(calc.Mode == Calculator.enMode.enReadFirst)
            {
                calc.eq.frtNumber *= -1;
                calc.CurrentNumber = calc.eq.frtNumber.ToString();
            }
            else
            {
                calc.eq.secNumber *= -1;
                calc.CurrentNumber = calc.eq.secNumber.ToString();
            }

            UpdateUI();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (calc.Mode == Calculator.enMode.enReadSecond)
            {
                calc.ContinueCalculation("+");
                UpdateUI();
                return;
            }
            calc.ReadOperation("+");
            calc.MakeEquation();
            UpdateUI();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (calc.Mode == Calculator.enMode.enReadSecond)
            {
                calc.ContinueCalculation("-");
                UpdateUI();
                return;
            }
            calc.ReadOperation("-");
            calc.MakeEquation();
            UpdateUI();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (calc.Mode == Calculator.enMode.enReadSecond)
            {
                calc.ContinueCalculation("*");
                UpdateUI();
                return;
            }
            calc.ReadOperation("*");
            calc.MakeEquation();
            UpdateUI();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (calc.Mode == Calculator.enMode.enReadSecond)
            {
                calc.ContinueCalculation("/");
                UpdateUI();
                return;
            }
            calc.ReadOperation("/");
            calc.MakeEquation();
            UpdateUI();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (calc.Mode == Calculator.enMode.enReadSecond)
            {
                calc.ContinueCalculation("2√");
                UpdateUI();
                return;
            }
            calc.ReadOperation("2√");
            calc.MakeEquation();
            UpdateUI(false, true);
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            if(calc.Mode == Calculator.enMode.enReadSecond)
            {
                calc.ContinueCalculation("^2");
                UpdateUI();
                return;
            }
            calc.ReadOperation("^2");
            calc.MakeEquation();
            UpdateUI(false, true);
        }

        private void btnOneOverX_Click(object sender, EventArgs e)
        {
            if (calc.Mode == Calculator.enMode.enReadSecond)
            {
                calc.ContinueCalculation("1/");
                UpdateUI();
                return;
            }
            calc.ReadOperation("1/");
            calc.MakeEquation();
            UpdateUI(false, true);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            calc.Mode = Calculator.enMode.enReadFirst;
            calc.MakeEquation();

            UpdateUI(true);

            calc.eq.frtNumber = calc.eq.answer;
            calc.eq.secNumber = 0;
            calc.CurrentNumber = string.Empty;
            calc.eq.operation = string.Empty;            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Calculator NewCalc = new Calculator();
            calc = NewCalc;

            UpdateUI();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(calc.CurrentNumber == string.Empty)
                return;

            calc.CurrentNumber = calc.CurrentNumber.Remove(calc.CurrentNumber.Length - 1);
            calc.ReadNumber("");
            UpdateUI();
        }
    }
}
