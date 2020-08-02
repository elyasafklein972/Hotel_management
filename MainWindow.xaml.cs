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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PLWPF
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		BL.IBL bl;
		BackgroundWorker worker;
		public MainWindow()
		{
			InitializeComponent();
			worker = new BackgroundWorker();
			worker.DoWork += Worker_DoWork;

			worker.RunWorkerAsync();
			bl = BL.Factory.GetInstance();
			//if(bl==null)
			bl.CheckGuest();
			this.addGuestRequests.MouseLeave += Button_MouseLeave;
			this.addGuestRequests.MouseEnter+= Button_MouseEnter;


			this.meneger.MouseEnter+= Button_MouseEnter;
			this.meneger.MouseLeave += Button_MouseLeave;

			
			this.privatearea.MouseLeave += Button_MouseLeave;
			this.privatearea.MouseEnter += Button_MouseEnter;

			this.addhosting.MouseLeave += Button_MouseLeave;
			this.addhosting.MouseEnter += Button_MouseEnter;

			this.updateGuests.MouseEnter += Button_MouseEnter;
			this.updateGuests.MouseLeave += Button_MouseLeave;

			DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, delegate
			{
				int value = 0;
				if (counter == int.MaxValue)
				{
					value = 0;

				}
				else
				{
					value = counter + 1;
				}
				SetValue(counterProperty, value);



			}, Dispatcher);


		}


		public int counter
		{
			get { return (int)GetValue(counterProperty); }
			set { SetValue(counterProperty, value); }
		}

		// Using a DependencyProperty as the backing store for counter.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty counterProperty =
			DependencyProperty.Register("counter", typeof(int), typeof(MainWindow), new PropertyMetadata(0));




		private void Button_MouseEnter(object sender, MouseEventArgs e) {
			Button b = sender as Button;
			if (b != null) {
				b.Height += b.Height*0.5;
				b.Width += b.Width * 0.5; 
			} 
		}
	private void Button_MouseLeave(object sender, MouseEventArgs e) 
	{ 
		Button b = sender as Button; 
		if (b != null)
		{ b.Height = b.Height *0.67;
			b.Width = b.Width *0.67;
		} 
	}
	
	private void HostingUnit_Click(object sender, RoutedEventArgs e)
		{
			Window HostingUnit = new HostingUnit();
			HostingUnit.Show();
			//this.Close();
		}

		private void maneger_Click(object sender, RoutedEventArgs e)
		{
			Window maneger= new maneger();
			maneger.Show();
		//	this.Close();
		}

		private void GuestRequest_Click(object sender, RoutedEventArgs e)
		{
			Window GuestRequest = new GuestRequest();
			GuestRequest.Show();
		//	this.Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Window meneger = new maneger();
			meneger.Show();
		//	this.Close();
		}

		private void addGuestRequests_Click(object sender, RoutedEventArgs e)
		{
			Window addGuestRequest = new addGuestRequest();
			addGuestRequest.Show();
			
		}

		private void updateGuests_Click(object sender, RoutedEventArgs e)
		{
			Window UpdateGuestRequest = new UpdateGuestRequest();
			UpdateGuestRequest.Show();
			
		}

		private void privetArea_Click(object sender, RoutedEventArgs e)
		{
			Window privetArea = new PasswordForPrivet();
			privetArea.Show();
		//	this.Close();
		}

		private void addHostingUnit_Click_1(object sender, RoutedEventArgs e)
		{
			Window AddHostingUnit = new AddHostingUnit();
			AddHostingUnit.Show();
			//this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Window Window3 = new Window3();
			Window3.Show();
			//this.Close();

		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			Window UpdateOrder = new UpdateOrder();
			UpdateOrder.Show();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// guestRequestViewSource.Source = [generic data source]
			System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// orderViewSource.Source = [generic data source]
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Window password = new Password();
			password.Show();
			//	this.Close();
			
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
			mail.Subject = "עומר ואליסף בעמ";
			//תוכן הודעה
			mail.Body = "הפרוייקט שלך נפתח";
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




