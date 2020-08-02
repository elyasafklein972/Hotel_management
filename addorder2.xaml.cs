using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Interaction logic for addorder2.xaml
	/// </summary>
	public partial class addorder2 : Window
	{
		BE.Order tmp;
		BE.HostingUnit hosting;
		BE.GuestRequest Guest;
		BL.IBL bl;
		BackgroundWorker worker;
		public addorder2()
		{
			InitializeComponent();
			tmp = new BE.Order();
			worker = new BackgroundWorker();
			


			this.DataContext = tmp;
			bl = BL.Factory.GetInstance();
			this.statusComboBox.ItemsSource = Enum.GetValues(typeof(BE.StatusGuest));
			this.hostingComboBox.ItemsSource = bl.GetAllHostingUnit();

			this.hostingComboBox.DisplayMemberPath = "Hostingunitkey";
			this.hostingComboBox.SelectedValuePath = "HostingUnitName";

			this.GuestComboBox.ItemsSource = bl.GetAllGuest();
			this.GuestComboBox.DisplayMemberPath = "GuestRequestkey";
			this.GuestComboBox.SelectedValuePath = "GuestRequestkey";



		}
		private void GuestComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.GuestComboBox.SelectedItem is BE.GuestRequest)
			{
				this.Guest = ((BE.GuestRequest)this.GuestComboBox.SelectedItem).GetCopy();
				tmp.GuestrequestKey = Guest.GuestRequestkey;


			}
		}
		private void hostingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.hostingComboBox.SelectedItem is BE.HostingUnit)
			{

				this.hosting = ((BE.HostingUnit)this.hostingComboBox.SelectedItem).GetCopy();
				//MessageBox.Show(hosting.HostingUnitName);
				tmp.HostingunitKey = hosting.Hostingunitkey;
				
			}
			
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				bl.addOrder(tmp);
				if (tmp.Status == BE.StatusGuest.נשלח_מייל)
				{
					MessageBox.Show("נשלח מייל ללקוח עם פרטי הזמנה");
					MessageBox.Show(" ההזמנה נוספה בהצלחה");
					this.Close();
					//bl.SendingEmail(tmp);
					worker.DoWork += Worker_DoWork;
				}
				else {

			     MessageBox.Show(" ההזמנה נוספה בהצלחה");
			//	MainWindow.counter = bl.GetAllOrder().ToList().Count;
				this.Close();
				}
				
			}
			catch (Exception ex)

			{
				MessageBox.Show(ex.Message);
			}

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Window back = new SqrOrder();
			back.Show();
			this.Close();
		}


		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				bl.SendingEmail(tmp);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
