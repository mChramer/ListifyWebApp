namespace ListifyClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListifyMenu output = new ListifyMenu(new RequestHandler());
            

            while (true) 
            {
                
                output.DisplayMenu();
                
            }         
        }
    }
}