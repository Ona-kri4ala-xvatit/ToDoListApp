using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Base;
using ToDoListApp.Model;

namespace ToDoListApp.ViewModel
{
    public class AddToDoTaskViewModel : ViewModelBase
    { 
        private readonly ObservableCollection<ToDoTask>? taskColection;
        
        private string? taskTitle;
        private string? taskDescription;
        private bool taskIsComplited;
        private DateTime taskDeadline = DateTime.Now;

        public string? TaskTitle { get => taskTitle; set => OnPropertyChanged(out taskTitle, value); }
        public string? TaskDescription { get => taskDescription; set => OnPropertyChanged(out taskDescription, value); }
        public DateTime TaskDeadline { get => taskDeadline; set => OnPropertyChanged(out taskDeadline, value); }
        public bool TaskIsComplited { get => taskIsComplited; set => OnPropertyChanged(out taskIsComplited, value); }

       

        public AddToDoTaskViewModel() { }
        public AddToDoTaskViewModel(ObservableCollection<ToDoTask>? taskColection)
        {
            this.taskColection = taskColection;
        }
        
        

        public void AddTask()
        {
            taskColection?.Add(new ToDoTask
            {
                Title = TaskTitle,
                Description = TaskDescription,
                Deadline = TaskDeadline,
                IsCompleted = TaskIsComplited
            });

            Clear();
        }

        public void Clear()
        {
            TaskTitle = string.Empty;
            TaskDescription = string.Empty;
            TaskDeadline = DateTime.Now;
            TaskIsComplited = false;
        }


        
    }
}
