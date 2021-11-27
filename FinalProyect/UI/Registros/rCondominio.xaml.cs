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
    /// Interaction logic for rCondominio.xaml
    /// </summary>
    public partial class rCondominio : Window
    {
        private Condominios condominio = new Condominios();
        public rCondominio()
        {
            InitializeComponent();
            this.DataContext = condominio;
        }
        private void Limpiar()
        {
            this.condominio = new Condominios();
            this.DataContext = condominio;
        }
        private bool Validar()
        {
            String mensajeValidacion = "";

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                NombreTextBox.Focus();
                mensajeValidacion = "El nombre del condominio no puede estar vacio";
            }

            if (string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                PrecioTextBox.Focus();
                mensajeValidacion = "El precio del condominio no puede estar vacio";
            }

            if (string.IsNullOrWhiteSpace(EfectivoTextBox.Text))
            {
                EfectivoTextBox.Focus();
                mensajeValidacion = "El efectivo no puede estar vacio";
            }
            if (mensajeValidacion.Length > 0)
            {
                MessageBox.Show(mensajeValidacion, "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return mensajeValidacion.Length == 0;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var condominio = CondominiosBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (condominio != null)
            {
                this.condominio = condominio;
            }
            else
            {
                this.condominio = new Condominios();
            }
            this.DataContext = this.condominio;
        }


        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CondominiosBLL.Guardar(condominio);
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
            if (CondominiosBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalcularButton_Click(object sender, RoutedEventArgs e)
        {
            float devolucion;
            devolucion = float.Parse(EfectivoTextBox.Text.ToString()) - float.Parse(PrecioTextBox.Text.ToString());
            DevolucionTextBox.Text = devolucion.ToString();
        }
    }
}
