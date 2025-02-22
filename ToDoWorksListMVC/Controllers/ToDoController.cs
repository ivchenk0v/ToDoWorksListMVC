using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoWorksListMVC.Models;
using ToDoWorksListMVC.Services;

namespace ToDoWorksListMVC.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoListService _toDoList;

        public ToDoController(ILogger<ToDoController> logger, IToDoListService toDoList)
        {
            _logger = logger;
            _toDoList = toDoList;
        }
        // GET: ToDoController
        public ActionResult Index()
        {
            var email = User.FindFirst("email")?.Value;
            return View(_toDoList.GetToDoList(email));
        }

        // GET: ToDoController/Details/5
        public ActionResult Details(int id)
        {
            return View(_toDoList.GetToDoItem(id));
        }

        // GET: ToDoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newName =  collection["Name"].ToString();
                //var newEmail = collection["Email"].ToString();
                var newEmail = User.FindFirst("email")?.Value;
                _toDoList.AddItemToDoList(newName, newEmail);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_toDoList.GetToDoItem(id));
        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var editItem = new ToDoItem { Id = Convert.ToInt32(collection["Id"]), Name = collection["Name"].ToString(), IsDone = collection["IsDone"].ToArray()[0] == "true", Email = collection["Email"].ToString() };
                _toDoList.UpdToDoItem(id, editItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_toDoList.GetToDoItem(id));
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _toDoList.DelItemToDoList(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
