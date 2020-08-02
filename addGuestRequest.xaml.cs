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
	/// Interaction logic for addGuestRequest.xaml
	/// </summary>
	public partial class addGuestRequest : Window
	{
		// Configure the message box to be displayed
		string messageBoxText = "האם אתה רוצה לשמור את הבקשה?";
		string caption = "הוספת בקשת אירוח";
		MessageBoxButton button = MessageBoxButton.YesNoCancel;
		MessageBoxImage icon = MessageBoxImage.Warning;

		BE.GuestRequest tmp;
		BL.IBL bl;
		public addGuestRequest()
		{
			InitializeComponent();
			tmp = new BE.GuestRequest();
			this.DataContext = tmp;
			bl = BL.Factory.GetInstance();
			this.jacuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.StatusJacuzzi));
			this.poolComboBox1.ItemsSource = Enum.GetValues(typeof(BE.StatusPool));
			this.subAreaComboBox1.ItemsSource = Enum.GetValues(typeof(BE.SubArea));
			this.areaComboBox1.ItemsSource = Enum.GetValues(typeof(BE.Area));
			this.gardenComboBox1.ItemsSource = Enum.GetValues(typeof(BE.StatusGarden));
			this.childrensAttractionsComboBox1.ItemsSource = Enum.GetValues(typeof(BE.StatusChildrensAttractions));
			this.typeComboBox1.ItemsSource = Enum.GetValues(typeof(BE.Type));
			

		}

		

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				tmp.PrivateName = this.privateNameTextBox.Text;
				tmp.FamilyName = this.familyNameTextBox.Text;
				tmp.EntryDate = (DateTime)this.entryDateDatePicker.SelectedDate;
				tmp.ReleaseDate = (DateTime)this.ReleaseDatePicker1.SelectedDate;
				tmp.MailAddress = this.mailAddressTextBox.Text;
				tmp.Jacuzzi = (BE.StatusJacuzzi)this.jacuzziComboBox.SelectedIndex;
				tmp.Pool = (BE.StatusPool)this.poolComboBox1.SelectedIndex;
				tmp.Status = (bool)this.CheckBox.IsChecked;
				tmp.SubArea = (BE.SubArea)this.subAreaComboBox1.SelectedIndex;
				tmp.Area = (BE.Area)this.areaComboBox1.SelectedIndex;
				tmp.Adults = int.Parse(this.adultsTextBox.Text);
				tmp.children = int.Parse(this.childrenTextBox.Text);
				tmp.Garden = (BE.StatusGarden)this.gardenComboBox1.SelectedIndex;
				tmp.ChildrensAttractions = (BE.StatusChildrensAttractions)this.childrensAttractionsComboBox1.SelectedIndex;

			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				tmp = new BE.GuestRequest();
				this.DataContext = tmp;
			}

			try
			{
				
				

				//this.Close();
				// Display message box
				
				// Display message box
				MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
				// Process message box results
				switch (result)
				{
					case MessageBoxResult.Yes:
						bl.addGuestRequest(tmp);
						MessageBox.Show("הבקשה נשמרה בהצלחה");
						this.Close();
						break;
					case MessageBoxResult.No:
						tmp = new BE.GuestRequest();
						this.DataContext = tmp;
					
						break;
					case MessageBoxResult.Cancel:
						//this.Close();
						break;
				}
			}         catch (Exception ex) 
			
			{  
				MessageBox.Show(ex.Message);  
			} 
			
		     }
	

	private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// hostingUnitViewSource.Source = [generic data source]
		}

		

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			
			this.Close();
		}

		
	}
}
