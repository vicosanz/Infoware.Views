using System;
using System.ComponentModel;
using System.Windows.Forms;
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
                lblTitle.Text = _titleText;
                tabControlView1.TitleText = _titleText;
            }
        }

        private string _selectText = "Seleccionar";
        public string SelectText
        {
            get => _selectText;
            set
            {
                _selectText = value;
                btnListSelect.Text = _selectText;
                
            }
        }
        public bool AllowSearch
        {
            get => _allowSearch; 
            set
            {
                _allowSearch = value;
                SearchVisible();
            }
        }
        public bool AllowNew
        {
            get => _allowNew;
            set
            {
                _allowNew = value;
                btnListNew.Visible = _allowNew;
            }
        }

        public bool AllowEdit
        {
            get => _allowEdit;
            set
            {
                _allowEdit = value;
                btnListEdit.Visible = _allowEdit;
            }
        }

        public bool AllowDelete
        {
            get => _allowDelete;
            set
            {
                _allowDelete = value;
                btnListDelete.Visible = _allowDelete;
                sepDelete.Visible = _allowDelete;
            }
        }

        public bool CanSearch => BindingSourceView?.HasMainSourceFunction ?? false;

        public bool CanSelection
        {
            get => canSelection;
            set
            {
                canSelection = value;
                btnListSelect.Visible = canSelection;
                sepSelect.Visible = canSelection;
            }
        }
        internal event EventHandler OnPreAddingNewRecord;
        public event CancelEventHandler OnAddingNewRecord;
        public event EventHandler OnCancelEditRecord;
        public event EventHandler OnCancelShowRecordReadonly;
        public event EventHandler OnRecordSelected;
        public event EventHandler OnNewRecordSaved;
        public event CancelEventHandler OnDeletingRecord;
        public event EventHandler<ShowAsAttribute> OnLinkClicked;
        private IBindingSourceView BindingSourceView;
        private bool _isShowRecordReadonly = false;
        private bool canSelection = true;
        private bool _allowNew = true;
        private bool _allowDelete = true;
        private bool _allowEdit;
        private bool _allowSearch = true;
        private bool _isFindMode = false;

        public void SetBindingSourceView(IBindingSourceView bindingSourceView)
        {
            BindingSourceView = bindingSourceView;
            BindingSourceView.OnMainSourceLoaded += BindingSourceView_OnMainSourceLoaded;
            BindingSourceView.OnFindSourceLoaded += BindingSourceView_OnFindSourceLoaded;
            errorProvider1.DataSource = bindingSourceView.BindingSource;
            dataGridViewView1.DataSource = bindingSourceView.BindingSource;

            tabControlView1.ControlsFunctions = bindingSourceView.ControlsFunctions;
            tabControlView1.DataSource = bindingSourceView.BindingSource;
        }

        private void BindingSourceView_OnFindSourceLoaded(object sender, EventArgs e)
        {
            _isFindMode = true;
            ShowRecordReadonly();
        }

        private void BindingSourceView_OnMainSourceLoaded(object sender, EventArgs e)
        {
            SearchVisible();
        }

        private void SearchVisible()
        {
            txtSearch.Visible = AllowSearch && CanSearch;
            btnListSearch.Visible = AllowSearch && CanSearch;
            sepSearch.Visible = AllowSearch && CanSearch;
        }

        public MaintenanceViewBase()
        {
            InitializeComponent();
            splitContainer1.Panel2Collapsed = true;
            txtSearch.KeyDown += TxtTextoBuscar_KeyDown;
            btnListSearch.Click += BtnListBuscar_Click;
            btnListSelect.Click += BtnListSeleccionar_Click;
            dataGridViewView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewView1.CellDoubleClick += DataGridViewView1_CellDoubleClick;
            dataGridViewView1.KeyDown += DataGridViewView1_KeyDown;
            dataGridViewView1.KeyPress += DataGridViewView1_KeyPress;

            btnListNew.Click += BtnListNuevo_Click;
            btnListDelete.Click += BtnListEliminar_Click;
            btnListEdit.Click += BtnListEdit_Click;
            btnMantSave.Click += BtnMantGuardar_Click;
            btnMantCancel.Click += BtnMantCancelar_Click;
            tabControlView1.OnLinkClicked += TabControlView1_OnLinkClicked;
        }

        private void DataGridViewView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch.Visible)
            {
                if (
                    char.IsWhiteSpace(e.KeyChar) ||
                    char.IsPunctuation(e.KeyChar) ||
                    char.IsSymbol(e.KeyChar) ||
                    char.IsLetterOrDigit(e.KeyChar)
                )
                {
                    e.Handled = true;
                    txtSearch.Focus();
                    txtSearch.Text = e.KeyChar.ToString();
                    txtSearch.SelectionStart = 1;
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
                    if (btnListSelect.Visible)
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
                    if (btnListNew.Visible)
                    {
                        e.Handled = true;
                        BtnListNuevo_Click(sender, EventArgs.Empty);
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    if (btnListDelete.Visible)
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
            BindingSourceView.LoadData(txtSearch.Text);
            dataGridViewView1.Focus();
        }

        private void BtnListNuevo_Click(object sender, EventArgs e)
        {
            OnPreAddingNewRecord?.Invoke(this, e);
            CancelEventArgs adding = new();
            OnAddingNewRecord?.Invoke(sender, adding);
            if (adding.Cancel) return;
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
            btnMantSave.Visible = true;
            tabControlView1.Readonly = false;
            if (_isFindMode && BindingSourceView.HasMainSourceFunction)
            {
                BindingSourceView.LoadData();
            }
            _isFindMode = false;
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
            if (BindingSourceView.Current != null)
            {
                splitContainer1.Panel1Collapsed = true;
            }
        }

        public void ShowRecordReadonly()
        {
            _isShowRecordReadonly = true;
            splitContainer1.Panel1Collapsed = true;
            btnMantSave.Visible = false;
            tabControlView1.Readonly = true;
        }

        private void BtnListEliminar_Click(object sender, EventArgs e)
        {
            CancelEventArgs deleting = new();
            OnDeletingRecord?.Invoke(sender, deleting);
            if (deleting.Cancel) return;
            if (MessageBox.Show("¿Desea eliminar el registro?", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BindingSourceView.RemoveCurrent();
            }
        }

        private void DataGridViewView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CanSelection)
            {
                OnRecordSelected?.Invoke(sender, EventArgs.Empty);
            }
            else
            {
                BtnListEdit_Click(sender, EventArgs.Empty);
            }
        }

        private void BtnListSeleccionar_Click(object sender, EventArgs e)
        {
            OnRecordSelected?.Invoke(sender, e);
        }

        public object Data
        {
            get => BindingSourceView?.BindingSource?.DataSource;
            set
            {
                BindingSourceView?.SetData(value);
            }
        }

        public object ParentObject { get; set; }

    }
}
