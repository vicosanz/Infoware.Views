using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infoware.Views;

namespace Infoware.Views.Controles
{
    public partial class BindingSourceView<TView, TDomain> : Component, IBindingSourceView
        where TView : ViewBase<TDomain>
    {
        public BindingSourceView()
        {
            InitializeComponent();
        }

        public BindingSourceView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public BindingSource BindingSource { get => bindingSource1; set => bindingSource1 = value; }

        public Dictionary<string, object> Sources { get; internal set; } = new();

        public TView Current => (TView)BindingSource.Current;

        IView IBindingSourceView.Current => Current;

        public string DisplayMember { get; private set; }
        public string ValueMember { get; private set; }

        public void SyncCurrent()
        {
            Current.SaveChanges();
            BindingSource.ResetCurrentItem();
        }

        public void RevertCurrent()
        {
            if (Current.IsNewRecord)
            {
                RemoveCurrent();
            }
            else
            {
                Current.RevertFromDomain();
            }
            BindingSource.ResetCurrentItem();
        }

        public void AddNew(TView newRecord)
        {
            BindingSource.Add(newRecord);
            BindingSource.MoveLast();
        }

        public void RemoveCurrent()
        {
            if (!Current.IsNewRecord)
            {
                Current.Remove();
            }
            BindingSource.Remove(Current);
        }

        #region "Sources"
        private Dictionary<string, Func<string, object>> SourcesFunctions { get; set; } = new();
        bool _hasMainSourceFunction = false;
        bool IBindingSourceView.HasMainSourceFunction => _hasMainSourceFunction;

        public void AddMainSource(Func<string, object> p)
        {
            SourcesFunctions.Remove("__main__");
            SourcesFunctions.Add("__main__", p);
            _hasMainSourceFunction = true;
        }

        public void AddSources(string key, Func<string, object> p)
        {
            SourcesFunctions.Add(key, p);
        }

        public event EventHandler OnMainSourceLoaded;
        public void LoadData(string searchText = null)
        {
            foreach (var source in SourcesFunctions)
            {
                var result = source.Value.Invoke(searchText);
                if (source.Key == "__main__")
                {
                    BindingSource.DataSource = result;
                    OnMainSourceLoaded?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    Sources.Add(source.Key, result);
                }
            }
        }

        public void SetData(object data)
        {
            BindingSource.DataSource = data;
        }
        #endregion

        #region Controls
        public Dictionary<string, Func<string, MaintenanceViewBase>> ControlsFunctions { get; set; } = new();

        public void AddControl(string property, Func<string, MaintenanceViewBase> p)
        {
            ControlsFunctions.Add(property, p);
        }
        #endregion
    }
}
