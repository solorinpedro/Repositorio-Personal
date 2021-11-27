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
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios Usuario = new Usuarios();

        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = Usuario;

            UsuarioCombobox.ItemsSource = RolesBLL.GetRoles();
            UsuarioCombobox.SelectedValuePath = "RolId";
            UsuarioCombobox.DisplayMemberPath = "Descripcion";
        }
        private bool Validar()
        {
            String mensajeValidacion = "";
            if (FechaDatePicker.Text.Length == 0)
            {
                FechaDatePicker.Focus();
                mensajeValidacion = "La fecha no puede estar vacia";
            }
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                NombreTextBox.Focus();
                mensajeValidacion = "El nombre no puede estar vacio";
            }
            if (string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
            {
                ApellidoTextBox.Focus();
                mensajeValidacion = "El Apellido no puede estar vacio";
            }
            if (string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text))
            {
                NombreUsuarioTextBox.Focus();
                mensajeValidacion = "El nombre de usuario no puede estar vacio";
            }
            if (string.IsNullOrWhiteSpace(ClavePasswordBox.Password))
            {
                ClavePasswordBox.Focus();
                mensajeValidacion = "La clave de usuario no puede estar vacio";
            }
            if (string.IsNullOrWhiteSpace(ConfirmarClavePasswordBox.Password))
            {
                ConfirmarClavePasswordBox.Focus();
                mensajeValidacion = "La clave de usuario no puede estar vacio";
            }

            if (UsuarioCombobox.Text.Length == 0)
            {
                UsuarioCombobox.Focus();
                mensajeValidacion = "Debe de asignar un Rol";
            }
            if (mensajeValidacion.Length > 0)
            {
                MessageBox.Show(mensajeValidacion, "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return mensajeValidacion.Length == 0;
        }

        public void Limpiar()
        {
            this.Usuario = new Usuarios();
            this.DataContext = Usuario;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuario = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));
            if (usuario != null)
            {
                this.Usuario = usuario;
            }
            else
            {
                this.Usuario = new Usuarios();
                MessageBox.Show("No se ha encontrado",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.DataContext = this.Usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuariosBLL.Guardar(this.Usuario);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Se ha guardado exitosamente",
                    "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se ha guardado exitosamente",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se ha eliminado exitosamente", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se ha eliminado exitosamente", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
