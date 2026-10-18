using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab3.Classes
{
    public class PeripheralsManager
    {
        public static int TotalKeyBoardServiceLife(List<Peripherals> devices)
        {
            int totalServiceLife = 0;
            foreach (var device in devices)
            {
                if (device is Keyboard keyboard)
                    totalServiceLife += keyboard.CalculateServiceLife();
            }
            return totalServiceLife;
        }
    }
}
