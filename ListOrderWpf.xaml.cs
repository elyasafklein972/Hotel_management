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
    /// Interaction logic for ListOrderWpf.xaml
    /// </summary>
    public partial class ListOrderWpf : Window
    {
        BL.IBL bl;
        //private ObservableCollection<BE.Order> Order = new ObservableCollection<BE.Order>();
        public ListOrderWpf()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();


            //foreach (var item in bl.GetAllOrder())
            //{
            //    Order.Add(item);
            //}

            this.orderDataGrid.ItemsSource = bl.GetAllOrder();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new Order();
            back.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource.Source = [generic data source]
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Window update = new UpdateOrder();
            update.Show();
            this.Close();
        }
    }
}
