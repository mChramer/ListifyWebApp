using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ListifyClient
{
    public class EditListify
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }


        public EditListify(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public EditListify()
        {
            
        }
    }

        

    //denna klassen används för att "hålla" värdena som du vill
    //ta med och ändra i PUT();
}
