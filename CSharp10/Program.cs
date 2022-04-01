namespace CSharp10;

public class Program
{
    static void Main(string[] args)
    {
        //file scoped namespaces
        //global usings
        //implicit using statements
        var list = new List<string>() { "Book", "Desk", "Keyboard" };
        var another = list.Select(x => x.ToUpper());
        var now = DateTime.UtcNow;

        //var obj = JsonSerializer.Serialize(list);

        Thread.Sleep(100);

        //Console.WriteLine(obj);

        //\obj\Debug\net6.0\CSharp10.GlobalUsings.g

        var func = string () => null;

        var queue = new PriorityQueue<string, int>();
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 60);
        queue.Enqueue("C", 5);
        queue.Enqueue("D", 11);
        while (queue.TryDequeue(out var item, out int priority))
        {
            Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
        }

        List<Person> people = new List<Person>
            {
                new Person("John Smith", 10),
                new Person("Jane Hallow", 20),
                new Person("Peter Parker", 30),
                new Person("William Dafoe", 40),
                new Person("Test Name", 50),
            };

        var person = people.OrderByDescending(x => x.Age).First();
        var person1 = people.MinBy(x => x.Age);
        var person2 = people.MaxBy(x => x.Age);


        var items = people.Take(1..3);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(person);
        Console.WriteLine(person1);
        Console.WriteLine(person2);

        var distinctBy = people.DistinctBy(x => x.Age);

        var others = new List<Person> {
                new Person("John Smith", 10),
                new Person("Joe", 20)
            };

        var exceptBy = people
            .ExceptBy(new int[] { 10, 20 }, x => x.Age)
            .ToList();

        exceptBy.ForEach(x => Console.WriteLine($"ExceptBy: {x}"));

        var intersectBy = people
            .IntersectBy(new int[] { 10, 20 }, x => x.Age)
            .ToList();

        intersectBy.ForEach(x => Console.WriteLine($"IntersectBy: {x}"));

        var unionBy = people
            .UnionBy(new Person[] { new Person("European Union", 30) }, x => x.Age)
            .ToList();

        unionBy.ForEach(x => Console.WriteLine($"UnionBy: {x}"));

        // LINQ OrDefault Enhancements
        // when FirstOrDefault can’t find a value, what does it return?
        var hayStack = new List<int> { 0, 1, 2, 2, 3 };
        var needle = 5;
        var foundValue = hayStack.FirstOrDefault(x => x == needle);
        if (foundValue == 0)
        {
            Console.WriteLine("We couldn't find the value");
        }

        var nums = Enumerable.Range(1, 10).ToList();
        var chunkSize = 4;
        foreach (var chunk in nums.Chunk(chunkSize)) //Returns a chunk with the correct size. 
        {
            foreach (var item in chunk)
                Console.Write($"{item} ");
            Console.WriteLine("---");
        }


        DateTime datetime = DateTime.Now;
        Console.WriteLine($"DateTime: {datetime}"); //Outputs "Local"

        TimeOnly time = TimeOnly.MinValue;
        Console.WriteLine($"TimeOnly: {time}"); //Outputs 12:00 AM

        TimeOnly startTime = TimeOnly.Parse("11:00 PM");
        Console.WriteLine($"TimeOnly: {startTime}");

        var endTime = startTime.AddHours(2);
        var isBetween = TimeOnly.Parse("12:00 AM").IsBetween(startTime, endTime); //Returns true. 
        Console.WriteLine($"Is Between: {isBetween}");

        DateOnly dateonly = DateOnly.MinValue;
        Console.WriteLine($"DateOnly: {dateonly}"); //Outputs 01/01/0001 (With no Time)

        //It routes packets between a server and a client using a proxy server.
        //var proxy = new WebProxy();
        //proxy.Address = new Uri("socks5://127.0.0.1:8080");
        ////proxy.Credentials = new NetworkCredential(); //Used to set Proxy logins. 
        //var handler = new HttpClientHandler
        //{
        //    Proxy = proxy
        //};
        //var httpClient = new HttpClient(handler);

        Get();
        Console.ReadKey();
    }

    public static void Get()
    {
        return;
    }

    public record Person(string Name, int Age);
}
