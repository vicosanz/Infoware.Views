
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
            this.toolStripList = new System.Windows.Forms.ToolStrip();
            this.lblTitle = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnListSearch = new System.Windows.Forms.ToolStripButton();
            this.sepSearch = new System.Windows.Forms.ToolStripSeparator();
            this.btnListSelect = new System.Windows.Forms.ToolStripButton();
            this.sepSelect = new System.Windows.Forms.ToolStripSeparator();
            this.btnListNew = new System.Windows.Forms.ToolStripButton();
            this.btnListEdit = new System.Windows.Forms.ToolStripButton();
            this.sepDelete = new System.Windows.Forms.ToolStripSeparator();
            this.btnListDelete = new System.Windows.Forms.ToolStripButton();
            this.tabControlView1 = new Infoware.Views.Controles.TabControlView();
            this.toolStripMaintenance = new System.Windows.Forms.ToolStrip();
            this.btnMantCancel = new System.Windows.Forms.ToolStripButton();
            this.btnMantSave = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewView1)).BeginInit();
            this.toolStripList.SuspendLayout();
            this.toolStripMaintenance.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStripList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlView1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStripMaintenance);
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
            this.toolStripList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTitle,
            this.txtSearch,
            this.btnListSearch,
            this.sepSearch,
            this.btnListSelect,
            this.sepSelect,
            this.btnListNew,
            this.btnListEdit,
            this.sepDelete,
            this.btnListDelete});
            this.toolStripList.Location = new System.Drawing.Point(0, 0);
            this.toolStripList.Name = "toolStripList";
            this.toolStripList.Size = new System.Drawing.Size(403, 27);
            this.toolStripList.TabIndex = 2;
            this.toolStripList.Text = "";
            // 
            // lblTitulo
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 24);
            // 
            // txtTextoBuscar
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 27);
            this.txtSearch.Visible = false;
            // 
            // btnListBuscar
            // 
            this.btnListSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnListSearch.Image = global::Infoware.Views.Controles.Properties.Resources.searching_magnifying_glass;
            this.btnListSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListSearch.Name = "btnListSearch";
            this.btnListSearch.Size = new System.Drawing.Size(29, 24);
            this.btnListSearch.Text = "Buscar";
            this.btnListSearch.Visible = false;
            // 
            // sepBuscar
            // 
            this.sepSearch.Name = "sepSearch";
            this.sepSearch.Size = new System.Drawing.Size(6, 27);
            this.sepSearch.Visible = false;
            // 
            // btnListSeleccionar
            // 
            this.btnListSelect.Image = global::Infoware.Views.Controles.Properties.Resources.tick_inside_circle;
            this.btnListSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListSelect.Name = "btnListSelect";
            this.btnListSelect.Size = new System.Drawing.Size(109, 24);
            this.btnListSelect.Text = "Seleccionar";
            // 
            // sepSeleccionar
            // 
            this.sepSelect.Name = "sepSelect";
            this.sepSelect.Size = new System.Drawing.Size(6, 27);
            // 
            // btnListNuevo
            // 
            this.btnListNew.Image = global::Infoware.Views.Controles.Properties.Resources.round_add_button;
            this.btnListNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListNew.Name = "btnListNew";
            this.btnListNew.Size = new System.Drawing.Size(76, 24);
            this.btnListNew.Text = "Nuevo";
            // 
            // btnListEdit
            // 
            this.btnListEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnListEdit.Image = global::Infoware.Views.Controles.Properties.Resources.create_new_pencil_button;
            this.btnListEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListEdit.Name = "btnListEdit";
            this.btnListEdit.Size = new System.Drawing.Size(29, 24);
            this.btnListEdit.Text = "Editar";
            // 
            // sepDelete
            // 
            this.sepDelete.Name = "sepDelete";
            this.sepDelete.Size = new System.Drawing.Size(6, 27);
            // 
            // btnListEliminar
            // 
            this.btnListDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnListDelete.Image = global::Infoware.Views.Controles.Properties.Resources.rubbish_bin_delete_button;
            this.btnListDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListDelete.Name = "btnListDelete";
            this.btnListDelete.Size = new System.Drawing.Size(29, 24);
            this.btnListDelete.Text = "Eliminar";
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
            this.tabControlView1.TitleText = "";
            // 
            // toolStrip2
            // 
            this.toolStripMaintenance.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMaintenance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMantCancel,
            this.btnMantSave});
            this.toolStripMaintenance.Location = new System.Drawing.Point(0, 0);
            this.toolStripMaintenance.Name = "toolStripMaintenance";
            this.toolStripMaintenance.Size = new System.Drawing.Size(808, 27);
            this.toolStripMaintenance.TabIndex = 2;
            this.toolStripMaintenance.Text = "";
            // 
            // btnMantCancelar
            // 
            this.btnMantCancel.Image = global::Infoware.Views.Controles.Properties.Resources.cancel_button;
            this.btnMantCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMantCancel.Name = "btnMantCancel";
            this.btnMantCancel.Size = new System.Drawing.Size(90, 24);
            this.btnMantCancel.Text = "Cancelar";
            // 
            // btnMantGuardar
            // 
            this.btnMantSave.Image = global::Infoware.Views.Controles.Properties.Resources.save_button;
            this.btnMantSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMantSave.Name = "btnMantSave";
            this.btnMantSave.Size = new System.Drawing.Size(86, 24);
            this.btnMantSave.Text = "Guardar";
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
            this.toolStripList.ResumeLayout(false);
            this.toolStripList.PerformLayout();
            this.toolStripMaintenance.ResumeLayout(false);
            this.toolStripMaintenance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStripList;
        private System.Windows.Forms.ToolStripSeparator sepEdition;
        private System.Windows.Forms.ToolStripButton btnListDelete;
        private System.Windows.Forms.ToolStrip toolStripMaintenance;
        private System.Windows.Forms.ToolStripButton btnMantCancel;
        private DataGridViewView dataGridViewView1;
        private ErrorProvider errorProvider1;
        private ToolStripButton btnListSelect;
        private ToolStripButton btnListNew;
        private ToolStripButton btnListEdit;
        private ToolStripButton btnMantSave;
        private TabControlView tabControlView1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripTextBox txtSearch;
        private ToolStripSeparator sepSearch;
        private ToolStripButton btnListSearch;
        private ToolStripSeparator sepSelect;
        private ToolStripLabel lblTitle;
        private ToolStripSeparator sepDelete;
    }
}
