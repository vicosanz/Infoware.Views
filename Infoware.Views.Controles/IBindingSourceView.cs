using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Infoware.Views;
using Infoware.Views;

namespace Infoware.Views.Controles
{
    public interface IBindingSourceView
    {
        public BindingSource BindingSource { get; set; }
        IView Current { get; }
        string DisplayMember { get; }
        string ValueMember { get; }

        //void LoadData();
        void LoadData(string searchText);
        void RemoveCurrent();
        void RevertCurrent();
        void SyncCurrent();
        void AddControl(string property, Func<string, MaintenanceViewBase> p);
        void SetData(object data);

        public Dictionary<string, Func<string, MaintenanceViewBase>> ControlsFunctions { get; set; }
        bool HasMainSourceFunction { get; }
        public event EventHandler OnMainSourceLoaded;
    }
}