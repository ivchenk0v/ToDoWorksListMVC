using ToDoWorksListMVC.Models;

namespace ToDoWorksListMVC.Services
{
    public interface IToDoListService
    {
        public List<ToDoItem> GetToDoList();
        public ToDoItem? GetToDoItem(int id);
        public void UpdToDoItem(int id, ToDoItem toDoItem);
        public void AddItemToDoList(string name);
        public void DelItemToDoList(int id);
    }
}
