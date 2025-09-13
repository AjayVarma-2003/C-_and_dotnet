using System.Data;    // imported for datatable.

namespace Calculator
{
    public partial class Form1 : Form
    {
        string CurrentResult = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            txtExpression.Text = "";    // For top textbox
        }

        private void DisplayErrorMessage()
        {
            txtDisplay.Text = "";
            MessageBox.Show("Error : Something went wrong");
            txtExpression.Text = "";
            CurrentResult = "";
        }

        private bool HasTwoNumbers(string expression)
        {
            // Split on operators
            string[] parts = expression.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);

            return parts.Length >= 2; // we need at least 2 numbers
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            // For the buttons of division and multiplication cause otherwise it will give error
            if (button.Text == "÷")
            {
                CurrentResult += "/";
            }
            else if (button.Text == "x")
            {
                CurrentResult += "*";
            }
            else
            {
                CurrentResult += button.Text;
            }

            txtDisplay.Text = CurrentResult;
            txtExpression.Text = CurrentResult;
        }

        private void EqualsToButtonClick(object sender, EventArgs e)
        {
            string formattedcalculations = "";
            formattedcalculations = CurrentResult.ToString();    // because to handle expression like 1 + 2

            // Check if we actually have two numbers before computing
            if (!HasTwoNumbers(formattedcalculations))
            {
                MessageBox.Show("Error : Incomplete expression.");
                return;
            }

            try
            {
                // DataTable.Comput() is library which will perform the all calculations.
                var result = new DataTable().Compute(formattedcalculations, null).ToString();
                txtDisplay.Text = result;
                txtExpression.Text = result;
                CurrentResult = result;    // store the result for next calculations
            }
            catch(Exception exception)
            {
                DisplayErrorMessage();
            }
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            txtExpression.Text = "";
            CurrentResult = "";
        }

        private void ClearEntryButtonClick(object sender, EventArgs e)
        {
            if(CurrentResult.Length > 0)
            {
                CurrentResult = CurrentResult.Remove(CurrentResult.Length - 1, 1);
            }

            txtDisplay.Text = CurrentResult;    // Empty text
        }

        private void ReciprocalButtonClick(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(txtDisplay.Text);
                
                if(num != 0)
                {
                    double result = 1 / num;
                    txtDisplay.Text = result.ToString();
                    txtExpression.Text = "1/(" + num + ")";
                    CurrentResult = result.ToString();
                }
                else
                {
                    DisplayErrorMessage();
                }
            }
            catch
            {
                DisplayErrorMessage();
            }
        }

        private void SquareButtonClick(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(txtDisplay.Text);
                double result = Math.Pow(num, 2);    // squares the number
                txtDisplay.Text = result.ToString();
                txtExpression.Text = "(" + num + ")²";
                CurrentResult = result.ToString();
            }
            catch(Exception exception)
            {
                DisplayErrorMessage();
            }
        }

        private void SquareRootButtonClick(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(txtDisplay.Text);
                if(num > 0)
                {
                    double result = Math.Sqrt(num);
                    txtDisplay.Text = result.ToString();
                    txtExpression.Text = "?(" + num + ")";
                    CurrentResult = result.ToString();
                }
                else
                {
                    txtDisplay.Text = "";
                    MessageBox.Show("Number should be greater than 0 to caluculate square root.");
                    txtExpression.Text = "";
                    CurrentResult = "";
                }
            }
            catch (Exception exception)
            {
                DisplayErrorMessage();
            }
        }

        private void PositiveNegativeButttonClick(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(txtDisplay.Text);
                num = -num;
                txtDisplay.Text = num.ToString();
                txtExpression.Text = num.ToString();
                CurrentResult = num.ToString();
            }
            catch(Exception exception)
            {
                DisplayErrorMessage();
            }
        }

        private void PercentageButtonClick(object sender, EventArgs e)
        {
           try
            {
                double num = Convert.ToDouble(txtDisplay.Text);
                double result = (num / 100);
                txtDisplay.Text = result.ToString();
                txtExpression.Text = "(" + num + "%)";
                CurrentResult = result.ToString();
            }
            catch(Exception exception)
            {
                DisplayErrorMessage();
            }
        }
    }
}
