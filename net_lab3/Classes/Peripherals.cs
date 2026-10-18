using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab3.Classes
{
    public abstract class Peripherals
    {
        string name;
        double price;
        ConnectionType connectionType;
        bool connected;
        string driverVersion;

        public Peripherals(string name, double price, ConnectionType connection)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            this.name = name;
            this.price = price;
            this.connectionType = connection;
            connected = false;
            driverVersion = "1.0.0";
        }

        public Peripherals(string name, double price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            this.name = name;
            this.price = price;
            this.connectionType = ConnectionType.USB;
            connected = false;
            driverVersion = "1.0.0";
        }

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public ConnectionType ConnectionType { get => connectionType; }

        public string DriverVersion { get => driverVersion; }

        public bool Connected { get => connected; }

        public virtual void Connect()
        {
            connected = true;
        }

        public virtual void Disconnect()
        {
            connected = false;
        }

        public void UpdateDriver(string newVersion)
        {
            driverVersion = newVersion;
        }

        public abstract string TypeString { get; }
        public abstract string SpecialInfo { get; }
    } 
}
