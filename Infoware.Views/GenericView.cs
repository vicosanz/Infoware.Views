using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infoware.Views
{
    public abstract class GenericView<TDomain> : ViewBase<TDomain>
    {
        protected GenericView(TDomain domain, bool isNewRecord = false) : base(domain, isNewRecord)
        {
        }

        public override bool SaveChanges()
        {
            UpdateDomain();
            IsNewRecord = false;
            return true;
        }

        public override bool Remove()
        {
            return true;
        }

        public override bool Validate(string property, List<ValidationResult> results)
        {
            return true;
        }
    }
}
