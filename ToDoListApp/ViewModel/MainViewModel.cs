using System.Collections.ObjectModel;
using ToDoListApp.Base;
using ToDoListApp.Model;
using ToDoListApp.View;

namespace ToDoListApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private AddToDoTaskView addTaskView;
        private ToDoTask selectedTask;

        public ToDoTask SelectedTask { get => selectedTask; set => OnPropertyChanged(out selectedTask, value); }
        public ObservableCollection<ToDoTask> TasksCollection { get; set; }
        public MainViewModel()
        {

            TasksCollection = new ObservableCollection<ToDoTask>();
        }

        public void OpenSecondForm()
        {
            addTaskView = new AddToDoTaskView(TasksCollection);
            addTaskView.ShowDialog();
        }

        public void RemoveTask()
        {
            if (SelectedTask != null)
            {
                TasksCollection.Remove(selectedTask);
            }
        }
    }
}
