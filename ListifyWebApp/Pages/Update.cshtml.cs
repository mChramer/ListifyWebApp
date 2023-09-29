using ListifyWebApp.DataAccess;
using ListifyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq;

namespace ListifyWebApp.Pages
{
    
    public class UpdateModel : PageModel
    {
        DatabaseContext db;

        [BindProperty]
        public Listify listify { get; set; }

        [BindProperty]
        public List<ItemTask> Tasks { get; set; } = new List<ItemTask>();

        [BindProperty]
        public ItemTask itemTask { get; set; }
        [BindProperty]
        public string info { get; set; }


        public int ListifyId;

        public UpdateModel(DatabaseContext db)
        {
            this.db = db;
           
        }

        public void OnGet(int Id)
        {
            
            ListifyId = Id;
            listify = db.Listify
                     .Include( l => l.tasks)
                     .SingleOrDefault(l => l.Id == Id);
            Tasks = listify.tasks;
            
        }
        public ActionResult OnPostDeleteListify(int Id, string infostring, string saveListify, string deleteListify) 
        {
            if (saveListify != null)
            {
                Listify listify = db.Listify.SingleOrDefault(l => l.Id == Id);
                if (listify != null)
                {
                    listify.Name = infostring;
                    db.Listify.Update(listify);
                    db.SaveChanges();
                    return RedirectToPage("Page3");
                }
            }
            if (deleteListify != null)
            {
                Listify listify = db.Listify.Include(l => l.tasks).SingleOrDefault(l => l.Id == Id);
                if (listify != null)
                {
                    db.Remove(listify);
                    db.SaveChanges();
                }
                return RedirectToPage("Page3");
            }

            return RedirectToPage("Page3");
        }
        public ActionResult OnPost(int id, string info, string save, string delete)
        {
            if (save != null) {
                ItemTask item = db.Task.SingleOrDefault(t => t.Id == id);
                if (item != null)
                {
                    item.TaskDescription = info;
                    db.Task.Update(item);
                    db.SaveChanges();
                    return RedirectToPage("Page3");
                }
            }
            if (delete != null)
            {
                ItemTask item = db.Task.SingleOrDefault(t => t.Id == id);
                if(item != null)
                {
                    db.Remove(item);
                    db.SaveChanges();
                }
                return RedirectToPage("Page3");
            }
            
            return RedirectToPage("Page3");


        }
    }
}
