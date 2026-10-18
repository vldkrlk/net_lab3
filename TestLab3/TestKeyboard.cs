using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net_lab3.Classes;

namespace TestLab3
{
    [TestClass]
    public class TestKeyboard
    {
        [TestMethod]
        public void TestKeyboardCreation()
        {
            var keyboard = new Keyboard("Test Keyboard", 79.99, ConnectionType.BLUETOOTH, KeyboardSwitchType.MECHANICAL);
            Assert.AreEqual("Test Keyboard", keyboard.Name);
            Assert.AreEqual(79.99, keyboard.Price);
            Assert.AreEqual(ConnectionType.BLUETOOTH, keyboard.ConnectionType);
            Assert.AreEqual(KeyboardSwitchType.MECHANICAL, keyboard.SwitchType);
        }

        [TestMethod]
        public void TestKeyboardConnection()
        {
            var keyboard = new Keyboard("Test Keyboard", 79.99, ConnectionType.BLUETOOTH, KeyboardSwitchType.MECHANICAL);
            Assert.IsFalse(keyboard.Connected);
            keyboard.Connect();
            Assert.IsTrue(keyboard.Connected);
            keyboard.Disconnect();
            Assert.IsFalse(keyboard.Connected);
        }

        [TestMethod]
        public void TestKeyboardSwitchType()
        {
            var keyboard = new Keyboard("Test Keyboard", 79.99, ConnectionType.BLUETOOTH, KeyboardSwitchType.MECHANICAL);
            Assert.AreEqual(KeyboardSwitchType.MECHANICAL, keyboard.SwitchType);
        }

        [TestMethod]
        public void TestKeyboardServiceLife()
        {
            var keyboard = new Keyboard("Test Keyboard", 79.99, ConnectionType.BLUETOOTH, KeyboardSwitchType.MECHANICAL);
            int serviceLife = keyboard.CalculateServiceLife();
            Assert.AreEqual(50000000, serviceLife);
        }
    }
}
