class Car
{
    public string model {  get; set; }
    double fuelAmount;
    double fuelConsumptionFor1km;
    int distanceTraveled = 0;

    public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumptionFor1km = fuelConsumptionFor1km;
    }

    public void driveCar(int amountOfKm)
    {
        if(amountOfKm * fuelConsumptionFor1km > fuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        } else
        {
            distanceTraveled = amountOfKm + distanceTraveled;
            fuelAmount = fuelAmount - (amountOfKm * fuelConsumptionFor1km);
        }
    }

    public override string ToString()
    {
        return $"{model} {fuelAmount.ToString("F")} {distanceTraveled}";
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
            string[] input = Console.ReadLine().Split(' ');
            string name = input[0];
            double fuelAmount = double.Parse(input[1]);
            double fuelConsumptionFor1km = double.Parse(input[2]);

            cars.Add(new Car (name, fuelAmount, fuelConsumptionFor1km));
        }

        string[] command = new string[3];
        do {
            command = Console.ReadLine().Split(' ');
            if (command[0].ToLower().Equals("drive"))
            foreach (Car car in cars)
            {
                if (car.model.Equals(command[1]))
                {
                    car.driveCar(int.Parse(command[2]));
                }
            }
        } while (!command[0].ToLower().Equals("end"));

        foreach (Car car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}