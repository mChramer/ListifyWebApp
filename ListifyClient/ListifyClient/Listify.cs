using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ListifyClient
{
    public class Listify 
    {
        [Key]

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tasks")]
        public List<ItemTask>? tasks { get; set; }

        public Listify(int id, string name)
        {
            Id = id;
            Name = name;
            tasks = new List<ItemTask>();
        }
        public Listify()
        {
            
        }

       
    }

    public class ItemTask 
    {
        [Key]

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("taskDescription")]
        public string TaskDescription { get; set; }

        public ItemTask()
        {

        }
        public ItemTask(int id, string taskDescription)
        {
            Id = id;
            TaskDescription = taskDescription;

        }
        public override string ToString()
        {
            return $"Task: {TaskDescription}";
        }
    }
}
