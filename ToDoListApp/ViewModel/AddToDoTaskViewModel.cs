using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Model;

namespace ToDoListApp.ViewModel
{
    public class AddToDoTaskViewModel : INotifyPropertyChanged
    { 
        private string taskTitle;
        private string taskDescription;
        private bool taskIsComplited;
        private DateTime taskDeadline;

        public string TaskTitle { get => taskTitle; set => OnPropertyChanged(out taskTitle, value); }
        public string TaskDescription { get => taskDescription; set => OnPropertyChanged(out taskDescription, value); }
        public DateTime TaskDeadline { get => taskDeadline; set => OnPropertyChanged(out taskDeadline, value); }
        public bool TaskIsComplited { get => taskIsComplited; set => OnPropertyChanged(out taskIsComplited, value); }

        public event PropertyChangedEventHandler? PropertyChanged;
        private ToDoTask ToDoTaskModel = new ToDoTask();

        private readonly ObservableCollection<ToDoTask>? taskColection;
        public AddToDoTaskViewModel() { }
        public AddToDoTaskViewModel(ObservableCollection<ToDoTask>? taskColection)
        {
            this.taskColection = taskColection;
            
        }
        
        public void OnPropertyChanged<T>(out T prop, T value, [CallerMemberName] string? propName = null)
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void AddTask()
        {
            taskColection.Add(new ToDoTask
            {
                Title = TaskTitle,
                Description = TaskDescription,
                Deadline = TaskDeadline,
                IsCompleted = TaskIsComplited
            });

        }

        
    }
}
