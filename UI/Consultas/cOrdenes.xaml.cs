using System;
using System.Collections.Generic;
using System.Windows;
using DROrdenes.BLL;
using DROrdenes.DAL;
using DROrdenes.Entidades;

namespace DROrdenes.UI.Consultas
{
    public partial class cOrdenes : Window
    {
        public cOrdenes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Ordenes> listado = new List<Ordenes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = OrdenesBLL.GetList(p => p.OrdenId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                }
            }
            else
            {
                listado = OrdenesBLL.GetList(c => true);
            }
            if (DesdeDatePicker.SelectedDate != null)
                listado = (List<Ordenes>)OrdenesBLL.GetList(p => p.Fecha.Date >= DesdeDatePicker.SelectedDate);
            if (HastaDatePicker.SelectedDate != null)
                listado = (List<Ordenes>)OrdenesBLL.GetList(p => p.Fecha.Date <= HastaDatePicker.SelectedDate);

            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = listado;
        }
    }
}