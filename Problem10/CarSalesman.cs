class Car
{
    string carModel;
    public Engine engine {  get; set; }
    public int weight {  get; set; }
    public string color { get; set; }

    public Car(string carModel, Engine engine, int weight = 0, string color = "n/a")
    {
        this.carModel = carModel;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        
        return $"{carModel}: \n {engine} \n   Weight: {(weight == 0 ? "n/a" : $"{weight}")}  \n   Color: {color}";
    }
}

class Engine
{
    public string engineModel {  get; set; }
    int power;
    public int displasement {  get; set; }
    public string efficiency {  get; set; }
    public Engine(string engineModel, int power, int displasement = 0, string efficiency = "n/a")
    {
        this.engineModel = engineModel;
        this.power = power;
        this.displasement = displasement;
        this.efficiency = efficiency;
    }

    public override string ToString()
    {
        return $"   {engineModel}: \n\tPower: {power} \n\tDisplacement: {(displasement == 0 ? "n/a" : $"{displasement}")} \n\tEfficiency: {efficiency}";
    }
}

class Workspace
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string engineModel = input[0];
            int power = int.Parse(input[1]);
            engines.Add(new Engine(engineModel, power));

            int displacement;
            if(input.Length > 2 && int.TryParse(input[2], out displacement))
            {
                engines[i].displasement = displacement;
            } 
            else if (input.Length > 2)
            {
                engines[i].efficiency = input[2];
            } 

            if (input.Length > 3)
            {
                engines[i].efficiency = input[3];
            }
        }

        int m = int.Parse(Console.ReadLine());
        for (int j = 0; j < m; j++)
        {
            string[] input = Console.ReadLine().Split();
            string carModel = input[0];
            Engine engine = new Engine("", 0);
            for (int k = 0; k < engines.Count; k++)
            {
                if (engines[k].engineModel.Equals(input[1]))
                {
                   engine = engines[k];
                }
            }
            cars.Add(new Car(carModel, engine));

            int weight;
            if (input.Length > 2 && int.TryParse(input[2], out weight))
            {
                cars[j].weight = weight;
            }
            else if (input.Length > 2)
            {
                cars[j].color = input[2];
            }

            if (input.Length > 3)
            {
                cars[j].color = input[3];
            }
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}