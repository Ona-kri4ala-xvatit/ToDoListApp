using System.Collections.Generic;
using ToDoListApp.Model;

namespace ToDoListApp.Interfaces
{
    public interface IFileService
    {
        IEnumerable<ToDoTask> LoadTasks();
        void SaveTasks();
    }
}
