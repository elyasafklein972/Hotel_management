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
    /// Interaction logic for UpdatePassword.xaml
    /// </summary>
    public partial class UpdatePassword : Window
    {
        BL.IBL bl;
        BE.Passworde passworde;

        public UpdatePassword()
        {
            InitializeComponent();
            bl = BL.Factory.GetInstance();
            passworde = new BE.Passworde();
            this.DataContext = passworde;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource passwordeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("passwordeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // passwordeViewSource.Source = [generic data source]
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
                BE.Passworde passwordeTmp = new BE.Passworde(this.TextUser.Text, this.TextPassword.Text);

                bl.updatePassword(passworde, passwordeTmp);
                a = 1;
               
                this.Close();
                MessageBox.Show("!שם משתמש וסיסמה הוחלפו בהצלחה");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                passworde = new BE.Passworde();
                this.DataContext = passworde;
            }


        }

        private void backbottom_Click(object sender, RoutedEventArgs e)
        {
            Window back = new Password();
            back.Show();
            this.Close();
        }
    }
}