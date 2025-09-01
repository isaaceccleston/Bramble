public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            using (StreamReader sr = new StreamReader("/Users/isaaceccleston/Documents/Bramble/Statement Download 2025-Sep-01 15-27-25.csv"))
            {
                Statement statement = new Statement(sr.ReadToEnd());
                
                // statement.GetDates();
                // statement.GetTypes();
                // statement.GetDescriptions();
                // statement.GetDoubles(0);
                // statement.GetDoubles(1);
                // statement.GetDoubles(2);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Couldn't read file" + "\n" + e.Message);
        }
    }
}