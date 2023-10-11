class Person
{
    public string name { get; set; }
    public int age { get; set; }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public Person(int age)
    {
        this.name = "No name";
        this.age = age;
    }

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }

    public override string ToString()
    {
        return name + " " + age;
    }
}

class Workspace
{
    static void Main()
    {
        //problem 1
        Person person_1 = new Person("Pesho", 20);
        Person person_2 = new Person("Gosho", 18);
        Person person_3 = new Person("Stamat", 43);

        //problem 3
        Console.WriteLine("Enter 'n': ");
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            family.AddMember(new Person(name, age));
        }
        Console.WriteLine("Oldest: " + family.getOldestMember());

        //problem 4
        List<Person> opinionPoll = new List<Person>();
        Console.WriteLine("\nEnter 'n': ");
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            if (age > 30)
            {
                opinionPoll.Add(new Person(name, age));
            }
        }
        opinionPoll.Sort((person1, person2) => person1.name.CompareTo(person2.name));
        foreach (Person person in opinionPoll)
        {
            Console.WriteLine(person);
        }
    }
  
}

class Family
{
    List<Person> family = new List<Person>();
    public void AddMember(Person member)
    {
        family.Add(member);
    }

     public Person getOldestMember()
    {
        int oldestMember = 0;
        for (int i = 0; i< family.Count; i++)
        {
           if (family[i].age > family[oldestMember].age)
           {
                oldestMember = i;
           }
          
        }
        return family[oldestMember];
    }
}
