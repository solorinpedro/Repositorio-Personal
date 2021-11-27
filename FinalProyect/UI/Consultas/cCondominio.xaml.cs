using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FinalProyect.BLL;
using FinalProyect.Entidades;

namespace FinalProyect.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cCondominio.xaml
    /// </summary>
    public partial class cCondominio : Window
    {
        public cCondominio()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Condominios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = CondominiosBLL.GetList(e => e.CondominioId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = CondominiosBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

