
using System.Windows.Forms;

namespace Infoware.Views.Controles
{
    partial class MaintenanceViewBase
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewView1 = new Infoware.Views.Controles.DataGridViewView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblTitulo = new System.Windows.Forms.ToolStripLabel();
            this.txtTextoBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.btnListBuscar = new System.Windows.Forms.ToolStripButton();
            this.sepBuscar = new System.Windows.Forms.ToolStripSeparator();
            this.btnListSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.sepSeleccionar = new System.Windows.Forms.ToolStripSeparator();
            this.btnListNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnListEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnListEliminar = new System.Windows.Forms.ToolStripButton();
            this.tabControlView1 = new Infoware.Views.Controles.TabControlView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnMantCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnMantGuardar = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlView1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(1215, 542);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewView1
            // 
            this.dataGridViewView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewView1.Name = "dataGridViewView1";
            this.dataGridViewView1.RowHeadersWidth = 51;
            this.dataGridViewView1.RowTemplate.Height = 29;
            this.dataGridViewView1.Size = new System.Drawing.Size(403, 515);
            this.dataGridViewView1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTitulo,
            this.txtTextoBuscar,
            this.btnListBuscar,
            this.sepBuscar,
            this.btnListSeleccionar,
            this.sepSeleccionar,
            this.btnListNuevo,
            this.btnListEdit,
            this.toolStripSeparator2,
            this.btnListEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(403, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 24);
            // 
            // txtTextoBuscar
            // 
            this.txtTextoBuscar.Name = "txtTextoBuscar";
            this.txtTextoBuscar.Size = new System.Drawing.Size(100, 27);
            this.txtTextoBuscar.Visible = false;
            // 
            // btnListBuscar
            // 
            this.btnListBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnListBuscar.Image = global::Infoware.Views.Controles.Properties.Resources.search;
            this.btnListBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListBuscar.Name = "btnListBuscar";
            this.btnListBuscar.Size = new System.Drawing.Size(29, 24);
            this.btnListBuscar.Text = "Buscar";
            this.btnListBuscar.Visible = false;
            // 
            // sepBuscar
            // 
            this.sepBuscar.Name = "sepBuscar";
            this.sepBuscar.Size = new System.Drawing.Size(6, 27);
            this.sepBuscar.Visible = false;
            // 
            // btnListSeleccionar
            // 
            this.btnListSeleccionar.Image = global::Infoware.Views.Controles.Properties.Resources.post;
            this.btnListSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListSeleccionar.Name = "btnListSeleccionar";
            this.btnListSeleccionar.Size = new System.Drawing.Size(109, 24);
            this.btnListSeleccionar.Text = "Seleccionar";
            // 
            // sepSeleccionar
            // 
            this.sepSeleccionar.Name = "sepSeleccionar";
            this.sepSeleccionar.Size = new System.Drawing.Size(6, 27);
            // 
            // btnListNuevo
            // 
            this.btnListNuevo.Image = global::Infoware.Views.Controles.Properties.Resources._new;
            this.btnListNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListNuevo.Name = "btnListNuevo";
            this.btnListNuevo.Size = new System.Drawing.Size(76, 24);
            this.btnListNuevo.Text = "Nuevo";
            // 
            // btnListEdit
            // 
            this.btnListEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnListEdit.Image = global::Infoware.Views.Controles.Properties.Resources.open;
            this.btnListEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListEdit.Name = "btnListEdit";
            this.btnListEdit.Size = new System.Drawing.Size(29, 24);
            this.btnListEdit.Text = "Editar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnListEliminar
            // 
            this.btnListEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnListEliminar.Image = global::Infoware.Views.Controles.Properties.Resources.delete;
            this.btnListEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListEliminar.Name = "btnListEliminar";
            this.btnListEliminar.Size = new System.Drawing.Size(29, 24);
            this.btnListEliminar.Text = "Eliminar";
            // 
            // tabControlView1
            // 
            this.tabControlView1.DataSource = null;
            this.tabControlView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlView1.Location = new System.Drawing.Point(0, 27);
            this.tabControlView1.Name = "tabControlView1";
            this.tabControlView1.SelectedIndex = 0;
            this.tabControlView1.Size = new System.Drawing.Size(808, 515);
            this.tabControlView1.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMantCancelar,
            this.btnMantGuardar});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(808, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnMantCancelar
            // 
            this.btnMantCancelar.Image = global::Infoware.Views.Controles.Properties.Resources.cancel;
            this.btnMantCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMantCancelar.Name = "btnMantCancelar";
            this.btnMantCancelar.Size = new System.Drawing.Size(90, 24);
            this.btnMantCancelar.Text = "Cancelar";
            // 
            // btnMantGuardar
            // 
            this.btnMantGuardar.Image = global::Infoware.Views.Controles.Properties.Resources.save;
            this.btnMantGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMantGuardar.Name = "btnMantGuardar";
            this.btnMantGuardar.Size = new System.Drawing.Size(86, 24);
            this.btnMantGuardar.Text = "Guardar";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 482);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 482);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MaintenanceViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MaintenanceViewBase";
            this.Size = new System.Drawing.Size(1215, 542);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnListEliminar;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnMantCancelar;
        private DataGridViewView dataGridViewView1;
        private ErrorProvider errorProvider1;
        private ToolStripButton btnListSeleccionar;
        private ToolStripButton btnListNuevo;
        private ToolStripButton btnListEdit;
        private ToolStripButton btnMantGuardar;
        private TabControlView tabControlView1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripTextBox txtTextoBuscar;
        private ToolStripSeparator sepBuscar;
        private ToolStripButton btnListBuscar;
        private ToolStripSeparator sepSeleccionar;
        private ToolStripLabel lblTitulo;
    }
}
