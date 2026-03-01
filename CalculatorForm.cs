// Import necessary namespaces for the calculator application
using System;              // Provides fundamental types and base classes
using System.Drawing;       // Provides graphics and drawing functionality (Point, Size, Color, Font)
using System.Windows.Forms; // Provides Windows Forms controls (Form, TextBox, Button, Label)

namespace CalculatorApp
{
    /// <summary>
    /// Main form class for the Simple Calculator application.
    /// Provides a Windows Forms interface for performing basic arithmetic operations
    /// (addition, subtraction, multiplication, and division) on two numbers.
    /// </summary>
    public partial class CalculatorForm : Form
    {
        // UI Controls - Input fields for the two numbers
        private TextBox number1TextBox;  // Text box for entering the first number
        private TextBox number2TextBox;  // Text box for entering the second number
        
        // UI Controls - Operation buttons
        private Button addButton;         // Button to perform addition
        private Button subtractButton;    // Button to perform subtraction
        private Button multiplyButton;    // Button to perform multiplication
        private Button divideButton;      // Button to perform division
        
        // UI Controls - Display
        private Label resultLabel;        // Label to display the calculation result or error messages

        // Data fields to store parsed numbers and calculation results
        private double firstNumber;       // Stores the first number after parsing from number1TextBox
        private double secondNumber;      // Stores the second number after parsing from number2TextBox
        private double calculationResult; // Stores the result of the arithmetic operation

        /// <summary>
        /// Constructor for CalculatorForm. Initializes the form and sets up all UI components.
        /// </summary>
        /// <summary>
        /// Constructor for CalculatorForm. Initializes the form and sets up all UI components.
        /// </summary>
        public CalculatorForm()
        {
            // Call the method that creates and configures all UI controls
            InitializeComponent();
        }

        /// <summary>
        /// Initializes and configures all UI components of the calculator form.
        /// Sets up the form properties, creates input text boxes, operation buttons, and result label.
        /// </summary>
        private void InitializeComponent()
        {
            // Configure the main form window properties
            this.Text = "Simple Calculator";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;  // Center the form on screen
            this.BackColor = Color.LightGray;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;   // Prevent resizing
            this.MaximizeBox = false;  // Disable maximize button
            this.MinimizeBox = true;   // Enable minimize button

            // Create and configure the first number input text box
            number1TextBox = new TextBox();
            number1TextBox.Location = new Point(50, 30);      // X=50 pixels from left, Y=30 pixels from top
            number1TextBox.Size = new Size(150, 25);          // Width=150 pixels, Height=25 pixels
            number1TextBox.Font = new Font("Arial", 12);      // Set font family and size
            number1TextBox.TextAlign = HorizontalAlignment.Center;  // Center-align the text
            number1TextBox.PlaceholderText = "Enter first number";  // Hint text shown when empty
            this.Controls.Add(number1TextBox);  // Add the text box to the form's control collection

            // Create and configure the second number input text box
            number2TextBox = new TextBox();
            number2TextBox.Location = new Point(200, 30);     // Positioned to the right of first text box
            number2TextBox.Size = new Size(150, 25);         // Same size as first text box
            number2TextBox.Font = new Font("Arial", 12);      // Same font as first text box
            number2TextBox.TextAlign = HorizontalAlignment.Center;  // Center-align the text
            number2TextBox.PlaceholderText = "Enter second number";  // Hint text shown when empty
            this.Controls.Add(number2TextBox);  // Add the text box to the form's control collection

            // Create and configure the Addition button
            addButton = new Button();
            addButton.Text = "+";                              // Display the plus symbol
            addButton.Location = new Point(50, 80);           // Position below the input boxes
            addButton.Size = new Size(70, 40);                // Button dimensions
            addButton.Font = new Font("Arial", 16, FontStyle.Bold);  // Large, bold font for visibility
            addButton.BackColor = Color.LightBlue;            // Light blue background
            addButton.ForeColor = Color.DarkBlue;             // Dark blue text color
            addButton.Click += AddButton_Click;               // Attach click event handler (delegate)
            this.Controls.Add(addButton);                     // Add button to form

            // Create and configure the Subtraction button
            subtractButton = new Button();
            subtractButton.Text = "−";                        // Display the minus symbol (Unicode)
            subtractButton.Location = new Point(130, 80);      // Positioned next to addition button
            subtractButton.Size = new Size(70, 40);           // Same size as other buttons
            subtractButton.Font = new Font("Arial", 16, FontStyle.Bold);
            subtractButton.BackColor = Color.LightGreen;      // Light green background
            subtractButton.ForeColor = Color.DarkGreen;       // Dark green text color
            subtractButton.Click += SubtractButton_Click;     // Attach click event handler
            this.Controls.Add(subtractButton);                // Add button to form

            // Create and configure the Multiplication button
            multiplyButton = new Button();
            multiplyButton.Text = "×";                        // Display the multiplication symbol (Unicode)
            multiplyButton.Location = new Point(210, 80);     // Positioned next to subtraction button
            multiplyButton.Size = new Size(70, 40);          // Same size as other buttons
            multiplyButton.Font = new Font("Arial", 16, FontStyle.Bold);
            multiplyButton.BackColor = Color.LightYellow;    // Light yellow background
            multiplyButton.ForeColor = Color.DarkOrange;      // Dark orange text color
            multiplyButton.Click += MultiplyButton_Click;     // Attach click event handler
            this.Controls.Add(multiplyButton);                // Add button to form

            // Create and configure the Division button
            divideButton = new Button();
            divideButton.Text = "÷";                          // Display the division symbol (Unicode)
            divideButton.Location = new Point(290, 80);       // Positioned next to multiplication button
            divideButton.Size = new Size(70, 40);             // Same size as other buttons
            divideButton.Font = new Font("Arial", 16, FontStyle.Bold);
            divideButton.BackColor = Color.LightCoral;        // Light coral background
            divideButton.ForeColor = Color.DarkRed;            // Dark red text color
            divideButton.Click += DivideButton_Click;         // Attach click event handler
            this.Controls.Add(divideButton);                  // Add button to form

            // Create and configure the result display label
            resultLabel = new Label();
            resultLabel.Text = "Result will appear here";     // Initial placeholder text
            resultLabel.Location = new Point(50, 150);        // Position below the buttons
            resultLabel.Size = new Size(300, 30);             // Wide enough to display results
            resultLabel.Font = new Font("Arial", 12, FontStyle.Bold);  // Bold font for emphasis
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;  // Center the text both horizontally and vertically
            resultLabel.BackColor = Color.White;             // White background for contrast
            resultLabel.BorderStyle = BorderStyle.FixedSingle;  // Add border for better visibility
            this.Controls.Add(resultLabel);                   // Add label to form

            // Create and configure the title label at the top of the form
            Label titleLabel = new Label();                   // Local variable (not stored as field)
            titleLabel.Text = "Simple Calculator";            // Application title
            titleLabel.Location = new Point(50, 5);           // Position at the very top
            titleLabel.Size = new Size(300, 20);             // Width spans most of the form
            titleLabel.Font = new Font("Arial", 14, FontStyle.Bold);  // Larger, bold font for title
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;  // Center the title text
            this.Controls.Add(titleLabel);                    // Add title label to form
        }

