using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Model;
using ToDoListApp.View;

namespace ToDoListApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //public ToDoTask? ToDoTask { get; set; }
        private AddToDoTaskView addTaskView;
        public AddToDoTaskViewModel? addTaskViewModel;
        public ObservableCollection<ToDoTask> TasksCollection { get; set; }
        public MainViewModel()
        {
            TasksCollection = new ObservableCollection<ToDoTask>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OpenSecondForm()
        {
            addTaskView = new AddToDoTaskView(TasksCollection);
            addTaskView.ShowDialog();
        }
    }
}
