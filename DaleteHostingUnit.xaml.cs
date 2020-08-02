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
	/// Interaction logic for Window4.xaml
	/// </summary>
	public partial class DaleteHostingUnit : Window
	{
		BE.HostingUnit tmp2;
		BL.IBL bl;
		public DaleteHostingUnit()
		{
			tmp2 = null;
			InitializeComponent();
			bl = BL.Factory.GetInstance();
			
			this.hostingComboBox.ItemsSource = bl.GetAllHostingUnit();

			this.hostingComboBox.DisplayMemberPath = "Hostingunitkey";
			this.hostingComboBox.SelectedValuePath = "Hostingunitkey";


		}

		private void hostingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.hostingComboBox.SelectedItem is BE.HostingUnit)
			{

				this.tmp2 = ((BE.HostingUnit)this.hostingComboBox.SelectedItem).GetCopy();
				//MessageBox.Show(hosting.HostingUnitName);
				this.DataContext = tmp2;
			}
			//this.DataContext = hosting;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			
			try
			{
				bl.DeleteHostingUnit(tmp2);
				MessageBox.Show("נמחק בהצלחה!!");
				this.Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			}
			
		}

		
	}
}