        /// <summary>
        /// Validates that both input text boxes contain valid numeric values.
        /// Parses the text from both text boxes and stores them in firstNumber and secondNumber.
        /// </summary>
        /// <returns>True if both inputs are valid numbers, false otherwise.</returns>
        private bool ValidateInputs()
        {
            // TryParse attempts to convert the text to a double
            // If successful, it returns true and stores the value in the 'out' parameter
            // If failed, it returns false and the 'out' parameter is set to 0
            if (double.TryParse(number1TextBox.Text, out firstNumber))
            {
                // First number parsed successfully, now validate the second number
                if (double.TryParse(number2TextBox.Text, out secondNumber))
                {
                    // Both numbers are valid - validation successful
                    return true;
                }
                else
                {
                    // Second number is invalid - display error message to user
                    resultLabel.Text = "Error: Second number is invalid. Please enter a valid number.";
                    resultLabel.ForeColor = Color.Red;  // Red color indicates an error
                    return false;  // Validation failed
                }
            }
            else
            {
                // First number is invalid - display error message to user
                resultLabel.Text = "Error: First number is invalid. Please enter a valid number.";
                resultLabel.ForeColor = Color.Red;  // Red color indicates an error
                return false;  // Validation failed
            }
        }

        /// <summary>
        /// Performs addition operation on two numbers.
        /// </summary>
        /// <param name="num1">The first number (augend).</param>
        /// <param name="num2">The second number (addend).</param>
        /// <returns>The sum of num1 and num2.</returns>
        private double PerformAddition(double num1, double num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// Performs subtraction operation on two numbers.
        /// </summary>
        /// <param name="num1">The first number (minuend).</param>
        /// <param name="num2">The second number (subtrahend).</param>
        /// <returns>The difference of num1 and num2 (num1 - num2).</returns>
        private double PerformSubtraction(double num1, double num2)
        {
            return num1 - num2;
        }

        /// <summary>
        /// Performs multiplication operation on two numbers.
        /// </summary>
        /// <param name="num1">The first number (multiplicand).</param>
        /// <param name="num2">The second number (multiplier).</param>
        /// <returns>The product of num1 and num2.</returns>
        private double PerformMultiplication(double num1, double num2)
        {
            return num1 * num2;
        }

        /// <summary>
        /// Performs division operation on two numbers.
        /// Note: Division by zero should be checked before calling this method.
        /// </summary>
        /// <param name="num1">The first number (dividend).</param>
        /// <param name="num2">The second number (divisor).</param>
        /// <returns>The quotient of num1 divided by num2 (num1 / num2).</returns>
        private double PerformDivision(double num1, double num2)
        {
            return num1 / num2;
        }

        /// <summary>
        /// Event handler for the Addition button click.
        /// Validates inputs and performs addition operation, then displays the result.
        /// </summary>
        /// <param name="sender">The object that raised the event (the Add button).</param>
        /// <param name="e">Event arguments.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Validate that both inputs are valid numbers before proceeding
            if (ValidateInputs())
            {
                // Perform addition operation and store the result
                calculationResult = PerformAddition(firstNumber, secondNumber);
                // Display the calculation using string interpolation ($"..." syntax)
                // This creates a formatted string with the numbers and result
                resultLabel.Text = $"Result: {firstNumber} + {secondNumber} = {calculationResult}";
                resultLabel.ForeColor = Color.Black;  // Set text color to black for normal display
            }
            // If validation fails, ValidateInputs() already displays an error message
        }

