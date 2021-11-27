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
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Nombre
                        listado = UsuariosBLL.GetList(e => e.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 1: //Apellido
                        listado = UsuariosBLL.GetList(e => e.Apellido.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 2: //NombreUsuario
                        listado = UsuariosBLL.GetList(e => e.NombreUsuario.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                    case 3: //UsuarioId
                        listado = UsuariosBLL.GetList(e => e.UsuarioId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = UsuariosBLL.GetList(e => true);

            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = UsuariosBLL.GetList(c => c.FechaCreacion.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDataPicker.SelectedDate != null)
                listado = UsuariosBLL.GetList(c => c.FechaCreacion.Date <= HastaDataPicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
