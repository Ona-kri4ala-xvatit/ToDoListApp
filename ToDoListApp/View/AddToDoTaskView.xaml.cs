using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
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
            this.Close();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
