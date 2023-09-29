using ListifyWebApp.DataAccess;
using ListifyWebApp.Models;
using ListifyWebApp.Pages.Viewholder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ListifyWebApp.Controllers
{
    [Route("api/Listify")]
    [ApiController]
    public class ListifyController : ControllerBase
    {
        DatabaseContext db;

        public ListifyController(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        [HttpGet]
        public List<Listify> GetListify()
        {
            return db.Listify.ToList();
        }

        [Route("PostList")]
        [HttpPost]
        public void PostListify([FromBody] Listify listify)
        {
            db.Listify.Add(listify);

            for (int i = 0; i < listify.tasks.Count; i++)
            {
                db.Task.Add(listify.tasks[i]);
            }

            db.SaveChanges();
        }

        [Route("GetListifyById")]
        [HttpGet]
        public ActionResult<Listify> GetListifyById(int id)
        {

            Listify listify = db.Listify.Include(l => l.tasks).SingleOrDefault(l => l.Id == id);
            return listify;

        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public ActionResult DeleteListifyById(int id)
        {
            Listify listify = db.Listify.Include(l => l.tasks).SingleOrDefault(l => l.Id == id);
            if (listify != null)
            {
                // Remove associated tasks first
                foreach (var task in listify.tasks)
                {
                    db.Task.Remove(task);
                }

                // Then remove the listify entity
                db.Listify.Remove(listify);
                db.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

 
        [HttpPut("update")]
        public async Task<IActionResult> EditListify( int id, EditListify editListify)
        {
            var input = await db.Listify.FindAsync(id);
            if(input.Id != null)
            {
                input.Name = editListify.Name;

                await db.SaveChangesAsync();
                return Ok(input);
            }
            return BadRequest();
                       
        }

    }
}
