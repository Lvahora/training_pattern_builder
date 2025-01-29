using System;
// Задание 1
public class Car
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public bool TripComputer { get; set; }
    public bool GPS { get; set; }

    public override string ToString()
    {
        return $"Машина с {Seats} кресел, {Engine} двигатель, Бортовой компьютер: {TripComputer}, GPS: {GPS}";
    }
}

public class Manual
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public string TripComputerInstructions { get; set; }
    public string GPSInstructions { get; set; }
    public override string ToString()
    {
        return $"Руководство по эксплуатации с {Seats} сиденьями, {Engine} двигателем, инструкциями бортового компьютера: {TripComputerInstructions}, инструкциями GPS: {GPSInstructions}";
    }
}


public interface IBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(string engine);
    void SetTripComputer();
    void SetGPS();
}



public class CarBuilder : IBuilder
{
    private Car _car;

    public CarBuilder()
    {
        _car = new Car();
    }

    public void Reset()
    {
        _car = new Car();
    }

    public void SetSeats(int number)
    {
        _car.Seats = number;
    }

    public void SetEngine(string engine)
    {
        _car.Engine = engine;
    }

    public void SetTripComputer()
    {
        _car.TripComputer = true;
    }

    public void SetGPS()
    {
        _car.GPS = true;
    }

    public Car GetResult()
    {
        return _car;
    }
}

public class CarManualBuilder : IBuilder
{
    private Manual _manual;

    public CarManualBuilder()
    {
        _manual = new Manual();
    }

    public void Reset()
    {
        _manual = new Manual();
    }

    public void SetSeats(int number)
    {
        _manual.Seats = number;
    }

    public void SetEngine(string engine)
    {
        _manual.Engine = engine;
    }

    public void SetTripComputer()
    {
        _manual.TripComputerInstructions = "Добавить инструкцию в бортовой компьютер";
    }

    public void SetGPS()
    {
        _manual.GPSInstructions = "Добавьте инструкцию к GPS";
    }


    public Manual GetResult()
    {
        return _manual;
    }
}



public class Director
{
    public void MakeSUV(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(4);
        builder.SetEngine("Мощный двигатель");
        builder.SetTripComputer();
        builder.SetGPS();
    }

    public void MakeSportsCar(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(2);
        builder.SetEngine("Спортивный двигатель");
        builder.SetTripComputer();
        builder.SetGPS();
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Director director = new Director();


        CarBuilder carBuilder = new CarBuilder();
        director.MakeSportsCar(carBuilder);
        Car car = carBuilder.GetResult();
        Console.WriteLine(car);

        CarManualBuilder manualBuilder = new CarManualBuilder();
        director.MakeSUV(manualBuilder);
        Manual manual = manualBuilder.GetResult();
        Console.WriteLine(manual);
    }
}