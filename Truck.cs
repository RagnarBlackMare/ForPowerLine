using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Truck : Auto
    {
        private string name;
        private string typeOfAuto;
        private double averageFuelConsumptionPerKilometer;
        private double fuelTankCapacity;
        private double maximumSpeed;
        private double fuelQuantity;
        private double loadCapacity;
        private const int TheReductionOfPowerReserveInPercentPerEveryTwoHundredKilograms = 4;
        private const int weightOfOneUnitOfCargoInKilograms = 200;
        internal string Name { get { return name; } set { name = value; } }
        internal string TypeOfAuto { get { return typeOfAuto; } set { typeOfAuto = value; } }
        internal double AverageFuelConsumptionPerKilometer { get { return averageFuelConsumptionPerKilometer; } set { averageFuelConsumptionPerKilometer = value; } }
        internal double FuelTankCapacity { get { return fuelTankCapacity; } set { fuelTankCapacity = value; } }
        internal double MaximumSpeed { get { return maximumSpeed; } set { maximumSpeed = value; } }
        internal double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        internal double LoadCapacity { get { return loadCapacity; } set { loadCapacity = value; } }

        public Truck(string name, string typeOfAuto, double averageFuelConsumptionPerKilometer, double fuelTankCapacity, double maximumSpeed, double loadCapacity)
            : base(name, typeOfAuto, averageFuelConsumptionPerKilometer, fuelTankCapacity, maximumSpeed)

        {
            Name = name;
            TypeOfAuto = typeOfAuto;
            AverageFuelConsumptionPerKilometer = averageFuelConsumptionPerKilometer;
            FuelTankCapacity = fuelTankCapacity;
            MaximumSpeed = maximumSpeed;
            int maxloadCapacity = CalculatePossibleLoadCapacity();
            int wholeNumberOfCargoUnitsInTruck = loadCapacity / weightOfOneUnitOfCargoInKilograms;
            int massOfIntegerNumberOfCargoUnits = wholeNumberOfCargoUnitsInTruck * weightOfOneUnitOfCargoInKilograms;
            if (loadCapacity <= massOfIntegerNumberOfCargoUnits)
                LoadCapacity = loadCapacity;
            else
                throw new Exception("Превышение допустимой грузоподьемности");
        }

        internal override double CalculatePossibleDistance(double remainingFuel)
        {
            double possibleDistance = remainingFuel / averageFuelConsumptionPerKilometer;
            return possibleDistance;
        }

        internal override double CalculateTravelTime(double distance, double fuelQuantity)
        {
            double travelTime;
            if (IsThereEnoughFuel(distance, fuelQuantity) == true)
            {
                travelTime = distance / maximumSpeed;
                return travelTime;
            }
            else throw new Exception("Текщего запаса топлива не достаточно для прохождения дистанции - " + distance);
        }

        internal override double GetPowerReserve(double transportedUnits, double fuelQuantity)
        {
            double possibleDistance = CalculatePossibleDistance(fuelQuantity);
            double distanceByWhichPowerReserveWillDecrease = possibleDistance * (loadCapacity * TheReductionOfPowerReserveInPercentPerEveryTwoHundredKilograms / 100);
            double powerReserve = possibleDistance - distanceByWhichPowerReserveWillDecrease;
            return powerReserve;
        }

        private double CalculatePossibleLoadCapacity()
        {
            const int TheTotalPowerReserveInPercent = 100;
            double possibleNumberOfCargoUnits = TheTotalPowerReserveInPercent / TheReductionOfPowerReserveInPercentPerEveryTwoHundredKilograms;
            return possibleNumberOfCargoUnits;
        }
        private bool IsThereEnoughFuel(double distance, double fuelQuantity)
        {
            double distanceLimit = fuelQuantity / averageFuelConsumptionPerKilometer;
            if (distance > distanceLimit)
                return false;
            else
                return true;
        }
    }
}
