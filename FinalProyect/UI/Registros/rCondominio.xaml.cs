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
        private Condominios condominios = new Condominios();
        public rCondominio()
        {
            condominios = new Condominios();
            InitializeComponent();
            this.DataContext = condominios;
            LLenarComboCondominio();
        }
        private void Limpiar()
        {
            this.condominios = new Condominios();
            this.DataContext = condominios;
        }
        private void GuardarComboBox()
        {
            condominios.TipoCondominiosId = TipoComboBox.SelectedValue.ToString().Length;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.condominios;
        }
        private void LLenarComboCondominio()
        {
            this.TipoComboBox.ItemsSource = TipoCondominiosBLL.GetList(x => true);
            this.TipoComboBox.SelectedValuePath = "TipoCondominioId";
            this.TipoComboBox.DisplayMemberPath = "Tipo";

            if (TipoComboBox.Items.Count > 0)
            {
                TipoComboBox.SelectedIndex = 0;
            }
        }
        private bool Validar()
        {
            String mensajeValidacion = "";

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                NombreTextBox.Focus();
                mensajeValidacion = "El nombre del condominio no puede estar vacio";
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                CostoTextBox.Focus();
                mensajeValidacion = "El costo del condominio no puede estar vacio";
            }

            return mensajeValidacion.Length == 0;
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var Condominios = CondominiosBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (Condominios != null)
            {
                this.condominios = Condominios;
            }
            else
            {
                this.condominios = new Condominios();
                MessageBox.Show("Este Condominio no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            GuardarComboBox();
            if (!Validar())
                return;

            var paso = CondominiosBLL.Guardar(condominios);
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
            Condominios existe = CondominiosBLL.Buscar(this.condominios.CondominioId);

            if (CondominiosBLL.Eliminar(this.condominios.CondominioId))
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
    }
}
