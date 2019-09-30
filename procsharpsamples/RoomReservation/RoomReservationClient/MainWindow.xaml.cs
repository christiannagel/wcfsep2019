using System;
using System.Windows;
using Wrox.ProCSharp.WCF.RoomReservationService;

namespace Wrox.ProCSharp.WCF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RoomReservation reservation;
        public MainWindow()
        {
            InitializeComponent();
            reservation = new RoomReservation { StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) };
            DataContext = reservation;
        }

        private async void OnReserveRoom(object sender, RoutedEventArgs e)
        {
            var client = new RoomServiceClient();
            bool reserved = await client.ReserveRoomAsync(reservation);
            client.Close();

            if (reserved)
            {
                MessageBox.Show("reservation ok");
            }
        }

    }
}
