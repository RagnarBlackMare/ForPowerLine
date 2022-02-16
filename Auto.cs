using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal abstract class Auto
    {
        private string name;
        private string typeOfAuto;
        private double averageFuelConsumptionPerKilometer;
        private double fuelTankCapacity;
        private double maximumSpeed;
        private double fuelQuantity;
        internal string Name { get { return name; } set { name = value; } }
        internal string TypeOfAuto { get { return typeOfAuto; } set { typeOfAuto = value; } }
        internal double AverageFuelConsumptionPerKilometer { get { return averageFuelConsumptionPerKilometer; } set { averageFuelConsumptionPerKilometer = value; } }
        internal double FuelTankCapacity { get { return fuelTankCapacity; } set { fuelTankCapacity = value; } }
        internal double MaximumSpeed { get { return maximumSpeed; } set { maximumSpeed = value; } }
        internal double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }

        internal Auto(string name, string typeOfAuto, double averageFuelConsumptionPerKilometer, double fuelTankCapacity, double maximumSpeed)
        {
            Name = name;
            TypeOfAuto = typeOfAuto;
            AverageFuelConsumptionPerKilometer = averageFuelConsumptionPerKilometer;
            FuelTankCapacity = fuelTankCapacity;
            MaximumSpeed = maximumSpeed;
            FuelQuantity = fuelQuantity;
        }

        internal abstract double CalculatePossibleDistance(double remainingFuel);
        internal abstract double GetPowerReserve(double fuelQuantity);
        internal abstract double CalculateTravelTime(double distance, double fuelQuantity);

    }
}
