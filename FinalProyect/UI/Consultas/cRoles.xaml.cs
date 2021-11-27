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
    /// Interaction logic for cRoles.xaml
    /// </summary>
    public partial class cRoles : Window
    {
        public cRoles()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Roles>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = RolesBLL.GetList(e => e.RolId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = RolesBLL.GetList(e => e.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = RolesBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
