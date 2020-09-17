using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel VM_MainWindow;
        public MainWindow()
        {
            VM_MainWindow = new MainWindowViewModel();
            InitializeComponent();
            DataContext = VM_MainWindow;
            man_joystick.Moved += VM_MainWindow.VM_ManualControl.VM_JoystickMoved;
            man_joystick.Released += VM_MainWindow.VM_ManualControl.VM_JoystickReleased;
            flightboard.VM_FlightBoard = VM_MainWindow.VM_FlightBoard;
        }
    }
}
