﻿using Entidad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Validaciones;

namespace Presentacion.Recepcion
{
    public partial class PantallaPedirInformación : Control.Pantalla
    {
        Validar Validacion;
        public PantallaPedirInformación()
        {
            InitializeComponent();
        }

        public RegistroProducto PedirProducto(out bool Cancelado)
        {
            InterfaceUsuario Interface = new InterfaceUsuario(this);
            Validacion = new Validar(this);
            pbIcono.BackgroundImage = Properties.Resources.IconoProceso;
            tbNumEmpleado.MaxLength = 8;
            lblInfo.Text = "Ingrese clave del producto a eliminar";
            Text = lblPedir.Text = lblTitulo.Text = "#Producto";
            AlinearCentroHorizontal(lblInfo, lblPedir);
            bool Cerrado = true;
            tbNumEmpleado.KeyPress += delegate (object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 13 || e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    if (!Validacion.ValidarTextBox(tbNumEmpleado))
                    {
                        Close();
                        Cerrado = false;
                    }
                    if (e.KeyChar == Convert.ToChar(Keys.Escape))
                    {
                        Close();
                        Cerrado = true;
                    }
                }
                else
                {
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                        e.Handled = true;
                }
            };
            ShowDialog();
            Cancelado = Cerrado;
            RegistroProducto[] temp = null;
            if (!Cerrado)
                temp = Interface.BuscarUnProducto(new RegistroProducto(Convert.ToInt32(tbNumEmpleado.Text== "" ? "-2" : tbNumEmpleado.Text), "", -1, -1, 1));
            return temp?[0] ?? null;
        }

        public RegistroMaterial PedirMaterial(out bool Cancelado)
        {
            InterfaceUsuario Interface = new InterfaceUsuario(this);
            Validacion = new Validar(this);
            pbIcono.BackgroundImage = Properties.Resources.IconoMaterial;
            tbNumEmpleado.MaxLength = 8;
            lblInfo.Text = "Ingrese clave del material a eliminar";
            Text = lblPedir.Text = lblTitulo.Text = "#material";
            AlinearCentroHorizontal(lblInfo, lblPedir);
            bool Cerrado = true;
            tbNumEmpleado.KeyPress += delegate (object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 13 || e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    if (!Validacion.ValidarTextBox(tbNumEmpleado))
                    {
                        Close();
                        Cerrado = false;
                    }
                    if (e.KeyChar == Convert.ToChar(Keys.Escape))
                    {
                        Close();
                        Cerrado = true;
                    }
                }
                else
                {
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                        e.Handled = true;
                }
            };
            ShowDialog();
            Cancelado = Cerrado;
            RegistroMaterial [] temp = null;
            if (!Cerrado)
                temp = Interface.BuscarUnMaterial(new RegistroMaterial(Convert.ToInt32(tbNumEmpleado.Text == "" ? "-2" : tbNumEmpleado.Text), "", -1, -1));
            return temp?[0] ?? null;
        }

        public RegistroPedido PedirPedido(out bool Cancelado)
        {
            InterfaceUsuario Interface = new InterfaceUsuario(this);
            Validacion = new Validar(this);
            tbNumEmpleado.MaxLength = 10;
            bool Cerrado = true;
            tbNumEmpleado.KeyPress += delegate (object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 13 || e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    if (!Validacion.ValidarTextBox(tbNumEmpleado))
                    {
                        Close();
                        Cerrado = false;
                    }
                    if (e.KeyChar == Convert.ToChar(Keys.Escape))
                    {
                        Close();
                        Cerrado = true;
                    }
                }
            };
            ShowDialog();
            Cancelado = Cerrado;
            RegistroPedido temp = null;
            if (!Cerrado)
                temp = Interface.ObtenerUnPedido(tbNumEmpleado.Text);
            return temp;
        }

        public RegistroDentista PedirDentista(out bool Cancelado)
        {
            InterfaceUsuario Interface = new InterfaceUsuario(this);
            Validacion = new Validar(this);
            pbIcono.BackgroundImage = Properties.Resources.IconoDentista;
            tbNumEmpleado.MaxLength = 10;
            lblInfo.Text = "Ingrese clave del dentista a modificar";
            Text = lblPedir.Text = lblTitulo.Text = "Cédula Dentista";
            AlinearCentroHorizontal(lblInfo, lblPedir);
            bool Cerrado = true;
            tbNumEmpleado.KeyPress += delegate (object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 13 || e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    if (!Validacion.ValidarTextBox(tbNumEmpleado))
                    {
                        Close();
                        Cerrado = false;
                    }
                    if (e.KeyChar == Convert.ToChar(Keys.Escape))
                    {
                        Close();
                        Cerrado = true;
                    }
                }
            };
            ShowDialog();
            Cancelado = Cerrado;
            RegistroDentista temp = null;
            if (!Cerrado)
                temp = Interface.ObtenerUnDentista(tbNumEmpleado.Text);
            return temp;
        }
    }
}
