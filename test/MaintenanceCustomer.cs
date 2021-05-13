using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infoware.Views.Attributes;
using Infoware.Views.Controles;

namespace test
{
    public partial class MaintenanceCustomer: MaintenanceViewBase
    {
        private readonly BindingSourceView<CustomerView, Customer> _bindingSourceView = new();

        public MaintenanceCustomer():base()
        {
            SetBindingSourceView(_bindingSourceView);
            OnSavingRecord += MaintenanceCustomer_OnSavingRecord;
            OnUserRecordChanged += MaintenanceCustomer1_OnUserRecordChanged;
        }

        private void MaintenanceCustomer1_OnUserRecordChanged(object sender, ShowAsAttribute e)
        {
            if (e.PropertyInfo.Name == nameof(CustomerView.TypePerson))
            {
                _bindingSourceView.Current.Income = _bindingSourceView.Current.TypePerson == EnumTypePerson.Fast ? 500 : 600;
            }
        }

        private void MaintenanceCustomer_OnSavingRecord(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_bindingSourceView.Current.CustomerCode != null)
            {
                _bindingSourceView.Current.CustomerCode = _bindingSourceView.Current.CustomerCode.Replace("-", "");
            }
        }

        public void LoadData()
        {
            List<CustomerView> data = new();
            data.Add(new CustomerView(new Customer()
            {
                Name = "Peter"
            }));
            _bindingSourceView.SetData(data);
        }
    }
}
