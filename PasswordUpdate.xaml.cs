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
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class PasswordUpdate : Window
    {
        BL.IBL bl;
        BE.Passworde passworde;
        public PasswordUpdate()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
            passworde = new BE.Passworde();
            this.DataContext = passworde;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.passwordTextBox.Text == "" || this.userTextBox.Text == "")
                {
                    throw new Exception("!הינך חייב להכניס שם משתמש וסיסמה");

                }

                int a = 0;
                this.passworde.User = this.userTextBox.Text;
                this.passworde.Password = this.passwordTextBox.Text;
                foreach (var item in bl.GetPasswordList())
                {
                    if (item.User == passworde.User && item.Password == passworde.Password)
                    {
                        a = 1;

                        Window Window3 = new Window3();//open update hosting unit
                        Window3.Show();
                        this.Close();
                    }
                }
                if (passworde.Password != "" && passworde.User != "" && a == 0)
                {
                    MessageBox.Show("!משתמש או סיסמה אינם נכונים");
                }
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                passworde = new BE.Passworde();
                this.DataContext = passworde;
            }
            


            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource passwordeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("passwordeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // passwordeViewSource.Source = [generic data source]
        }

        private void passwordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        
            this.Close();
        }

        private void userTextBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void changPassword_Click(object sender, RoutedEventArgs e)
        {
            Window chagePass = new UpdatePassword();
            chagePass.Show();
            this.Close();
        }
    }
}
