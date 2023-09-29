

using System.Text;
using System.Text.Json;
namespace ListifyClient


{
    public class RequestHandler
    {
        public RequestHandler()
        {

        }
        public void Get()
        {
            Console.WriteLine("Please write the id of the list you want:");
            string id = Console.ReadLine();

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7277/api/Listify/GetListifyById?id=" + id);

            HttpResponseMessage response = client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Statuscode: {(int)response.StatusCode} with response: {response.StatusCode}.");
                string json = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json);
                var listify = JsonSerializer.Deserialize<Listify>(json);
                
                Console.WriteLine();
                Console.WriteLine($"List name: {listify.Name}");
                
                foreach( var task in listify.tasks) 
                {
                    Console.WriteLine(task); 
                }

            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }
        }
        public void Post()
        {
            Console.WriteLine("What's the name of the list?");
            string listName = Console.ReadLine();

            var listify = new Listify() { Name = listName };
            List<ItemTask> itemTask = new List<ItemTask>();

            string task;
            ItemTask addedTask;
            string input;

            while (true)
            {
                Console.WriteLine("Press q anytime to quit");
                Console.WriteLine("Add task: ");
                input = Console.ReadLine();
                if (input.ToLower().Equals("q"))
                    break;

                addedTask = new ItemTask() { TaskDescription = input };
                itemTask.Add(addedTask);

            }

            listify.tasks = itemTask;

            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:7277/api/Listify/PostList");

            string json = System.Text.Json.JsonSerializer.Serialize(listify);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync(uri, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Statuscode: {(int)response.StatusCode} with response: {response.StatusCode} - List: {listify.Name} successfully registered!");
            }
            else
            {
                Console.WriteLine("Post failed. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }
        }
        public void Put()
        {
            Console.WriteLine("What is the id nr of the list you want to update?");
            int listIdInt = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new name for the list:");
            string newListName = Console.ReadLine();

            var listify = new EditListify() { Id = listIdInt, Name = newListName };

            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("https://localhost:7277/api/Listify/update?id=" + listIdInt);

            string json = System.Text.Json.JsonSerializer.Serialize(listify);
            Console.WriteLine(json); //skriver ut listan i json

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync(uri, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Statuscode: {(int)response.StatusCode} with response: {response.StatusCode} - {listify.Name} updated!");
            }
            else
            {
                Console.WriteLine("Put failed. Status Code " + (int)response.StatusCode + ": " + response.StatusCode);
            }

        }
        public void Delete()
        {
            Console.WriteLine("Please write the id nr of the list you want to delete.");
            string listId = Console.ReadLine();

            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://localhost:7277/api/Listify/Delete/" + listId);

            HttpResponseMessage response = client.DeleteAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Statuscode: {(int)response.StatusCode} with response: {response.StatusCode} - List with id {listId} successfully deleted.");
            }
            else
            {
                Console.WriteLine("Error. " + response.ReasonPhrase);
            }

        }
    }
        
}

