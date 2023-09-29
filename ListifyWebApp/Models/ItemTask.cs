using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListifyWebApp.Models
{
    [Table("Task")]
    public class ItemTask
    {
        [Key]
        public int Id { get; set; }
        public string TaskDescription { get; set; }

        
    }
}
