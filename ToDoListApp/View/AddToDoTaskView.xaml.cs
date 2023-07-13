using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ToDoListApp.Model;
using ToDoListApp.ViewModel;

namespace ToDoListApp.View
{
    public partial class AddToDoTaskView : Window
    {
        private AddToDoTaskViewModel viewModel;
        public ObservableCollection<ToDoTask> taskCollection;
        public AddToDoTaskView(ObservableCollection<ToDoTask> tasksCollection)
        {
            InitializeComponent();
            this.taskCollection = tasksCollection;
            viewModel = new AddToDoTaskViewModel(taskCollection);
            DataContext = viewModel;
        }

        private void DragAddToDoTaskView(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            viewModel.AddTask();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
