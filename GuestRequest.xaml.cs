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

namespace PLWPF
{
	/// <summary>
	/// Interaction logic for GuestRequest.xaml
	/// </summary>
	public partial class GuestRequest : Window
	{
		public GuestRequest()
		{
			InitializeComponent();
		}

		private void updateGuests_Click(object sender, RoutedEventArgs e)
		{
			Window UpdateGuestRequest = new UpdateGuestRequest();
			UpdateGuestRequest.Show();
		}

		private void addGuestRequests_Click(object sender, RoutedEventArgs e)
		{
			Window addGuestRequest = new addGuestRequest();

			addGuestRequest.Show();
		}
	}
}
