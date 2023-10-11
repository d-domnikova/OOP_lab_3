using System.Security.Cryptography.X509Certificates;

class Employee
{
    string name;
    public double salary {  get; set; }
    string position;
    public string departament { get; set; }
    public string email { get; set; }
    public int age { get; set; }

    public Employee(string name, double salary, string position, string departament, string email = "n/a", int age = -1)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.departament = departament;
        this.email = email;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{name} {salary.ToString("F")} {email} {age}";
    }
}

class Workspace
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();
        Console.WriteLine("Enter 'n': ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            double salary = double.Parse(input[1]);
            string position = input[2];
            string departament = input[3];

            employees.Add(new Employee(name, salary, position, departament));

            if (input.Length > 4 && input[4].Contains("@"))
            {
                employees[i].email = input[4];
            }
            else if (input.Length > 4)
            {
                employees[i].age = int.Parse(input[4]);
            }

            if (input.Length > 5)
            {
                employees[i].age = int.Parse(input[5]);
            }
           
        }
        employees.Sort((employee1, employee2) => employee2.salary.CompareTo(employee1.salary));
        print(SalaryByDepartament(employees), employees);

        static string SalaryByDepartament(List<Employee> employees)
        {
            string departament = "";
            double maxSalary = 0;
            for (int i = 0; i < employees.Count; i++)
            {
                double salary = employees[i].salary;
                int numOfEmp = 1;
                for (int j = 1; j < employees.Count; j++)
                {
                    if (employees[i].departament.Equals(employees[j].departament))
                    {
                        salary = salary + employees[j].salary;
                        numOfEmp++;
                    }
                }
                double avgSalary = salary / numOfEmp;
                if (avgSalary > maxSalary)
                {
                    maxSalary = avgSalary;
                    departament = employees[i].departament;
                }
            }
            return departament;
        }

        static void print(string departament, List<Employee> employees)
        {
            Console.WriteLine("Highest Average Salary: " + departament);
            foreach (Employee employee in employees)
            {
                if (employee.departament.Equals(departament))
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}