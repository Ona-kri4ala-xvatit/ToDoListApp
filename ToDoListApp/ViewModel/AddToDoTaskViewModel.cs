using System;
using System.Collections.ObjectModel;
using ToDoListApp.Base;
using ToDoListApp.Model;

namespace ToDoListApp.ViewModel
{
    public class AddToDoTaskViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ToDoTask>? taskColection;

        private string? taskTitle;
        private string? taskDescription;
        private bool taskIsDone;
        private DateTime taskDeadline = DateTime.Now;

        public string? TaskTitle { get => taskTitle; set => OnPropertyChanged(out taskTitle, value); }
        public string? TaskDescription { get => taskDescription; set => OnPropertyChanged(out taskDescription, value); }
        public DateTime TaskDeadline { get => taskDeadline; set => OnPropertyChanged(out taskDeadline, value); }
        public bool TaskIsDone { get => taskIsDone; set => OnPropertyChanged(out taskIsDone, value); }

        public AddToDoTaskViewModel() { }
        public AddToDoTaskViewModel(ObservableCollection<ToDoTask>? taskColection)
        {
            this.taskColection = taskColection;
        }
        public void Clear()
        {
            TaskTitle = string.Empty;
            TaskDescription = string.Empty;
            TaskDeadline = DateTime.Now;
            TaskIsDone = false;
        }

        public void AddTask()
        {
            taskColection?.Add(new ToDoTask
            {
                Title = TaskTitle,
                Description = TaskDescription,
                Deadline = TaskDeadline,
                IsDone = TaskIsDone
            });

            Clear();
        }
    }
}
