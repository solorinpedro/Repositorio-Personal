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

namespace FinalProyect.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles role = new Roles();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = role;
        }
        private void Limpiar()
        {
            this.role = new Roles();
            this.DataContext = role;
        }

        private bool Validar()
        {
            String mensajeValidacion = "";

            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                DescripcionTextBox.Focus();
                mensajeValidacion = "La descripcion no puede estar vacio";
            }

            if (mensajeValidacion.Length > 0)
            {
                MessageBox.Show(mensajeValidacion, 
                    "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return mensajeValidacion.Length == 0;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var roles = RolesBLL.Buscar(Utilidades.ToInt(RolIdTextBox.Text));

            if (roles != null)
            {
                this.role = roles;
            }
            else
            {
                this.role = new Roles();
            }
            this.DataContext = this.role;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = RolesBLL.Guardar(role);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exito", 
                    "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar",
                    "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Utilidades.ToInt(RolIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", 
                    "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", 
                    "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
