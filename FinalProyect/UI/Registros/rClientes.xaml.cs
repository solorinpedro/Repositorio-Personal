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
    /// Interaction logic for rClientes.xaml
    /// </summary>
    public partial class rClientes : Window
    {
        private Clientes clientes = new Clientes();
        public rClientes()
        {
            InitializeComponent();
            this.DataContext = clientes;
            LLenarComboCondominio();
            CondominioComboBox.ItemsSource = CondominiosBLL.GetList();
            CondominioComboBox.SelectedValuePath = "CondoinioId";
            CondominioComboBox.DisplayMemberPath = "Nombre";
        }
        private bool Validar()
        {
            String mensajeValidacion = "";

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                NombreTextBox.Focus();
                mensajeValidacion = "El nombre no puede estar vacio";
            }

            if (string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
            {
                ApellidoTextBox.Focus();
                mensajeValidacion = "El apellido no  puede estar vacio";
            }

            if (string.IsNullOrWhiteSpace(direccionTextBox.Text))
            {
                direccionTextBox.Focus();
                mensajeValidacion = "La direccion no  puede estar vacio";
            }

            if (telefonoTextBox.Text.Length == 0)
            {
                telefonoTextBox.Focus();
                mensajeValidacion = "El telefono no  puede estar vacio";
            }

            if (cedulaTextBox.Text.Length == 0)
            {
                cedulaTextBox.Focus();
                mensajeValidacion = "La cedula no  puede estar vacio";
            }
            if (CondominioComboBox.SelectedItem == null)
            {
                CondominioComboBox.Focus();
                mensajeValidacion = "Debe de seleccionar una condominio";
            }
            if (ClientesBLL.ExisteCedula(cedulaTextBox.Text))
            {
                MessageBox.Show("Debe ingresar una cedula que no exista....");
            }

            if (mensajeValidacion.Length > 0)
            {
                MessageBox.Show(mensajeValidacion, "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return mensajeValidacion.Length == 0;
        }
        private void LLenarComboCondominio()
        {
            this.CondominioComboBox.ItemsSource = CondominiosBLL.GetList(x => true);
            this.CondominioComboBox.SelectedValuePath = "CondominioId";
            this.CondominioComboBox.DisplayMemberPath = "Nombre";

            if (CondominioComboBox.Items.Count > 0)
            {
                CondominioComboBox.SelectedIndex = 0;
            }
        }
        private void GuardarComboBox()
        {
            clientes.CondominioId = CondominioComboBox.SelectedValue.ToString().Length;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }

        private void Limpiar()
        {
            this.clientes = new Clientes();
            this.DataContext = clientes;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes encontrado = ClientesBLL.Buscar(Utilidades.ToInt(ClienteIdTextBox.Text));

            if (encontrado != null)
            {
                clientes = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("El cliente no existe", 
                    "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            clientes.Detalles.Add(new ClientesDetalle {
                ClienteId = clientes.ClienteId,
                Condominios = (Condominios)CondominioComboBox.SelectedItem
            });

            Cargar();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                clientes.Detalles.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ClientesBLL.Guardar(clientes);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exito", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesBLL.Eliminar(Utilidades.ToInt(ClienteIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se elimino con exito", 
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
