using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace WpfApp1 
{
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        const int HORZSIZE = 4;
        const int VERTSIZE = 6;

        public MainWindow()
        {
            InitializeComponent();
            CalculateMonitorDiagonal();
        }

        private void CalculateMonitorDiagonal()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);

            if (hdc != IntPtr.Zero)
            {
                try
                {
                    int widthMm = GetDeviceCaps(hdc, HORZSIZE);
                    int heightMm = GetDeviceCaps(hdc, VERTSIZE);

                    double diagonalMm = Math.Sqrt(Math.Pow(widthMm, 2) + Math.Pow(heightMm, 2));

                    double diagonalInches = diagonalMm / 25.4;

                    ResultTextBlock.Text = $"Примерная диагональ монитора:\n{Math.Round(diagonalInches, 1)} дюймов";
                }
                finally
                {
                    ReleaseDC(IntPtr.Zero, hdc);
                }
            }
            else
            {
                ResultTextBlock.Text = "Не удалось получить доступ к данным монитора.";
            }
        }
    }
}