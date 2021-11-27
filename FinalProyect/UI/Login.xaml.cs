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
using FinalProyect.BLL;

namespace FinalProyect.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MainWindow principal = new MainWindow();
        public Login()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = LoginBLL.Validar(NombreUsuarioTextBox.Text, ClavePassWordBox.Password);

            if (paso)
            {
                this.Close();
                principal.Show();
            }
            else
            {
                MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                ClavePassWordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }
        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
