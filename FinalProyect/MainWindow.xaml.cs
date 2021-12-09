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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinalProyect.UI.Consultas;
using FinalProyect.UI.Registros;

namespace FinalProyect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroCondominio_Click(object sender, RoutedEventArgs e)
        {
            rCondominio condomio = new rCondominio();
            condomio.Show();
        }

        private void RegistroCliente_Click(object sender, RoutedEventArgs e)
        {
            rClientes clientes = new rClientes();
            clientes.Show();
        }

        private void RegistroRoles_Click(object sender, RoutedEventArgs e)
        {
            rRoles roles = new rRoles();
            roles.Show();
        }

        private void RegistroUsuarios_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios usuarios = new rUsuarios();
            usuarios.Show();
        }

        private void ConsultaRoles_Click(object sender, RoutedEventArgs e)
        {
            cRoles roles = new cRoles();
            roles.Show();
        }

        private void ConsultasUsuarios_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios usuarios = new cUsuarios();
            usuarios.Show();
        }

        private void ConsultaCondominio_Click(object sender, RoutedEventArgs e)
        {
            cCondominio condominio = new cCondominio();
            condominio.Show();
        }

        private void ConsultarClientes_Click(object sender, RoutedEventArgs e)
        {
            cClientes clientes = new cClientes();
            clientes.Show();
        }

        private void Recibos_Click(object sender, RoutedEventArgs e)
        {
            rRecibos recibos = new rRecibos();
            recibos.Show();
        }
    }
}
