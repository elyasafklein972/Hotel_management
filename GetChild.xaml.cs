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
using System.Collections.ObjectModel;

namespace PLWPF
{
	/// <summary>
	/// Interaction logic for GetChild.xaml
	/// </summary>
	public partial class GetChild : Window
	{
		BL.IBL bl;
		
		public GetChild()
		{
			InitializeComponent();
			bl = BL.Factory.GetInstance();
			this.guestRequestListView.ItemsSource = bl.GetChild();
			
		}

	

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Window back = new SQRguest();
			back.Show();
			this.Close();
		}

	
	}
}
