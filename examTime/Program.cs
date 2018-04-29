﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examTime
{
    class Program
    {
        static Dictionary<string, Car> cars = new Dictionary<string, Car>(); // model Car
        static Dictionary<string, Part> parts = new Dictionary<string, Part>(); // name Part

        static void Main(string[] args)
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ').ToArray();

                switch (commandArgs[0])
                {
                    case "OrderCar":
                        OrderCar(commandArgs.Skip(1).ToArray());
                        break;
                    case "CreatePart":
                        CreatePart(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintPartByName":
                        PrintPartByName(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintCarByModel":
                        PrintCarByModel(commandArgs.Skip(1).ToArray());
                        break;
                    case "AddPartToCar":
                        AddPartToCar(commandArgs.Skip(1).ToArray());
                        break;
                    case "AddMultiplePartsToCar":
                        AddMultiplePartsToCar(commandArgs.Skip(1).ToArray());
                        break;
                    case "RemovePartFromCar":
                        RemovePartFromCar(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintCarPrice":
                        PrintCarPrice(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintPartPrice":
                        PrintPartPrice(commandArgs.Skip(1).ToArray());
                        break;
                    case "CarContainsPart":
                        CarContainsPart(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintCarMostExpencivePart":
                        PrintCarMostExpencivePart(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintCarPartsWithPriceAbove":
                        PrintCarPartsWithPriceAbove(commandArgs.Skip(1).ToArray());
                        break;
                    case "DriveCar":
                        DriveCar(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintTotalCarOrders":
                        PrintTotalCarOrders();
                        break;
                }
            }
        }
        static void OrderCar(string[] args)
        {
            try
            {
                Car car = new Car(args[0], args[1], double.Parse(args[2]));
                cars.Add(car.Model, car);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void CreatePart(string[] args)
        {
            try
            {
                Part part = null;
                if (args.Length == 2)
                {
                    part = new Part(args[0], double.Parse(args[1]));
                }
                else
                {
                    part = new Part(args[0]);
                }

                parts.Add(part.Name, part);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void PrintPartByName(string[] args)
        {
            Console.WriteLine(parts[args[0]]);
        }
        static void PrintCarByModel(string[] args)
        {
            cars[args[0]].ToPrint();
        }
        static void AddPartToCar(string[] args)
        {
            Car car = cars[args[0]];
            
             if (!parts.ContainsKey(args[1]))
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!");
                }
                else
                {
                Part part = parts[args[1]];
                     car.AddPart(part);
                }                     
        }
        static void AddMultiplePartsToCar(string[] args)
        {
            Car car = cars[args[0]];
            var partsList = new List<Part>();

            foreach (var p in args.Skip(1))
            {
                if (!parts.ContainsKey(p))
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!");
                }
                else
                {
                    Part part = parts[p];
                    partsList.Add(part);
                }

            }

            car.AddMultipleParts(partsList);
        }
        static void RemovePartFromCar(string[] args)
        {
            try
            {
                cars[args[0]].RemovePartByName(args[1]);
            }
            catch (Exception exs)
            {

                Console.WriteLine(exs.Message); 
            }

        }
        static void PrintCarPrice(string[] args)
        {
            cars[args[0]].GetCarPrice();
            // Console.WriteLine($"{cars[args[0]].Model} with price = {cars[args[0]].GetCarPrice():F2}");
        }
        static void PrintPartPrice(string[] args)
        {
            parts[args[0]].PrintPartPrice();
        }
        static void CarContainsPart(string[] args)
        {
            cars[args[0]].ContainsPart(args[1]);
        }
        static void PrintCarMostExpencivePart(string[] args)
        {
            cars[args[0]].GetMostExpensivePart();
        }
        static void PrintCarPartsWithPriceAbove(string[] args)
        {
            Console.WriteLine(cars[args[0]].Model + " with parts more expensive than " + args[1] + ": ");
            cars[args[0]].GetPartsWithPriceAbove(double.Parse(args[1]));
        }
        static void DriveCar(string[] args)
        {
            try
            {
                cars[args[0]].Drive(double.Parse(args[1]));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void PrintTotalCarOrders()
        {
            Console.WriteLine(Car.OrdersCount);
        }


    }
}
