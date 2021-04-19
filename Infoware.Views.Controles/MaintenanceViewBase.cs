using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infoware.Views;
using Infoware.Views.Attributes;

namespace Infoware.Views.Controles
{
    public partial class MaintenanceViewBase : UserControl
    {
        private string _titleText = "";
        public string TitleText
        {
            get => _titleText;
            set
            {
                _titleText = value;
                lblTitulo.Text = _titleText;
                tabControlView1.TitleText = _titleText;
            }
        }

        private string _selecteText = "Seleccionar";
        public string SelectText
        {
            get => _selecteText;
            set
            {
                _selecteText = value;
                btnListSeleccionar.Text = _selecteText;
            }
        }
        public bool AllowSearch { get; set; } = true;
        public bool AllowNew
        {
            get => _allowNew; 
            set
            {
                _allowNew = value;
                btnListNuevo.Visible = _allowNew;
            }
        }
        public bool AllowDelete
        {
            get => _allowDelete; 
            set
            {
                _allowDelete = value;
                btnListEliminar.Visible = _allowDelete;
            }
        }
        public bool CanSearch
        {
            get => BindingSourceView is null ? false : BindingSourceView.HasMainSourceFunction;
        }

        public bool CanSelection
        {
            get => canSelection;
            set
            {
                canSelection = value;
                btnListSeleccionar.Visible = canSelection;
                sepSeleccionar.Visible = canSelection;
            }
        }
        public event EventHandler OnPreparingAddingNewRecord;
        public event EventHandler OnAddingNewRecord;
        public event EventHandler OnCancelEditRecord;
        public event EventHandler OnCancelShowRecordReadonly;
        public event EventHandler OnRecordSelected;
        public event EventHandler OnNewRecordSaved;
        public event EventHandler<ShowAsAttribute> OnLinkClicked;
        private IBindingSourceView BindingSourceView;
        private bool _isShowRecordReadonly = false;
        private bool canSelection = true;
        private bool _allowNew = true;
        private bool _allowDelete = true;

        public void SetBindingSourceView(IBindingSourceView bindingSourceView)
        {
            BindingSourceView = bindingSourceView;
            BindingSourceView.OnMainSourceLoaded += BindingSourceView_OnMainSourceLoaded;
            errorProvider1.DataSource = bindingSourceView.BindingSource;
            dataGridViewView1.DataSource = bindingSourceView.BindingSource;

            tabControlView1.ControlsFunctions = bindingSourceView.ControlsFunctions;
            tabControlView1.DataSource = bindingSourceView.BindingSource;
        }

        private void BindingSourceView_OnMainSourceLoaded(object sender, EventArgs e)
        {
            txtTextoBuscar.Visible = AllowSearch && CanSearch;
            btnListBuscar.Visible = AllowSearch && CanSearch;
            sepBuscar.Visible = AllowSearch && CanSearch;
        }

        public MaintenanceViewBase()
        {
            InitializeComponent();
            splitContainer1.Panel2Collapsed = true;
            txtTextoBuscar.KeyDown += TxtTextoBuscar_KeyDown;
            btnListBuscar.Click += BtnListBuscar_Click;
            btnListSeleccionar.Click += BtnListSeleccionar_Click;
            dataGridViewView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewView1.CellDoubleClick += DataGridViewView1_CellDoubleClick;
            dataGridViewView1.KeyDown += DataGridViewView1_KeyDown;
            dataGridViewView1.KeyPress += DataGridViewView1_KeyPress;

            btnListNuevo.Click += BtnListNuevo_Click;
            btnListEliminar.Click += BtnListEliminar_Click;
            btnListEdit.Click += BtnListEdit_Click;
            btnMantGuardar.Click += BtnMantGuardar_Click;
            btnMantCancelar.Click += BtnMantCancelar_Click;
            tabControlView1.OnLinkClicked += TabControlView1_OnLinkClicked;
        }

