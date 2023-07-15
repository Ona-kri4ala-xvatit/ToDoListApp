using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
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

        private void LoadTasks_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoadTasks();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            viewModel.SaveTasks();
        }
    }
}
