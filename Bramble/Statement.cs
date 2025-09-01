public class Statement
{
    public string[] fullStatement { get; set; }
    public string[] header { get; set; }
    public string[] body { get; set; }
    public Statement(string statementRaw)
    {
        fullStatement = statementRaw.Split("\n");
        header = fullStatement[..5];
        body = fullStatement[5..];
    }
    public DateTime[] GetDates(bool debug = false)
    {
        DateTime[] dates = new DateTime[body.Length];

        for (int i = 0; i < body.Count(); i++)
        {
            DateTime date;

            try
            {
                DateTime.TryParse(body[i][1..12], out date);
                dates[i] = date;

                if (debug)
                {
                    Console.WriteLine(date + ", index: " + i);
                }
            }
            catch
            {
                Console.WriteLine("Couldn't parse date at index " + i);
                dates[i] = DateTime.MaxValue;
            }
        }

        return dates;
    }

    public string[] GetTypes(bool debug = false)
    {
        string[] types = new string[body.Length];

        for (int i = 0; i < body.Count(); i++)
        {
            types[i] = body[i].Split(",")[1];

            if (debug)
            {
                Console.WriteLine(body[i].Split(",")[1] + ", index: " + i);
            }
        }

        return types;
    }

    public string[] GetDescriptions(bool debug = false)
    {
        string[] descriptions = new string[body.Length];

        for (int i = 0; i < body.Count(); i++)
        {
            descriptions[i] = body[i].Split(",")[2];

            if (debug)
            {
                Console.WriteLine(body[i].Split(",")[2] + ", index: " + i);
            }
        }

        return descriptions;
    }

    public double[] GetDoubles(int doubleIndex, bool debug = false)
    {
        /* 
        doubleIndex:
            0 == paidOut
            1 == paidIn
            2 == balance
        */

        double[] doubles = new double[body.Length];

        for (int i = 0; i < body.Count(); i++)
        {
            double doubl;

            if (body[i].Split(',')[3 + doubleIndex] == "\"\"")
            {
                doubl = 0;
            }
            else
            {
                doubl = Convert.ToDouble(body[i].Split(',')[3 + doubleIndex][2..^1].Trim('\"'));
            }

            if (debug)
            {
                Console.WriteLine(doubl + ", index: " + i);
            }

            doubles[i] = doubl;
        }

        return doubles;
    }       
}   