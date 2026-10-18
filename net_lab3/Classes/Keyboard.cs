using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab3.Classes
{
    public class Keyboard:Peripherals
    {

        KeyboardSwitchType switchType;

        public Keyboard(string name, double price, ConnectionType conn, KeyboardSwitchType switchType)
            : base(name, price, conn)
        {
            this.switchType = switchType;
        }

        public Keyboard(string name, double price, KeyboardSwitchType switchType)
            : base(name, price)
        {
            this.switchType = switchType;
        }

        public KeyboardSwitchType SwitchType { get => switchType; }

        public int CalculateServiceLife()
        {
            switch (switchType)
            {
                case KeyboardSwitchType.MECHANICAL:
                    return 50_000_000;
                case KeyboardSwitchType.MEMBRANE:
                    return 5_000_000;
                case KeyboardSwitchType.OPTICAL:
                    return 100_000_000;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Connect()
        {
            base.Connect();
            Console.WriteLine("Keyboard connected.");
        }

        public override void Disconnect()
        {
            base.Disconnect();
            Console.WriteLine("Keyboard disconnected.");
        }

        public string getSwitchTypeString()
        {
            switch (switchType)
            {
                case KeyboardSwitchType.MECHANICAL:
                    return "Механічні";
                case KeyboardSwitchType.MEMBRANE:
                    return "Мембранні";
                case KeyboardSwitchType.OPTICAL:
                    return "Оптичні";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string TypeString => "Клавіатура";

        public override string SpecialInfo => $"Тип перемикачів: {getSwitchTypeString()}";

    }
}
