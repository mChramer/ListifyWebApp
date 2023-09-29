using ListifyWebApp.DataAccess;
using ListifyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListifyWebApp.Pages
{

    
    public class Page2Model : PageModel
    {
        DatabaseContext db;

        public Page2Model(DatabaseContext db)
        {
            this.db = db;
        }

        
        [BindProperty]
        public Listify listify { get; set; }

        [BindProperty]
        public string taskDescription { get; set; }
        public List<ItemTask> items { get; set; } = new List<ItemTask>(); 

        public void OnGet()
        {
        
        }
       
        public IActionResult OnPostAddListify(string[] task)
        {

            for (int i = 0; i < task.Length; i++)
            {
                ItemTask itemTask = new ItemTask()
                {
                    TaskDescription = task[i]
                };

                items.Add(itemTask);

            }
            listify.tasks = items;
            db.Listify.Add(listify);
            for (int i = 0; i < items.Count; i++)
            {
                db.Task.Add(items[i]);
            } 
            db.SaveChanges();
            return RedirectToPage("Page3");
        }
    }
}
