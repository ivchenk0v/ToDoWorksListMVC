using ToDoWorksListMVC.Models;

namespace ToDoWorksListMVC.Services
{
    public class ToDoListService : IToDoListService
    {
        private List<ToDoItem> ToDoItemsList;
        public ToDoListService()
        {
            ToDoItemsList = [
                new() { Id = 1, Name = "Создать веб-приложение", IsDone = true, Email = "AliceSmith@email.com" },
                new() { Id = 2, Name = "Создать сервис списка дел", IsDone = true, Email = "AliceSmith@email.com"  },
                new() { Id = 3, Name = "Создание моделей", IsDone = true, Email = "AliceSmith@email.com"  },
                new() { Id = 4, Name = "Использовать при создании списка дел четыре метода", Email = "AliceSmith@email.com"  },
                new() { Id = 5, Name = "Создать контроллер ToDoController, добавить методы", Email = "AliceSmith@email.com"  },
                new() { Id = 6, Name = "Создать IdentityServer", IsDone = true, Email = "BobSmith@email.com" },
                new() { Id = 7, Name = "Обновить созданный IdentityServer", IsDone = true, Email = "BobSmith@email.com"  },
                new() { Id = 8, Name = "Добавить аутентификацию в приложение", IsDone = true, Email = "BobSmith@email.com"  },
                new() { Id = 9, Name = "Добавить аутентификацию для контроллера ToDo", Email = "BobSmith@email.com"  },
                new() { Id = 10, Name = "Обновить модель элемента списка дел", Email = "BobSmith@email.com"  },
                new() { Id = 11, Name = "Обновить сервис списка дел", Email = "BobSmith@email.com"  },
                new() { Id = 12, Name = "Обновить контроллер ToDo", Email = "BobSmith@email.com"  }
            ];
        }
        public List<ToDoItem> GetToDoList(string email) => ToDoItemsList.Where(x => x.Email == email).ToList();
        public ToDoItem? GetToDoItem(int id) => ToDoItemsList.FirstOrDefault(x => x.Id == id);
        public void UpdToDoItem(int id, ToDoItem toDoItem)
        {
            var item = ToDoItemsList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Name = toDoItem.Name;
                item.IsDone = toDoItem.IsDone;
                item.Email = toDoItem.Email;
            }
        }
        public void AddItemToDoList(string name, string email) => ToDoItemsList.Add(new() { Id = ToDoItemsList.Max(x => x.Id) + 1, Name = name, Email = email });
        public void DelItemToDoList(int id) => ToDoItemsList.RemoveAll(x => x.Id == id);
    }
}
