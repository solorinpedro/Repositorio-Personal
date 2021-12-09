using System;
using InvoicerNETCore.Models;
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
using InvoicerNETCore.Services;

namespace FinalProyect.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRecibos.xaml
    /// </summary>
    public partial class rRecibos : Window
    {
        private Clientes clientes = new Clientes();

        public rRecibos()
        {
            InitializeComponent();
            LLenarComboCliente();
            LLenarComboDireccion();
            LLenarComboApartamento();
            LLenarComboParqueo();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GenerarButton_Click(object sender, RoutedEventArgs e)
        {
           
            string[] empresa = { NombreTextBox.Text };
            string direccion = DireccionTextBox.Text;
            string[] cliente = { ClienteComboBox.SelectedValue.ToString()};
            string direccionCliente = DireccionComboBox.SelectedValue.ToString();
            decimal precioApartamento = ApartamentoComboBox.SelectedValue.ToString().Length;
            decimal precioParqueo = ParqueoComboBox.SelectedValue.ToString().Length; ;
            decimal precioTotal = precioApartamento + precioParqueo;
            new InvoicerApi(SizeOption.A4, OrientationOption.Landscape, "DOP")
            .TextColor("#CC0000")
            .BackColor("#FFD6CC")
            .Title("Recibo de Pago")
            .DueDate(DateTime.Now.AddMonths(1))
        .Image(@"C:\Users\solor\source\repos\FinalProyect\FinalProyect\Resources\inmobiliaria.png", 125, 27)
        .Company(Address.Make("De", empresa, empresa[0].ToString(), "0.00"))
        .Client(Address.Make("Para", cliente, direccionCliente, "0.00"))
        .Items(new List<ItemRow> {
            ItemRow.Make("Pago de Apartamento", "Apartamento 1", (decimal)1, 0, precioApartamento, precioApartamento),
            ItemRow.Make("Pago de Parqueo", "Parqueo 1", (decimal)1, 0, precioParqueo, precioParqueo),
        })
        .Totals(new List<TotalRow> {
            TotalRow.Make("Total", precioTotal, true),
        })
        .Save();
        }
        private void LLenarComboCliente()
        {
            this.ClienteComboBox.ItemsSource = ClientesBLL.GetList(x => true);
            this.ClienteComboBox.SelectedValuePath = "Nombre";
            this.ClienteComboBox.DisplayMemberPath = "Nombre";
        }

        private void LLenarComboDireccion()
        {
            this.DireccionComboBox.ItemsSource = ClientesBLL.GetList(x => true);
            this.DireccionComboBox.SelectedValuePath = "Direccion";
            this.DireccionComboBox.DisplayMemberPath = "Direccion";
        }

        private void LLenarComboApartamento()
        {
            this.ApartamentoComboBox.ItemsSource = CondominiosBLL.GetList(x => true);
            this.ApartamentoComboBox.SelectedValuePath = "Costo";
            this.ApartamentoComboBox.DisplayMemberPath = "CondominioId";
        }

        private void LLenarComboParqueo()
        {
            this.ParqueoComboBox.ItemsSource = CondominiosBLL.GetList(x => true);
            this.ParqueoComboBox.SelectedValuePath = "Costo";
            this.ParqueoComboBox.DisplayMemberPath = "CondominioId";
        }
    }
}