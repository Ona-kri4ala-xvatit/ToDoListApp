using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoListApp.ViewModel;

namespace ToDoListApp.View
{
    public partial class MainView : Window
    {
        private MainViewModel viewModel;
        
        public MainView()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            DataContext = viewModel;
        }

        private void DragMainView(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OpenAddTaskForm(object sender, RoutedEventArgs e)
        {
            viewModel.OpenSecondForm();
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveTask();
        }
    }
}
