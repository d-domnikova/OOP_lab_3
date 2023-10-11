class DateModifier
{
 public int calcDiff(string date1, string date2)
    {
        DateTime date_1 = DateTime.Parse(date1);
        DateTime date_2 = DateTime.Parse(date2);
        TimeSpan interval = date_2 - date_1;
        return Math.Abs(interval.Days);
    }
}

class Workspace
{
    static void Main(string[] args)
    {
        string date1 = Console.ReadLine();
        string date2 = Console.ReadLine();

        DateModifier dateModifier = new DateModifier();
        Console.WriteLine(dateModifier.calcDiff(date1, date2));

    }
}