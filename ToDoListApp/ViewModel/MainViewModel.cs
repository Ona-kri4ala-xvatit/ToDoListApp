using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Base;
using ToDoListApp.Model;
using ToDoListApp.View;

namespace ToDoListApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private AddToDoTaskView addTaskView;
        public ObservableCollection<ToDoTask> TasksCollection { get; set; }
        public ObservableCollection<ToDoTask> tttasksCollection;
        public MainViewModel()
        {

            TasksCollection = new ObservableCollection<ToDoTask>();
        }

        public void OpenSecondForm()
        {
            addTaskView = new AddToDoTaskView(TasksCollection);
            addTaskView.ShowDialog();
        }

        public void RemoveTask(int index)
        {
            if (TasksCollection.Count != 0 && index != -1)
            {
                TasksCollection.RemoveAt(index);
            }
        }
    }
}
