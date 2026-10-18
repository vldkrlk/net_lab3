using net_lab3.Classes;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace net_lab3
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Peripherals> devices;

        public MainWindow()
        {
            InitializeComponent();
            devices = new ObservableCollection<Peripherals>();
            DevicesDataGrid.ItemsSource = devices;
        }

        public void TypeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeviceTypeComboBox.SelectedItem is ComboBoxItem item)
            {
                string? type = item.Tag.ToString();

                if (type == null)
                {
                    MessageBox.Show("Device type is null.");
                    return;
                }

                MousePanel.Visibility = type == "mouse"
                    ? Visibility.Visible
                    : Visibility.Collapsed;

                KeyboardPanel.Visibility = type == "keyboard"
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }
        public void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem? deviceTypeComboBox = DeviceTypeComboBox.SelectedItem as ComboBoxItem;

                if (deviceTypeComboBox?.Tag == null)
                {
                    throw new Exception("Device type is not selected.");
                }

                string deviceType = deviceTypeComboBox.Tag.ToString()!;

                string name = DeviceNameTextBox.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Device name cannot be empty.");
                }

                double price = double.Parse(DevicePrice.Text);

                if (price < 0)
                {
                    throw new Exception("Price cannot be negative.");
                }

                ComboBoxItem? ConnectionTypeComboBox = DeviceConnectionType.SelectedItem as ComboBoxItem;

                if (ConnectionTypeComboBox?.Tag == null)
                {
                    throw new Exception("Connection type is not selected.");
                }

                ConnectionType connectionType = (ConnectionType)Enum.Parse(
                    typeof(ConnectionType),
                    ConnectionTypeComboBox.Tag.ToString()!,
                    true
                );

                if (deviceType == "mouse")
                {
                    int numberOfButtons = int.Parse(MouseNumberOfButtons.Text);
                    if (numberOfButtons < 1)
                    {
                        throw new Exception("Number of buttons must be at least 1.");
                    }
                    Classes.Mouse mouse = new Classes.Mouse(name, price, connectionType, numberOfButtons);
                    devices.Add(mouse);
                }
                else if (deviceType == "keyboard")
                {
                    ComboBoxItem? SwitchTypeComboBox = KeyboardSwitchType.SelectedItem as ComboBoxItem;
                    if (SwitchTypeComboBox?.Tag == null)
                    {
                        throw new Exception("Switch type is not selected.");
                    }
                    KeyboardSwitchType switchType = (KeyboardSwitchType)Enum.Parse(
                        typeof(KeyboardSwitchType),
                        SwitchTypeComboBox.Tag.ToString()!,
                        true
                    );
                    Classes.Keyboard keyboard = new Classes.Keyboard(name, price, connectionType, switchType);
                    devices.Add(keyboard);
                }
                else
                {
                    throw new Exception("Unknown device type.");
                }

                UpdateAnalytics();
                ClearFields();
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding device: {ex.Message}");
            }
        }

        public void UpdateAnalytics()
        {
            int serviceLife = PeripheralsManager.TotalKeyBoardServiceLife(devices.ToList());
            TotalServiceLifeTextBlock.Text = $"Загальний термін служби всіх клавіатур: {serviceLife} натискань";
        }

        public void ClearFields()
        {
            DeviceNameTextBox.Clear();
            DevicePrice.Clear();
            MouseNumberOfButtons.Clear();
            DeviceTypeComboBox.SelectedIndex = -1;
            DeviceConnectionType.SelectedIndex = -1;
            KeyboardSwitchType.SelectedIndex = -1;
        }
    }
}