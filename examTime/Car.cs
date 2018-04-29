using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examTime
{
    class Car
    {
        private string manufacturer;
        private string model;
        private double loadCapacity;
        private List<Part> parts = new List<Part>();
        private double fuel = 100;
        private double price;
        private static byte count;

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Invalid manufacturer name!");
                }
                this.manufacturer = value; }
        }
        public string Model
        {
            get { return this.model; }
            set {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Invalid model name!");
                }
                this.model = value; }
        }
        public double LoadCapacity
        {
            get { return this.loadCapacity; }
            set {
                if (value < 3)
                {
                    throw new ArgumentException("Invalid load capacity!");
                }
                this.loadCapacity = value; }
        }
        public List<Part> Parts
        {
            get { return this.parts; }
            set { this.parts = value; }
        }
        public double Fuel
        {
            get { return this.fuel; }
            set { this.fuel = value; }
        }
        public double Price
        {
            get { return this.price; }
            set
            {
                foreach (var item in this.Parts)
                {
                    price += item.Price;
                }
                this.Price = value;
            }
        }
        public static byte OrdersCount {
            get { return count; }
        }
        public void ToPrint()
        {
            Console.WriteLine($"{this.Model} made by {this.Manufacturer}");
            Console.WriteLine("Available parts:");
            double price = 0;
            foreach (var item in this.Parts)
            {
                Console.WriteLine($"-> {item.Name} - {item.Price:f2}");
                price += item.Price;
            }
            Console.WriteLine($"With total price of: {price:f2} lv");

        }

        public Car(string manufacturer, string model, double loadCapacity)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.LoadCapacity = loadCapacity;
            count++;
        }
        public void AddPart(Part part)
        {
            this.Parts.Add(part);
        }
        public void AddMultipleParts(List<Part> parts)
        {
            this.Parts.AddRange(parts);
        }
        public void RemovePartByName(string partName)
        {
            Part findPart = this.Parts.Find(v => v.Name == partName);
            if (findPart == null)
            {
                throw new ArgumentException("???????");
            }
            else
            {
                this.Parts.Remove(findPart);
            }
        }
        public void GetCarPrice()
        {
            Console.WriteLine($"{this.Model} with price = {this.Price:f2}");
        }
        public void ContainsPart(string namePr) {
            Part part = this.Parts.Find(s=>s.Name == namePr);
            if (part == null)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("true");
            }
        }
        public void Drive(double distance) {
            this.Fuel -= this.LoadCapacity * 0.2 * distance;
        }
        public void GetMostExpensivePart() {
            double expensive = 0.0;
            string expenIt = "";
            foreach (var item in this.Parts)
            {
                if (item.Price > expensive)
                {
                    expensive = item.Price;
                    expenIt = item.Name;
                }
            }
            Console.WriteLine($"-> {expenIt} - {expensive:f2}");
        }
        public void GetPartsWithPriceAbove(double cena) {
            List<Part> finalParts = new List<Part>();
            foreach (var item in this.Parts)
            {
                if (item.Price > cena)
                {
                    finalParts.Add(item);
                }
            }
            foreach (var item in finalParts )
            {
                Console.Write($"-> {item.Name} - {item.Price:f2}");
            }
        }
        
    }
}
