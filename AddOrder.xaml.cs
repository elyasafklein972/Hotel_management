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
	/// Interaction logic for Window5.xaml
	/// </summary>
	public partial class Window5 : Window
	{
		BE.Order tmp;
		BL.IBL bl;
		public Window5()
		{
			InitializeComponent();
			tmp = new BE.Order();
			this.DataContext = tmp;
			bl = BL.Factory.GetInstance();
			this.statusComboBox.ItemsSource = Enum.GetValues(typeof(BE.StatusGuest));
			tmp.GuestrequestKey = int.Parse(this.GuestRequestKey.Text);
			tmp.HostingunitKey = int.Parse(this.HostingUnitKey.Text);


		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				bl.addOrder(tmp);

			}
			catch (Exception ex)

			{
				MessageBox.Show(ex.Message);
			}

		}
	}
	}
}
