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
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class AddHostingUnit : Window
	{
		BE.HostingUnit hostingunit;
		BE.Host tmp2;
		BL.IBL bl;
		public AddHostingUnit()
		{
			InitializeComponent();
			hostingunit = new BE.HostingUnit();
			bl = BL.Factory.GetInstance();
			this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
			this.DataContext = hostingunit;
			this.Owner.ItemsSource = bl.GetAllHost();
			this.Owner.DisplayMemberPath = "PrivateName";
			this.Owner.SelectedValuePath = "Hostkey";

		}


		private void Button_Click(object sender, RoutedEventArgs e)
		{
			
			hostingunit.Owner = tmp2;
			hostingunit.HostingUnitName = this.hostingUnitNameTextBox.Text;
			hostingunit.Area = (BE.Area)this.areaComboBox.SelectedIndex;
			
			try
			{
				bl.addHostingUnit(hostingunit);
				MessageBox.Show("נוספה יחידת אירוח בהצלחה");
				this.Close();
				//hostingunit = new BE.HostingUnit();
				//this.DataContext = hostingunit;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// hostingUnitViewSource.Source = [generic data source]
		}


		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.Owner.SelectedItem is BE.Host)
			{

				this.tmp2 = ((BE.Host)this.Owner.SelectedItem).GetCopy();
				//MessageBox.Show(hosting.HostingUnitName);
				this.DataContext = tmp2;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//Window back = new MainWindow();
			//back.Show();
			this.Close();
		}
	}
}
