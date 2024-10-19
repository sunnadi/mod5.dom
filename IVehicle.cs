using System;
using System.Collections.Generic;

public interface IVehicle
{
    void Drive();
    void Refuel();
}

public class Car : IVehicle
{
    public string Brand { get; }
    public string Model { get; }
    public string FuelType { get; }

    public Car(string brand, string model, string fuelType)
    {
        Brand = brand;
        Model = model;
        FuelType = fuelType;
    }

    public void Drive()
    {
        Console.WriteLine($"Машина {Brand} {Model} едет.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Заправка машины {Brand} {Model} топливом типа {FuelType}.");
    }
}

public class Motorcycle : IVehicle
{
    public string Type { get; }
    public double EngineVolume { get; }

    public Motorcycle(string type, double engineVolume)
    {
        Type = type;
        EngineVolume = engineVolume;
    }

    public void Drive()
    {
        Console.WriteLine($"Мотоцикл типа {Type} с объемом двигателя {EngineVolume} л едет.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Заправка мотоцикла типа {Type}.");
    }
}

public class Truck : IVehicle
{
    public double LoadCapacity { get; }
    public int Axles { get; }

    public Truck(double loadCapacity, int axles)
    {
        LoadCapacity = loadCapacity;
        Axles = axles;
    }

    public void Drive()
    {
        Console.WriteLine($"Грузовик с грузоподъемностью {LoadCapacity} кг и {Axles} осями едет.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Заправка грузовика с грузоподъемностью {LoadCapacity} кг.");
    }
}

public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}
public class CarFactory : VehicleFactory
{
    private readonly string _brand;
    private readonly string _model;
    private readonly string _fuelType;

    public CarFactory(string brand, string model, string fuelType)
    {
        _brand = brand;
        _model = model;
        _fuelType = fuelType;
    }

    public override IVehicle CreateVehicle()
    {
        return new Car(_brand, _model, _fuelType);
    }
}

public class MotorcycleFactory : VehicleFactory
{
    private readonly string _type;
    private readonly double _engineVolume;

    public MotorcycleFactory(string type, double engineVolume)
    {
        _type = type;
        _engineVolume = engineVolume;
    }

    public override IVehicle CreateVehicle()
    {
        return new Motorcycle(_type, _engineVolume);
    }
}

public class TruckFactory : VehicleFactory
{
    private readonly double _loadCapacity;
    private readonly int _axles;

    public TruckFactory(double loadCapacity, int axles)
    {
        _loadCapacity = loadCapacity;
        _axles = axles;
    }

    public override IVehicle CreateVehicle()
    {
        return new Truck(_loadCapacity, _axles);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип транспорта (Car, Motorcycle, Truck):");
        string vehicleType = Console.ReadLine();

        IVehicle vehicle = null;

        switch (vehicleType.ToLower())
        {
            case "car":
                Console.WriteLine("Введите марку:");
                string brand = Console.ReadLine();
                Console.WriteLine("Введите модель:");
                string model = Console.ReadLine();
                Console.WriteLine("Введите тип топлива:");
                string fuelType = Console.ReadLine();
                vehicle = new CarFactory(brand, model, fuelType).CreateVehicle();
                break;

            case "motorcycle":
                Console.WriteLine("Введите тип мотоцикла:");
                string motorcycleType = Console.ReadLine();
                Console.WriteLine("Введите объем двигателя:");
                double engineVolume = Convert.ToDouble(Console.ReadLine());
                vehicle = new MotorcycleFactory(motorcycleType, engineVolume).CreateVehicle();
                break;

            case "truck":
                Console.WriteLine("Введите грузоподъемность:");
                double loadCapacity = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите количество осей:");
                int axles = Convert.ToInt32(Console.ReadLine());
                vehicle = new TruckFactory(loadCapacity, axles).CreateVehicle();
                break;

            default:
                Console.WriteLine("Некорректный тип транспорта.");
                return;
        }

        vehicle.Drive();
        vehicle.Refuel();
    }
}
