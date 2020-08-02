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
	/// Interaction logic for GetGuest.xaml
	/// </summary>
	public partial class GetGuest : Window
	{
		BL.IBL bl;
		IEnumerable<BE.GuestRequest> Guests { get; set; }
		public GetGuest()
		{
			InitializeComponent();
			bl = BL.Factory.GetInstance();



			Guests = bl.GrouGuestnums();
			
			
			foreach (var item in Guests)
			{
				this.printGuestRequest.Text = item.PrivateName+" "+item.FamilyName+"\n";

			}
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}
