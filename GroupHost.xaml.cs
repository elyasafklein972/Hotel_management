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
    /// Interaction logic for GroupHostingUnitArea.xaml
    /// </summary>
    /// 

    public partial class GroupHost : Window
    {
        private ObservableCollection<BE.Host> Hosts = new ObservableCollection<BE.Host>();
        
        BL.IBL bl;
        public GroupHost()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
            foreach (var item in bl.HostingUnitnums())
            {
                Hosts.Add(item);
            }
            DataContext = Hosts;
 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window back = new Sqr_Etc();
            back.Show();
            this.Close();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}