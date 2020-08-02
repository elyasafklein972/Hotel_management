using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
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
	/// Interaction logic for maneger.xaml
	/// </summary>
	public partial class maneger : Window
	{
		BL.IBL bl;
		int sum;
		BackgroundWorker worker;

		public maneger()
		{
			InitializeComponent();
			worker = new BackgroundWorker();
			worker.DoWork += Worker_DoWork;
			worker.RunWorkerAsync();

			bl = BL.Factory.GetInstance();
			this.orderDataGrid.ItemsSource = bl.GetAllOrder();
			this.guestRequestDataGrid.ItemsSource = bl.GetAllGuest();
			this.hostDataGrid.ItemsSource = bl.GetAllHost();
			this.hostingUnitDataGrid.ItemsSource = bl.GetAllHostingUnit();
			sum = 0;

			foreach (var item in bl.GetAllOrder().ToList())
			{
				sum += item.Commission;
			}
			this.SumCommission.Text = string.Format("{0}", sum);
			//this.orderDataGrid.MouseEnter += MessageBox;
		}
		//private void MessageBox(object sender, MouseEventArgs e)
		//{

		//}
		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			Window UpdateOrder = new UpdateOrder();
			UpdateOrder.Show();

		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Window SQRmain = new SQRmain();
			SQRmain.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Window Window3 = new Window3();//open update hosting unit
			Window3.Show();
			this.Close();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Window addOrder = new addorder2();
			addOrder.Show();

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// orderViewSource.Source = [generic data source]
			System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// hostingUnitViewSource.Source = [generic data source]
			System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// guestRequestViewSource.Source = [generic data source]
			System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// hostViewSource.Source = [generic data source]
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			//Window back = new MainWindow();
			//back.Show();
			this.Close();
		}

		private void SumCommission_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void orderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{

		}


		/// <summary>
		/// dependency property
		/// </summary>


		public static readonly DependencyProperty dependencyProperty =
			DependencyProperty.Register("SetBackGroundRed", typeof(bool), typeof(maneger),
				new PropertyMetadata(false, new PropertyChangedCallback(ChangeBackGround)));

		

		private static void ChangeBackGround(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
				(d as Button).Background = Brushes.Red;
		}


		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			//יצירת אובייקט מסוג מייל
			MailMessage mail = new MailMessage();
			//כתובת נמען
			mail.To.Add("elyasaf007@gmail.com");
			//מייל של השולח
			mail.From = new MailAddress("omerhadad23@gmail.com");
			//נושא הודעה
			mail.Subject = "!!התראת אבטחה";
			//תוכן הודעה
			mail.Body = "נכנסו לך באתר לחשבון המנהל";
			//הגדרה שתוכן ההודעה בפורמט HTML 
			mail.IsBodyHtml = true;

			// smt יצירת עצם מסוג 
			SmtpClient smtp = new SmtpClient();

			smtp.Host = "smtp.gmail.com";


			smtp.Credentials = new System.Net.NetworkCredential("elyasaf007@gmail.com",
		   "96522080");

			smtp.EnableSsl = true;

			try
			{
				smtp.Send(mail);

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}




		}

	}
}
	