        private void DataGridViewView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTextoBuscar.Visible)
            {
                if (
                    char.IsWhiteSpace(e.KeyChar) ||
                    char.IsPunctuation(e.KeyChar) ||
                    char.IsSymbol(e.KeyChar) ||
                    char.IsLetterOrDigit(e.KeyChar)
                )
                {
                    e.Handled = true;
                    txtTextoBuscar.Focus();
                    txtTextoBuscar.Text = e.KeyChar.ToString();
                    txtTextoBuscar.SelectionStart = 1;
                }
            }
        }

        private void TxtTextoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    BtnListBuscar_Click(sender, EventArgs.Empty);
                }
            }
        }

        private void DataGridViewView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (btnListSeleccionar.Visible)
                    {
                        e.Handled = true;
                        BtnListSeleccionar_Click(sender, EventArgs.Empty);
                    }
                    else if (btnListEdit.Visible)
                    {
                        e.Handled = true;
                        BtnListEdit_Click(sender, EventArgs.Empty);
                    }
                }
                else if (e.KeyCode == Keys.Insert)
                {
                    if (btnListNuevo.Visible)
                    {
                        e.Handled = true;
                        BtnListNuevo_Click(sender, EventArgs.Empty);
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    if (btnListEliminar.Visible)
                    {
                        e.Handled = true;
                        BtnListEliminar_Click(sender, EventArgs.Empty);
                    }
                }
            }
        }

        private void TabControlView1_OnLinkClicked(object sender, ShowAsAttribute e)
        {
            OnLinkClicked?.Invoke(sender, e);
        }

        private void BtnListBuscar_Click(object sender, EventArgs e)
        {
            BindingSourceView.LoadData(txtTextoBuscar.Text);
            dataGridViewView1.Focus();
        }

        private void BtnListNuevo_Click(object sender, EventArgs e)
        {
            OnPreparingAddingNewRecord?.Invoke(this, e);
            OnAddingNewRecord?.Invoke(sender, e);
            splitContainer1.Panel1Collapsed = true;
        }

        private void BtnMantCancelar_Click(object sender, EventArgs e)
        {
            OnCancelEditRecord?.Invoke(sender, e);
            BindingSourceView.RevertCurrent();
            splitContainer1.Panel2Collapsed = true;

            if (_isShowRecordReadonly)
            {
                CancelReadonlyRecordMode();
            }
        }

        public void CancelReadonlyRecordMode()
        {
            splitContainer1.Panel2Collapsed = true;
            _isShowRecordReadonly = false;
            btnMantGuardar.Visible = true;
            tabControlView1.Readonly = false;
            OnCancelShowRecordReadonly?.Invoke(this, EventArgs.Empty);
        }

        private void BtnMantGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsNew = BindingSourceView.Current.IsNewRecord;
                BindingSourceView.BindingSource.EndEdit();
                if (BindingSourceView.Current.Error != null)
                {
                    throw new Exception(BindingSourceView.Current.Error);
                }
                BindingSourceView.SyncCurrent();
                if (IsNew)
                {
                    OnNewRecordSaved?.Invoke(sender, e);
                }
                splitContainer1.Panel2Collapsed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void BtnListEdit_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        public void ShowRecordReadonly()
        {
            _isShowRecordReadonly = true;
            splitContainer1.Panel1Collapsed = true;
            btnMantGuardar.Visible = false;
            tabControlView1.Readonly = true;
        }

        private void BtnListEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el registro?", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BindingSourceView.RemoveCurrent();
            }
        }

        private void DataGridViewView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnRecordSelected?.Invoke(sender, e);
        }

        private void BtnListSeleccionar_Click(object sender, EventArgs e)
        {
            OnRecordSelected?.Invoke(sender, e);
        }

        public object Data
        {
            get => BindingSourceView.BindingSource.DataSource;
            set
            {
                BindingSourceView.SetData(value);
            }
        }

        public object ParentObject { get; set; }

    }
}
