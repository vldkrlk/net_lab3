using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab3.Classes
{
    public class Mouse : Peripherals
    {
        int numberOfButtons;

        public Mouse(string name, double price, ConnectionType conn, int numberOfButtons)
            : base(name, price, conn)
        {
            if (numberOfButtons < 1)
            {
                throw new ArgumentException("Number of buttons must be at least 1.");
            }

            this.numberOfButtons = numberOfButtons;
        }

        public Mouse(string name, double price, int numberOfButtons)
            : base(name, price)
        {
            if (numberOfButtons < 1)
            {
                throw new ArgumentException("Number of buttons must be at least 1.");
            }

            this.numberOfButtons = numberOfButtons;
        }

        public int NumberOfButtons { get => numberOfButtons; }

        public int GetClicksSpeed()
        {
            return numberOfButtons * 10;
        }

        public override void Connect()
        {
            base.Connect();
            Console.WriteLine("Mouse connected.");
        }

        public override void Disconnect()
        {
            base.Disconnect();
            Console.WriteLine("Mouse disconnected.");
        }

        public override string TypeString => "Мишка";

        public override string SpecialInfo => $"Кількість кнопок: {numberOfButtons}";
    }
}
