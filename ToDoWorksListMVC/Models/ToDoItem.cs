using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ToDoWorksListMVC.Models
{
    public class ToDoItem
    {
        [Display(Name = "Номер задачи")]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public required string Name { get; set; }
        [Display(Name = "Признак завершенности")]
        public bool IsDone { get; set; } = false;
    }
}
