using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    /// Interaction logic for ListAllWindow.xaml
    /// </summary>
    public partial class ListAllWindow : Window
    {
        private ModuleList localStore;
        public ListAllWindow(ModuleList store)
        {
            InitializeComponent();
            localStore = store;
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // dataGrid.ItemsSource = localStore.List;
            foreach (Student s in localStore.List)
            {
                dataGrid.Items.Add(s);
            }
            //dataGrid.Items.Add(localStore.find(localStore.matrics.Max()));
        }
    }
}
