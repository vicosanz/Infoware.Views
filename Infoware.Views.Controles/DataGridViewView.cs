using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Infoware.Views.Attributes;
using Infoware.Views.Enums;

namespace Infoware.Views.Controles
{
    public class DataGridViewView : DataGridView
    {
        private readonly ContextMenuStrip ContextMenuStrip1;
        private bool _noDataBinding = true;

        public DataGridViewView()
        {
            if (DesignMode) return;
            ContextMenuStrip1 = new ContextMenuStrip();
            ContextMenuStrip = ContextMenuStrip1;
            AutoGenerateColumns = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            if (_noDataBinding)
            {
                ReBind();
            }
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            if (_noDataBinding)
            {
                ReBind();
            }
        }

        private void ReBind()
        {
            if (DesignMode) return;
            try
            {
                ContextMenuStrip1.Items.Clear();
                var attributes = Utils.GetProperties((IList)DataSource, x => x.ShowInList);
                foreach (var attr in attributes)
                {
                    if (attr.Control != EnumControls.None)
                    {
                        ToolStripMenuItem menuItem = new()
                        {
                            Text = attr.Label,
                            Tag = attr,
                            CheckOnClick = true,
                            Checked = !attr.IsOptional,
                            Enabled = attr.IsOptional,
                        };
                        ContextMenuStrip1.Items.Add(menuItem);
                        menuItem.Click += new EventHandler(OnToogleVisibleFields);
                    }
                }
                _noDataBinding = false;

                RefreshColumns();
            }
            catch (Exception)
            {
                _noDataBinding = true;
                Columns.Clear();
                Columns.Add("none", "No existen registros a presentar");
            }
        }

        public void OnToogleVisibleFields(object sender, EventArgs e)
        {
            RefreshColumns();
        }

        private void RefreshColumns()
        {
            Columns.Clear();
            foreach (ToolStripMenuItem menuItem in ContextMenuStrip1.Items)
            {
                var attr = (ShowAsAttribute)menuItem.Tag;
                if (menuItem.Checked)
                {
                    DataGridViewColumn column;
                    if (attr.PropertyInfo.PropertyType.IsEnum && attr.PropertyInfo.PropertyType.IsNullableEnum())
                    {
                        column = new DataGridViewComboBoxColumn();

                        List<KeyValuePair<object, string>> items = Utils.EnumToComboData(attr);

                        ((DataGridViewComboBoxColumn)column).DisplayMember = "Value";
                        ((DataGridViewComboBoxColumn)column).ValueMember = "Key";
                        ((DataGridViewComboBoxColumn)column).DataSource = items;
                    }
                    else if (attr.PropertyInfo.PropertyType.Equals(typeof(bool)))
                    {
                        column = new DataGridViewCheckBoxColumn();
                    }
                    else
                    {
                        column = new DataGridViewTextBoxColumn();
                    }

                    column.ValueType = attr.PropertyInfo.PropertyType;
                    column.DataPropertyName = attr.PropertyInfo.Name;
                    column.HeaderText = attr.Label;

                    Columns.Add(column);
                }

            }
        }
    }
}
