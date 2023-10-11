class Car
{
    public string model {  get; set; }
    public Engine engine;
    public Cargo cargo;
    public Tire[] tire;

    public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tire = tire;
    }
}

class Engine
{
    private int engineSpeed;
    public int enginePower { get; set; }

    public Engine(int engineSpeed, int enginePower)
    {
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
    }
}

class Cargo
{
    private int cargoWeight;
    public string cargoType { get; set; }

    public Cargo(int cargoWeight, string cargoType)
    {
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
    }
}

class Tire
{
    public double tirePressure {  get; set; }
    private int tireAge;

    public Tire(double tirePressure, int tireAge)
    {
        this.tirePressure = tirePressure;
        this.tireAge = tireAge;
    }
}

class Workspace
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];
            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            double[] tireInfo = input.Skip(5).Select(double.Parse).ToArray();
            Tire[] tires = new Tire[4];
            for(int j = 0; j < tires.Length; j++)
            {
                double tirePressure = tireInfo[j*2];
                int tireAge = (int)tireInfo[j * 2 + 1];
                tires[j] = new Tire(tirePressure, tireAge);
            }

            cars.Add(new Car(model, engine, cargo, tires));
        }

        string command = Console.ReadLine();
        if(command == "flamable")
        {
            flamable(cars);   
        } else if (command == "fragile") 
        {
            fragile(cars);
        }

        void fragile(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++) {
                if (cars[i].cargo.cargoType == "fragile")
                {
                    for (int j = 0; j < cars[i].tire.Length; j++){
                        if (cars[i].tire[j].tirePressure < 1){
                            Console.WriteLine(cars[i].model);
                            break;
                        }
                    }
                }
            }
        }

        void flamable(List<Car> cars){
            for (int i = 0; i < cars.Count; i++){
                if (cars[i].cargo.cargoType == "flamable" && cars[i].engine.enginePower > 250)
                {
                    Console.WriteLine(cars[i].model);
                }
            }
        }
    }
}