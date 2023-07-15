using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using ToDoListApp.Base;
using ToDoListApp.Interfaces;
using ToDoListApp.Model;
using ToDoListApp.View;

namespace ToDoListApp.ViewModel
{
    public class MainViewModel : ViewModelBase, IFileService
    {
        private AddToDoTaskView addTaskView;
        private ToDoTask selectedTask;

        public ToDoTask SelectedTask { get => selectedTask; set => OnPropertyChanged(out selectedTask, value); }
        public ObservableCollection<ToDoTask> TasksCollection { get; set; }

        private static string filePath = "tasks.json";

        public MainViewModel()
        {
            var tasks = LoadTasks();
            if (tasks == null)
            {
                TasksCollection = new ObservableCollection<ToDoTask>();
            }
            else
            {
                TasksCollection = new ObservableCollection<ToDoTask>(tasks);
            }
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

        public IEnumerable<ToDoTask> LoadTasks()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var tasks = JsonSerializer.Deserialize<IEnumerable<ToDoTask>>(json);
                return tasks;
            }

            return Enumerable.Empty<ToDoTask>();    
        }

        public void SaveTasks()
        {
            var json = JsonSerializer.Serialize(TasksCollection);
            File.WriteAllText(filePath, json);
        }
    }
}
