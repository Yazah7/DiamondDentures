﻿using Entidad;
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
    public partial class PantallaAdministrarMateriales : Control.Pantalla
    {
        InterfaceUsuario Interface;
        enum Búsqueda { Total, Clave, Personalizada };

        public PantallaAdministrarMateriales()
        {
            InitializeComponent();
            InitializeComponent2();
            InitializeComponent3();
        }

        private void InitializeComponent3()
        {
            Interface = new InterfaceUsuario(this);
            LlenarData(Búsqueda.Total);
        }

        private void LlenarData(Búsqueda Tipo)
        {
            int Col = 0, Ren = 0;
            if (dgvMateriales.SelectedCells.Count > 0)
            {
                DataGridViewCell Cell = dgvMateriales.SelectedCells[0];
                Col = Cell.ColumnIndex;
                Ren = Cell.RowIndex;
            }
            dgvMateriales.Rows.Clear();
            RegistroMaterial[] temp = null;
            if (Tipo == Búsqueda.Total)
                temp = Interface.ObtenerMateriales();
            else
            {
                if (Tipo == Búsqueda.Clave)
                    temp = Interface.BuscarUnMaterial(new RegistroMaterial(Convert.ToInt32(tbClave.Text), "", -1, -1));
                else
                    if (Tipo == Búsqueda.Personalizada)
                    temp = Interface.BuscarUnMaterial(new RegistroMaterial(-1, tbNombre.Text, string.IsNullOrWhiteSpace(tbPrecio.Text) ? -1 : Convert.ToInt32(tbPrecio.Text), -1));
            }
                dgvMateriales.RowCount = temp?.Length ?? 0;
            if (temp != null)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    dgvMateriales.Rows[i].DefaultCellStyle.BackColor = temp[i].Activo == 1 ? Color.LightGreen : Color.LightSalmon;
                    dgvMateriales[0, i].Value = temp[i].Clave;
                    dgvMateriales[1, i].Value = temp[i].Nombre;
                    dgvMateriales[2, i].Value = "$" + temp[i].Precio.ToString("N2");
                }
            }
            if (dgvMateriales.SelectedCells.Count > 0)
            {
                dgvMateriales.CurrentCell = dgvMateriales[Col > dgvMateriales.ColumnCount ? 0 : Col, Ren > dgvMateriales.RowCount ? 0 : Ren];
                dgvMateriales.Focus();
            }
        }

        private void LlenarData()
        {
            LlenarData(Búsqueda.Total);
        }

        private void ActivarMaterial()
        {
            Interface = new InterfaceUsuario(this);
            if (Interface.ActivarMaterial(Convert.ToInt32(dgvMateriales[0, dgvMateriales.CurrentRow.Index].Value)))
                MessageBox.Show("Material activado con éxito", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                Validar.MensajeErrorBaseDeDatos();
            LlenarData(Búsqueda.Total);
        }

        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            if (!Validar.ValidarUnaPantalla(new PantallaAgregarMaterial().GetType()))
            {
                Interface = new InterfaceUsuario(this);
                Interface.DesplegarPantallaAgregarMaterial(LlenarData);
            }
        }

        private void btnModificarMaterial_Click(object sender, EventArgs e)
        {
            if (!Validar.ValidarUnaPantalla(new PantallaModificarMaterial(null).GetType()))
            {
                Interface = new InterfaceUsuario(this);
                RegistroMaterial Producto = Interface.ObtenerUnMaterial(Convert.ToInt32(dgvMateriales[0, dgvMateriales.CurrentRow.Index].Value));
                Interface.DesplegarPantallaModificarMaterial(Producto, LlenarData);
            }
        }

        private void dgvMateriales_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvMateriales.CurrentCell = dgvMateriales[e.ColumnIndex, e.RowIndex];
                Point Puntero = dgvMateriales.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                Puntero.X += e.X;
                Puntero.Y += e.Y;
                new ContextMenu((new MenuItem[] { new MenuItem("Activar", new EventHandler(delegate(object sender2, EventArgs e2) { ActivarMaterial(); })),
                                                  new MenuItem("Modificar", btnModificarMaterial_Click),
                                                  new MenuItem("Eliminar", btnEliminarMaterial_Click)})).Show(dgvMateriales, Puntero);
            }
        }

        private void btnEliminarMaterial_Click(object sender, EventArgs e)
        {
            Interface = new InterfaceUsuario(this);
            if (DialogResult.Yes == MessageBox.Show("Realmente desea eliminar el material " + dgvMateriales[1, dgvMateriales.SelectedCells[0].RowIndex].Value + "?", "AVISO", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                if (Interface.EliminarMaterial(Convert.ToInt32(dgvMateriales[0, dgvMateriales.SelectedCells[0].RowIndex].Value)))
                {
                    MessageBox.Show("Material eliminado con éxito", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LlenarData(Búsqueda.Total);
                }
                else
                    Validar.MensajeErrorBaseDeDatos();
            }
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
                LlenarData(Búsqueda.Personalizada);
        }

        private void tbClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarSoloNumeros(sender as TextBox, e);
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarPrecio(sender as TextBox, e);
        }
    }
}
