using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace ListifyWebApp.Models
{
    [Table("Listify")]
    public class Listify
    {

        [Key] /*BLIR PRIMARYKEY*/
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<ItemTask> tasks { get; set; }

    }
}
