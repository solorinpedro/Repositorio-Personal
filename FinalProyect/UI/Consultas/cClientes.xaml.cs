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
using FinalProyect.Entidades;

namespace FinalProyect.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cClientes.xaml
    /// </summary>
    public partial class cClientes : Window
    {
        public cClientes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Nombre
                        listado = ClientesBLL.GetList(e => e.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 1: //Apellido
                        listado = ClientesBLL.GetList(e => e.Apellido.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 2: //Direccion
                        listado = ClientesBLL.GetList(e => e.Direccion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 3: //Id
                        listado = ClientesBLL.GetList(e => e.ClienteId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = ClientesBLL.GetList(e => true);

            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
