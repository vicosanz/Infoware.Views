using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Infoware.Views.Controles
{
    public partial class BindingSourceView<TView, TDomain> : Component, IBindingSourceView
        where TView : ViewBase<TDomain>
    {
        public BindingSourceView()
        {
            InitializeComponent();
            BindingSource.CurrentItemChanged += BindingSource1_CurrentItemChanged;
        }

        public event EventHandler CurrentItemChanged;

        private void BindingSource1_CurrentItemChanged(object sender, EventArgs e)
        {
            CurrentItemChanged?.Invoke(this, EventArgs.Empty);
        }

        public BindingSourceView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            BindingSource.CurrentItemChanged += BindingSource1_CurrentItemChanged;
        }

        public BindingSource BindingSource { get; set; }

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
            if (Current is null) return;
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
            if (Current is null) return;
            if (!Current.IsNewRecord)
            {
                Current.Remove();
            }
            BindingSource.Remove(Current);
        }

        #region "Sources"
        private Dictionary<string, Func<string, object>> SourcesFunctions { get; set; } = new();
        private Func<TView, object> FindFunction { get; set; }
        private bool _hasMainSourceFunction = false;

        bool IBindingSourceView.HasMainSourceFunction => _hasMainSourceFunction;

        public void AddMainSource(Func<string, object> p)
        {
            SourcesFunctions.Remove("__main__");
            SourcesFunctions.Add("__main__", p);
            _hasMainSourceFunction = true;
        }

        public void AddFindSource(Func<TView, object> p)
        {
            FindFunction = p;
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

        public event EventHandler OnFindSourceLoaded;
        public void Find(TView view)
        {
            var result = (TView)FindFunction.Invoke(view);
            var listResult = new List<TView>
            {
                result
            };
            BindingSource.DataSource = listResult;
            OnFindSourceLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void SetData(object data)
        {
            BindingSource.DataSource = data;
            OnMainSourceLoaded?.Invoke(this, EventArgs.Empty);
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
