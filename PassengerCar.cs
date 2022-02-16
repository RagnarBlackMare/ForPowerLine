using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class PassengerCar : Auto
    {
        private string name;
        private string typeOfAuto;
        private double averageFuelConsumptionPerKilometer;
        private double fuelTankCapacity;
        private double maximumSpeed;
        private int numberOfPassengersTransported;
        private const int TheReductionOfPowerReserveInPercentPerPassenger = 6;
        internal new string Name { get { return name; } set { name = value; } }
        internal new string TypeOfAuto { get { return typeOfAuto; } set { typeOfAuto = value; } }
        internal new double AverageFuelConsumptionPerKilometer { get { return averageFuelConsumptionPerKilometer; } set { averageFuelConsumptionPerKilometer = value; } }
        internal new double FuelTankCapacity { get { return fuelTankCapacity; } set { fuelTankCapacity = value; } }
        internal new double MaximumSpeed { get { return maximumSpeed; } set { maximumSpeed = value; } }
        internal int NumberOfPassengersTransported { get { return numberOfPassengersTransported; } set { numberOfPassengersTransported = value; } }

        internal PassengerCar(string name, string typeOfAuto, double averageFuelConsumptionPerKilometer, double fuelTankCapacity, double maximumSpeed, int numberOfPassengersTransported)
            : base(name, typeOfAuto, averageFuelConsumptionPerKilometer, fuelTankCapacity, maximumSpeed)
        {
            Name = name;
            TypeOfAuto = typeOfAuto;
            AverageFuelConsumptionPerKilometer = averageFuelConsumptionPerKilometer;
            FuelTankCapacity = fuelTankCapacity;
            MaximumSpeed = maximumSpeed;
            int maxNumberOfPassengers = CalculatePossibleNumberOfPassengers();
            if (numberOfPassengersTransported <= maxNumberOfPassengers)
                NumberOfPassengersTransported = numberOfPassengersTransported;
            else
                throw new Exception("Превышение допустимого кол-ва пассажиров");

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

        internal override double GetPowerReserve(double fuelQuantity)
        {

            double possibleDistance = CalculatePossibleDistance(fuelQuantity);
            double distanceByWhichPowerReserveWillDecrease = possibleDistance * (numberOfPassengersTransported * TheReductionOfPowerReserveInPercentPerPassenger / 100);
            double powerReserve = possibleDistance - distanceByWhichPowerReserveWillDecrease;
            return powerReserve;

        }

        private bool IsThereEnoughFuel(double distance, double fuelQuantity)
        {
            double distanceLimit = fuelQuantity / averageFuelConsumptionPerKilometer;
            if (distance > distanceLimit)
                return false;
            else
                return true;
        }

        private static int CalculatePossibleNumberOfPassengers()
        {
            const int TheTotalPowerReserveInPercent = 100;
            int possibleNumberOfPassengers = TheTotalPowerReserveInPercent / TheReductionOfPowerReserveInPercentPerPassenger;
            return possibleNumberOfPassengers;
        }
    }
}
