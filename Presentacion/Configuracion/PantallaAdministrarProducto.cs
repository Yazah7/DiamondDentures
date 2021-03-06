﻿using Control;
using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Validaciones;

namespace Presentacion.Configuracion
{
    public partial class PantallaAdministrarProducto : Pantalla
    {
        InterfaceUsuario Interface;
        enum Búsqueda { Total, Clave, Personalizada };

        public PantallaAdministrarProducto()
        {
            InitializeComponent();
            InitializeComponent2();
            LlenarData(Búsqueda.Total);
            
        }

        private void LlenarData(Búsqueda Tipo)
        {
            int Col = 0, Ren = 0;
            if (dgvProductos.SelectedCells.Count > 0)
            {
                DataGridViewCell Cell = dgvProductos.SelectedCells[0];
                Col = Cell.ColumnIndex;
                Ren = Cell.RowIndex;
            }
            dgvProductos.Rows.Clear();
            Interface = new InterfaceUsuario(this);
            RegistroProducto[] temp = null;
            if (Tipo == Búsqueda.Total)
                temp = Interface.BuscarUnProducto(new RegistroProducto(-1, "", -1, -1, 1));
            else
            {
                if (Tipo == Búsqueda.Clave)
                    temp = Interface.BuscarUnProducto(new RegistroProducto(Convert.ToInt32(tbClave.Text), "", -1, -1, 1));
                else
                    if (Tipo == Búsqueda.Personalizada)
                        temp = Interface.BuscarUnProducto(new RegistroProducto(-1, tbNombre.Text, Convert.ToInt32(tbDias.Text =="" ? "-1" : tbDias.Text), Convert.ToSingle(tbPrecio.Text == "" ? "-1" : tbPrecio.Text), 1));
            }
            if (temp != null)
            {
                dgvProductos.RowCount = temp.Length;
                for (int i = 0; i < temp.Length; i++)
                {
                    dgvProductos[0, i].Value = temp[i].Clave;
                    dgvProductos[1, i].Value = temp[i].Nombre;
                    dgvProductos[2, i].Value = temp[i].Dias + " Dias";
                    dgvProductos[3, i].Value = "$" + temp[i].Precio.ToString();
                    dgvProductos.Rows[i].DefaultCellStyle.BackColor = temp[i].Activo == 0 ? Color.LightSalmon : Color.LightGreen;
                }
            }
            if (dgvProductos.SelectedCells.Count > 0)
            {
                dgvProductos.CurrentCell = dgvProductos[Col, Ren];
                dgvProductos.Focus();
            }
        }

        private void LlenarData()
        {
            LlenarData(Búsqueda.Total);
        }

        private void btnBuscarClave_Click(object sender, EventArgs e)
        {
            if (tbClave.Text != "")
            {
                LlenarData(Búsqueda.Clave);
                tbClave.Clear();
                tbClave.Focus();
            }
            else
            {
                LlenarData(Búsqueda.Personalizada);
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Interface = new InterfaceUsuario(this);
            if (!Validar.ValidarUnaPantalla(new PantallaAgregarProducto().GetType()))
                Interface.DesplegarPantallaAgregarProducto(LlenarData);
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            Interface = new InterfaceUsuario(this);
            if (DialogResult.Yes == MessageBox.Show("Realmente desea eliminar el producto " + dgvProductos[1, dgvProductos.SelectedCells[0].RowIndex].Value + "?", "AVISO", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                if (Interface.EliminarProducto(Convert.ToInt32(dgvProductos[0, dgvProductos.SelectedCells[0].RowIndex].Value)))
                {
                    MessageBox.Show("Producto eliminado con éxito", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarData(Búsqueda.Total);
                }
                else
                    Validar.MensajeErrorBaseDeDatos();
            }
        }

        private void ActivarProducto()
        {
            Interface = new InterfaceUsuario(this);
            if (Interface.ActivarProducto(Convert.ToInt32(dgvProductos[0, dgvProductos.SelectedCells[0].RowIndex].Value)))
            {
                MessageBox.Show("Producto activado con éxito", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarData(Búsqueda.Total);
            }
            else
            {
                Validar.MensajeErrorBaseDeDatos();
            }
        }

        private void dgvProductos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvProductos.CurrentCell = dgvProductos[e.ColumnIndex, e.RowIndex];
                Point Puntero = dgvProductos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                Puntero.X += e.X;
                Puntero.Y += e.Y;
                new ContextMenu((new MenuItem[] { new MenuItem("Activar", new EventHandler(delegate(object sender2, EventArgs e2) { ActivarProducto(); })),
                                                  new MenuItem("Modificar", btnModificarProducto_Click),
                                                  new MenuItem("Eliminar", btnEliminarProducto_Click)})).Show(dgvProductos, Puntero);
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (!Validar.ValidarUnaPantalla(new PantallaModificarProducto(null).GetType()))
            {
                Interface = new InterfaceUsuario(this);
                RegistroProducto Producto = Interface.ObtenerUnProducto(dgvProductos[1, dgvProductos.SelectedCells[0].RowIndex].Value.ToString());
                Interface.DesplegarPantallaModificarProducto(Producto, LlenarData);
            }
        }
    }
}
