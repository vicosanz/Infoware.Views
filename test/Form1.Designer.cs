
namespace test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maintenanceCustomer1 = new test.MaintenanceCustomer();
            this.SuspendLayout();
            // 
            // maintenanceCustomer1
            // 
            this.maintenanceCustomer1.AllowDelete = true;
            this.maintenanceCustomer1.AllowEdit = true;
            this.maintenanceCustomer1.AllowNew = true;
            this.maintenanceCustomer1.AllowSearch = true;
            this.maintenanceCustomer1.CanSelection = false;
            this.maintenanceCustomer1.Data = null;
            this.maintenanceCustomer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maintenanceCustomer1.Location = new System.Drawing.Point(0, 0);
            this.maintenanceCustomer1.Name = "maintenanceCustomer1";
            this.maintenanceCustomer1.ParentObject = null;
            this.maintenanceCustomer1.SelectText = "Seleccionar";
            this.maintenanceCustomer1.Size = new System.Drawing.Size(800, 450);
            this.maintenanceCustomer1.TabIndex = 0;
            this.maintenanceCustomer1.TitleText = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.maintenanceCustomer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaintenanceCustomer maintenanceCustomer1;
    }
}

