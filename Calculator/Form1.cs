using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{


    /// <summary>
    /// A basic calculator
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion


        #region Clearing Methods

        /// <summary>
        /// Clears The User input Text
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event argument</param>
        private void CEButton_Click(object sender, EventArgs e)
        {
            //Clears the text from the user input text box
            this.UserInputText.Text = string.Empty;

            //Focus on the user input
            FocusInputText();
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            //Delete the value after the selected position
            DeleteTextValue();

            //Focus on the user input
            FocusInputText();
        }

        #endregion


        #region Operator Methods

        private void DivideButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
            //Focus on the user input
            FocusInputText();
        }

        private void TimesButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
            //Focus on the user input
            FocusInputText();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
            //Focus on the user input
            FocusInputText();
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
            //Focus on the user input
            FocusInputText();
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            CalculateEquation();
            //Focus on the user input
            FocusInputText();
        }

        #endregion


        #region Number Methods

        private void NineButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
            //Focus on the user input
            FocusInputText();
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
            //Focus on the user input
            FocusInputText();
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
            //Focus on the user input
            FocusInputText();
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
            //Focus on the user input
            FocusInputText();
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
            //Focus on the user input
            FocusInputText();
        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
            //Focus on the user input
            FocusInputText();
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
            //Focus on the user input
            FocusInputText();
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
            //Focus on the user input
            FocusInputText();
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
            //Focus on the user input
            FocusInputText();
        }


        private void DotButton_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
            //Focus on the user input
            FocusInputText();
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");
            //Focus on the user input
            FocusInputText();
        }



        #endregion

        #region Private Helpers
        /// <summary>
        /// Focuses the user Input After the click of a button
        /// </summary>
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }

        /// <summary>
        /// inserts the number inputed
        /// </summary>
        /// <param name="number">number inputed</param>
        private void InsertTextValue(string number)
        {
            //Remember Selection Start
            var selectionStart = this.UserInputText.SelectionStart;

            //Set New text
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, number);

            //Restore the selection start
            this.UserInputText.SelectionStart = selectionStart + number.Length;

            //Set selection length to zero
            this.UserInputText.SelectionLength = 0;

        }

        private void DeleteTextValue()
        {
            if (this.UserInputText.Text.Length == 0)
                return;

            //Remember Selection Start
            var selectionStart = this.UserInputText.SelectionStart;

            //Delete the char to the right of the selection
            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart - 1, 1);

            //Restore the selection start
            this.UserInputText.SelectionStart = selectionStart;

            //Set selection length to zero
            this.UserInputText.SelectionLength = 0;

        }


        /// <summary>
        /// Calculates the equation
        /// </summary>

        #endregion
        private void CalculateEquation()
        {

            this.CalculationResultText.Text = ParseOperation();

        }

        /// <summary>
        /// Passes the user input and calculate the result
        /// </summary>
        /// <returns></returns>
        private string ParseOperation()
        {
            try
            {
                //Get the Equation input
                var input = this.UserInputText.Text;

                //Remove all Spaces
                input = input.Replace(" ", "");

                //Create new top level operation
                var operation = new Operation();
                var leftside = true;

                for (int i = 0; i < input.Length; i++)
                {
                    //Todo: Handle order priority

                    if ("0123456789.".Any(c => input[i] == c))
                    {
                        if (leftside)
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                    }
                }

                return string.Empty;
            }
            catch (Exception e)
            {
                return $"Invalid equation {e.Message}";
            }
        }

        private string AddNumberPart(string currentNumber, char newCharacter)
        {
            if (newCharacter == '.' && currentNumber.Contains("."))
                throw new InvalidOperationException($"Number {currentNumber} already contains a dot and another cannot be added");

            return currentNumber + newCharacter;
        }
    }
}
