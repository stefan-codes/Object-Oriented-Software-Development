using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private MainWindow _mainWindow;

        public AddStudent()
        {
            InitializeComponent();
        }

        public AddStudent(MainWindow mainWindow):this()
        {

            // TODO: Complete member initialization
            _mainWindow = mainWindow;
            Console.WriteLine("123213");
        }

        private void ClosingWindow(object sender, CancelEventArgs e)
        {
            Console.WriteLine("kkloki");
            _mainWindow.Show();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
