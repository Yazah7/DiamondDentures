﻿namespace Presentacion.Recepcion
{
    partial class PantallaRecepcion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbIcono = new System.Windows.Forms.PictureBox();
            this.lblPantallaUsuario = new System.Windows.Forms.Label();
            this.btnAgregarPedido = new System.Windows.Forms.Button();
            this.btnModificarPedido = new System.Windows.Forms.Button();
            this.btnAgregarDentista = new System.Windows.Forms.Button();
            this.btnModificarDentista = new System.Windows.Forms.Button();
            this.lblRegistrarDentista = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRegistrarPedido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerarOrden = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Encabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // Encabezado
            // 
            this.Encabezado.Controls.Add(this.lblPantallaUsuario);
            this.Encabezado.Controls.Add(this.pbIcono);
            this.Encabezado.Size = new System.Drawing.Size(360, 93);
            // 
            // pbIcono
            // 
            this.pbIcono.BackColor = System.Drawing.Color.Transparent;
            this.pbIcono.BackgroundImage = global::Presentacion.Properties.Resources.IconoRecepcion;
            this.pbIcono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcono.Location = new System.Drawing.Point(23, 16);
            this.pbIcono.Margin = new System.Windows.Forms.Padding(0);
            this.pbIcono.Name = "pbIcono";
            this.pbIcono.Size = new System.Drawing.Size(60, 60);
            this.pbIcono.TabIndex = 10;
            this.pbIcono.TabStop = false;
            // 
            // lblPantallaUsuario
            // 
            this.lblPantallaUsuario.AutoSize = true;
            this.lblPantallaUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblPantallaUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPantallaUsuario.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPantallaUsuario.Location = new System.Drawing.Point(99, 34);
            this.lblPantallaUsuario.Name = "lblPantallaUsuario";
            this.lblPantallaUsuario.Size = new System.Drawing.Size(118, 24);
            this.lblPantallaUsuario.TabIndex = 11;
            this.lblPantallaUsuario.Text = "Recepción";
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.BackgroundImage = global::Presentacion.Properties.Resources.IconoPedidoAgregar;
            this.btnAgregarPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarPedido.FlatAppearance.BorderSize = 0;
            this.btnAgregarPedido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarPedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPedido.Location = new System.Drawing.Point(53, 116);
            this.btnAgregarPedido.Name = "btnAgregarPedido";
            this.btnAgregarPedido.Size = new System.Drawing.Size(90, 90);
            this.btnAgregarPedido.TabIndex = 41;
            this.btnAgregarPedido.UseVisualStyleBackColor = true;
            this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // btnModificarPedido
            // 
            this.btnModificarPedido.BackgroundImage = global::Presentacion.Properties.Resources.IconoPedidoModificar;
            this.btnModificarPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificarPedido.FlatAppearance.BorderSize = 0;
            this.btnModificarPedido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnModificarPedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnModificarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPedido.Location = new System.Drawing.Point(218, 116);
            this.btnModificarPedido.Name = "btnModificarPedido";
            this.btnModificarPedido.Size = new System.Drawing.Size(90, 90);
            this.btnModificarPedido.TabIndex = 41;
            this.btnModificarPedido.UseVisualStyleBackColor = true;
            this.btnModificarPedido.Click += new System.EventHandler(this.btnModificarPedido_Click);
            // 
            // btnAgregarDentista
            // 
            this.btnAgregarDentista.BackgroundImage = global::Presentacion.Properties.Resources.IconoDentistaAgregar;
            this.btnAgregarDentista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarDentista.FlatAppearance.BorderSize = 0;
            this.btnAgregarDentista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarDentista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarDentista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDentista.Location = new System.Drawing.Point(53, 267);
            this.btnAgregarDentista.Name = "btnAgregarDentista";
            this.btnAgregarDentista.Size = new System.Drawing.Size(90, 90);
            this.btnAgregarDentista.TabIndex = 41;
            this.btnAgregarDentista.UseVisualStyleBackColor = true;
            this.btnAgregarDentista.Click += new System.EventHandler(this.btnAgregarDentista_Click);
            // 
            // btnModificarDentista
            // 
            this.btnModificarDentista.BackgroundImage = global::Presentacion.Properties.Resources.IconoDentistaModificar;
            this.btnModificarDentista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificarDentista.FlatAppearance.BorderSize = 0;
            this.btnModificarDentista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnModificarDentista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnModificarDentista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarDentista.Location = new System.Drawing.Point(218, 267);
            this.btnModificarDentista.Name = "btnModificarDentista";
            this.btnModificarDentista.Size = new System.Drawing.Size(90, 90);
            this.btnModificarDentista.TabIndex = 41;
            this.btnModificarDentista.UseVisualStyleBackColor = true;
            this.btnModificarDentista.Click += new System.EventHandler(this.btnModificarDentista_Click);
            // 
            // lblRegistrarDentista
            // 
            this.lblRegistrarDentista.AutoSize = true;
            this.lblRegistrarDentista.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrarDentista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRegistrarDentista.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrarDentista.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRegistrarDentista.Location = new System.Drawing.Point(50, 362);
            this.lblRegistrarDentista.Name = "lblRegistrarDentista";
            this.lblRegistrarDentista.Size = new System.Drawing.Size(96, 51);
            this.lblRegistrarDentista.TabIndex = 43;
            this.lblRegistrarDentista.Text = "Agregar\r\nInformación\r\nDentista";
            this.lblRegistrarDentista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(215, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 51);
            this.label2.TabIndex = 43;
            this.label2.Text = "Modificar\r\nInformación\r\nDentista";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegistrarPedido
            // 
            this.lblRegistrarPedido.AutoSize = true;
            this.lblRegistrarPedido.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRegistrarPedido.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrarPedido.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRegistrarPedido.Location = new System.Drawing.Point(60, 219);
            this.lblRegistrarPedido.Name = "lblRegistrarPedido";
            this.lblRegistrarPedido.Size = new System.Drawing.Size(77, 34);
            this.lblRegistrarPedido.TabIndex = 42;
            this.lblRegistrarPedido.Text = "Registrar\r\nPedido";
            this.lblRegistrarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(225, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 34);
            this.label1.TabIndex = 42;
            this.label1.Text = "Modificar\r\nPedido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerarOrden
            // 
            this.btnGenerarOrden.BackgroundImage = global::Presentacion.Properties.Resources.IconoPedidoGenerarOrden;
            this.btnGenerarOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarOrden.FlatAppearance.BorderSize = 0;
            this.btnGenerarOrden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGenerarOrden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGenerarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarOrden.Location = new System.Drawing.Point(135, 420);
            this.btnGenerarOrden.Name = "btnGenerarOrden";
            this.btnGenerarOrden.Size = new System.Drawing.Size(90, 90);
            this.btnGenerarOrden.TabIndex = 41;
            this.btnGenerarOrden.UseVisualStyleBackColor = true;
            this.btnGenerarOrden.Click += new System.EventHandler(this.btnGenerarOrden_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(127, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 51);
            this.label3.TabIndex = 42;
            this.label3.Text = "Generar\r\nOrden De\r\nConfirmación";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PantallaRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(360, 583);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRegistrarPedido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRegistrarDentista);
            this.Controls.Add(this.btnModificarDentista);
            this.Controls.Add(this.btnAgregarDentista);
            this.Controls.Add(this.btnModificarPedido);
            this.Controls.Add(this.btnGenerarOrden);
            this.Controls.Add(this.btnAgregarPedido);
            this.Name = "PantallaRecepcion";
            this.Text = "Recepcion";
            this.Controls.SetChildIndex(this.btnAgregarPedido, 0);
            this.Controls.SetChildIndex(this.btnGenerarOrden, 0);
            this.Controls.SetChildIndex(this.btnModificarPedido, 0);
            this.Controls.SetChildIndex(this.btnAgregarDentista, 0);
            this.Controls.SetChildIndex(this.btnModificarDentista, 0);
            this.Controls.SetChildIndex(this.lblRegistrarDentista, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblRegistrarPedido, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Encabezado, 0);
            this.Encabezado.ResumeLayout(false);
            this.Encabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox pbIcono;
        protected System.Windows.Forms.Label lblPantallaUsuario;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.Button btnModificarPedido;
        private System.Windows.Forms.Button btnAgregarDentista;
        private System.Windows.Forms.Button btnModificarDentista;
        private System.Windows.Forms.Label lblRegistrarDentista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRegistrarPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerarOrden;
        private System.Windows.Forms.Label label3;
    }
}
