using System;
using System.Windows;
using System.Windows.Controls;
using Business;
using Entity;

namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        public ListaCategoria()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BProducto Bproducto = null;
            try
            {
                Bproducto = new BProducto();
                dgvCategoria.ItemsSource = Bproducto.Listar(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bproducto = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManCategoria manCategoria = new ManCategoria(0);
            manCategoria.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idProducto;
            var item = (Producto)dgvCategoria.SelectedItem;
            if (null == item) return;
            idProducto = Convert.ToInt32(item.IdProducto);

            ManCategoria manCategoria = new ManCategoria(idProducto);
            manCategoria.ShowDialog();
            Cargar();
        }
    }
}
