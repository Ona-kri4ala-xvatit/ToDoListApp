using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Controls;
using ToDoListApp.Base;
using ToDoListApp.Interfaces;
using ToDoListApp.Model;
using ToDoListApp.View;

namespace ToDoListApp.ViewModel
{
    public class MainViewModel : ViewModelBase, IFileService
    {
        private AddToDoTaskView? addTaskView;
        private ToDoTask? selectedTask;

        public ToDoTask? SelectedTask { get => selectedTask; set => OnPropertyChanged(out selectedTask, value); }
        public ObservableCollection<ToDoTask> TasksCollection { get; set; }

        private const string jsonFilePath = "tasks.json";

        public MainViewModel()
        {
            var tasks = LoadTasks();
            TasksCollection = new ObservableCollection<ToDoTask>(tasks);
        }

        public void OpenAddTaskView()
        {
            addTaskView = new AddToDoTaskView(TasksCollection);
            addTaskView.ShowDialog();
        }

        public void RemoveTask()
        {
            TasksCollection?.Remove(selectedTask!);
        }

        public IEnumerable<ToDoTask> LoadTasks()
        {
            if (!File.Exists(jsonFilePath))
            {
                return Enumerable.Empty<ToDoTask>();
            }

            var json = File.ReadAllText(jsonFilePath);
            var tasks = JsonSerializer.Deserialize<IEnumerable<ToDoTask>>(json);
            return tasks!;
        }

        public void SaveTasks()
        {
            var json = JsonSerializer.Serialize(TasksCollection);
            File.WriteAllText(jsonFilePath, json);
        }

        public void SortTasks(ListBox listBox)
        {
            if (TasksCollection.Count != 0)
            {
                ICollectionView listBoxView = listBox.Items;              
                listBoxView.SortDescriptions.Add(new SortDescription(nameof(ToDoTask.IsDone), ListSortDirection.Descending));
            }
        }
    }
}
