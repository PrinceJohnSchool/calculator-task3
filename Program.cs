// Import necessary namespaces for the application entry point
using System;              // Provides fundamental types and base classes
using System.Windows.Forms; // Provides Windows Forms application framework

namespace CalculatorApp
{
    /// <summary>
    /// Main entry point class for the Calculator application.
    /// Initializes the Windows Forms application and starts the calculator form.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Configures Windows Forms settings and launches the calculator form.
        /// </summary>
        [STAThread]  // Required for Windows Forms applications - Single Threaded Apartment
        static void Main()
        {
            // Enable visual styles for modern Windows appearance
            Application.EnableVisualStyles();
            // Use GDI+ text rendering for better text quality
            Application.SetCompatibleTextRenderingDefault(false);
            // Create and run the calculator form (this starts the application)
            Application.Run(new CalculatorForm());
        }
    }
}