        /// <summary>
        /// Event handler for the Subtraction button click.
        /// Validates inputs and performs subtraction operation, then displays the result.
        /// </summary>
        /// <param name="sender">The object that raised the event (the Subtract button).</param>
        /// <param name="e">Event arguments.</param>
        private void SubtractButton_Click(object sender, EventArgs e)
        {
            // Validate that both inputs are valid numbers before proceeding
            if (ValidateInputs())
            {
                // Perform subtraction operation and store the result
                calculationResult = PerformSubtraction(firstNumber, secondNumber);
                // Display the calculation using string interpolation
                // Note: Uses Unicode minus symbol (−) instead of hyphen (-) for better appearance
                resultLabel.Text = $"Result: {firstNumber} − {secondNumber} = {calculationResult}";
                resultLabel.ForeColor = Color.Black;  // Set text color to black for normal display
            }
            // If validation fails, ValidateInputs() already displays an error message
        }

        /// <summary>
        /// Event handler for the Multiplication button click.
        /// Validates inputs and performs multiplication operation, then displays the result.
        /// </summary>
        /// <param name="sender">The object that raised the event (the Multiply button).</param>
        /// <param name="e">Event arguments.</param>
        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            // Validate that both inputs are valid numbers before proceeding
            if (ValidateInputs())
            {
                // Perform multiplication operation and store the result
                calculationResult = PerformMultiplication(firstNumber, secondNumber);
                // Display the calculation using string interpolation
                // Note: Uses Unicode multiplication symbol (×) instead of asterisk (*) for better appearance
                resultLabel.Text = $"Result: {firstNumber} × {secondNumber} = {calculationResult}";
                resultLabel.ForeColor = Color.Black;  // Set text color to black for normal display
            }
            // If validation fails, ValidateInputs() already displays an error message
        }

        /// <summary>
        /// Event handler for the Division button click.
        /// Validates inputs, checks for division by zero, performs division operation, then displays the result.
        /// </summary>
        /// <param name="sender">The object that raised the event (the Divide button).</param>
        /// <param name="e">Event arguments.</param>
        private void DivideButton_Click(object sender, EventArgs e)
        {
            // Validate that both inputs are valid numbers before proceeding
            if (ValidateInputs())
            {
                // Special check: Division by zero is mathematically undefined
                // We must prevent this to avoid runtime exceptions
                if (secondNumber == 0)
                {
                    // Display error message for division by zero
                    resultLabel.Text = "Error: Cannot divide by zero. Please enter a non-zero second number.";
                    resultLabel.ForeColor = Color.Red;  // Set text color to red for error indication
                }
                else
                {
                    // Safe to perform division - second number is not zero
                    calculationResult = PerformDivision(firstNumber, secondNumber);
                    // Display the calculation using string interpolation
                    // Note: Uses Unicode division symbol (÷) instead of slash (/) for better appearance
                    resultLabel.Text = $"Result: {firstNumber} ÷ {secondNumber} = {calculationResult}";
                    resultLabel.ForeColor = Color.Black;  // Set text color to black for normal display
                }
            }
            // If validation fails, ValidateInputs() already displays an error message
        }
    }
}
