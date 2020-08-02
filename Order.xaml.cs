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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
       
        public Order()
        {
            InitializeComponent();
          
        }

        private void SqrList_Click(object sender, RoutedEventArgs e)
        {
            Window SqrList = new SqrOrder();
            SqrList.Show();
            this.Close();
        }

        private void ListOrder_Click(object sender, RoutedEventArgs e)
        {
            Window ListOrder = new ListOrderWpf();
            ListOrder.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new privetArea();
            back.Show();
            this.Close();
        }
    }
}
