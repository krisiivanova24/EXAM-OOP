using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examTime
{
    class Part
    {
        private string name;
        private double price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Invalid part name!");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price should be positive!");
                }
                this.price = value;
            }
        }
        public Part(string name, double price)
        {
            this.Name = name;
            this.Price = price;

        }
        public Part(string name):this(name,25)
        {
        
        
        }
        public override string ToString()
        {
            return $"-> {this.Name} - {this.Price:f2}";
        }
        public void PrintPartPrice()
        {
            Console.WriteLine($"{this.Name} with price = {this.Price:f2}");
        }
        public void CreatePart(string name, double price)
        {
            Part part = new Part(name, price);
        }
        public void CreatePart(string name)
        {
            Part part = new Part(name);
        }
    }
}
