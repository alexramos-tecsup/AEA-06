using System;
using System.Collections.Generic;
using System.Windows;
using Business;
using Entity;

namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {

        public int ID { get; set; }
        public ManCategoria(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);
                if (productos.Count > 0)
                {
                    lblID.Content = productos[0].IdProducto.ToString();
                    txtNombre.Text = productos[0].Nombre;
                    txtPrecio.Text = productos[0].Precio.ToString();
                    if (productos[0].EsActivo == false)
                    {
                        chkNo.IsChecked = true;
                    }
                    else
                    {
                        chkSi.IsChecked = true;
                    }
                }
            }
        }

        private void BntGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto Bproductos = null;
            bool result = true;
            try
            {
                Bproductos = new BProducto();
                if (ID > 0)
                    if (chkSi.IsChecked ?? true)
                    {
                        result = Bproductos.Actualizar(new Producto { IdProducto = ID, Nombre = txtNombre.Text, Precio = Convert.ToDecimal(txtPrecio.Text), EsActivo = true });
                    }
                    else
                    {
                        result = Bproductos.Actualizar(new Producto { IdProducto = ID, Nombre = txtNombre.Text, Precio = Convert.ToDecimal(txtPrecio.Text), EsActivo = false });
                    }                
                else
                    if (chkSi.IsChecked ?? true)
                    {
                        result = Bproductos.Insertar(new Producto { Nombre = txtNombre.Text, Precio = Convert.ToDecimal(txtPrecio.Text), EsActivo = true });
                    }
                    else
                    {
                        result = Bproductos.Insertar(new Producto { Nombre = txtNombre.Text, Precio = Convert.ToDecimal(txtPrecio.Text), EsActivo = false });
                    }                    
                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bproductos = null;
            }
        }

        private void BntCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public ManCategoria()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProducto Bproductos = null;
            bool result = true;
            try
            {
                Bproductos = new BProducto();
                if (ID > 0)
                    result = Bproductos.Eliminar(ID);
                else
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bproductos = null;
            }
        }
    }
}
