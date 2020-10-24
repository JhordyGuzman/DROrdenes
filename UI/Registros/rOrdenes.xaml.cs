using System;
using System.Windows;
using DROrdenes.BLL;
using DROrdenes.DAL;
using DROrdenes.Entidades;

namespace DROrdenes.UI.Registros
{
    public partial class rOrdenes : Window
    {   
        private Ordenes ordenes = new Ordenes();
        
        public rOrdenes()
        {
        InitializeComponent();
        this.DataContext = ordenes;

            //ComboBox del SuplidorId
            SuplidorIdComboBox.ItemsSource = SuplidoresBLL.GetList(s => true);
            SuplidorIdComboBox.SelectedValuePath = "SuplidorId";
            SuplidorIdComboBox.DisplayMemberPath = "Nombres";

           // ComboBox del ProductoId
            ProductoIdComboBox.ItemsSource = ProductosBLL.GetList(p => true);
            ProductoIdComboBox.SelectedValuePath = "ProductoId";
            ProductoIdComboBox.DisplayMemberPath = "Descripcion";

        }

         private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = ordenes;
        }
        //Funcion Limpiar
        private void Limpiar()
        {
            this.ordenes = new Ordenes();
            this.DataContext = ordenes;
        }
        //Funcion Validar
        private bool Validar()
        {
            bool esValidado = true;
            if (OrdenIdTextBox.Text.Length == 0)
            {
                esValidado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValidado;
        }
        //Boton Buscar
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ordenes encontrado = OrdenesBLL.Buscar(ordenes.OrdenId);

            if (encontrado != null)
            {
                ordenes = encontrado;
                Cargar();
            }
            else
            {
                MessageBox.Show($"Este pedido no fue encontrado.\n\nAsegurese que existe o cree uno nuevo.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                OrdenIdTextBox.Clear();
                OrdenIdTextBox.Focus();
            }
        }
        
        //Boton Nuevo
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //Boton Guardar
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = OrdenesBLL.Guardar(this.ordenes);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Boton Eliminar
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (OrdenesBLL.Eliminar(Utilidades.ToInt(OrdenIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Boton de Agregar Fila
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            Productos producto = (Productos)ProductoIdComboBox.SelectedItem;
            var filaDetalle = new OrdenesDetalle
            {
                OrdenId = this.ordenes.OrdenId,
                ProductoId = Convert.ToInt32(ProductoIdComboBox.SelectedValue.ToString()),
                productos = (Productos)ProductoIdComboBox.SelectedItem,
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)
            };

            ordenes.Monto = producto.Costo * int.Parse(CantidadTextBox.Text);
            this.ordenes.Detalle.Add(filaDetalle);
            Cargar();

            ProductoIdComboBox.SelectedIndex = -1;
            CantidadTextBox.Clear();
            CantidadTextBox.Focus();
        }
        //Boton de Eliminar Fila
        private void EliminarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                var detalle = (OrdenesDetalle)DetalleDataGrid.SelectedItem;
                    
                ordenes.Monto = ordenes.Monto - (detalle.productos.Costo * (decimal)detalle.Cantidad);
                ordenes.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
    }
}