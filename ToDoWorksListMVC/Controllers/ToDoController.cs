using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoWorksListMVC.Models;
using ToDoWorksListMVC.Services;

namespace ToDoWorksListMVC.Controllers
{
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
            return View(_toDoList.GetToDoList());
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
                var newItem =  collection["Name"].ToString();
                _toDoList.AddItemToDoList(newItem);
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
                var editItem = new ToDoItem { Id = Convert.ToInt32(collection["Id"]), Name = collection["Name"].ToString(), IsDone = collection["IsDone"].ToArray()[0] == "true" };
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
