using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net_lab3.Classes;

namespace TestLab3
{
    [TestClass]
    public class TestPeripheralsManager
    {
        [TestMethod]
        public void TestTotalKeyBoardServiceLife()
        {
            var devices = new List<Peripherals>
            {
                new Keyboard("ModelX", 1000, ConnectionType.USB, KeyboardSwitchType.MECHANICAL),
                new Keyboard("ModelY", 2000, ConnectionType.BLUETOOTH, KeyboardSwitchType.MEMBRANE),
                new Mouse("ModelZ", 1500, ConnectionType.USB, 4)
            };
            int totalServiceLife = PeripheralsManager.TotalKeyBoardServiceLife(devices);
            Assert.AreEqual(55000000, totalServiceLife);
        }

        [TestMethod]
        public void TestTotalKeyBoardServiceLifeWithNoKeyboards()
        {
            var devices = new List<Peripherals>
            {
                new Mouse("ModelZ", 1500, ConnectionType.USB, 4)
            };
            int totalServiceLife = PeripheralsManager.TotalKeyBoardServiceLife(devices);
            Assert.AreEqual(0, totalServiceLife);
        }
    }
}
