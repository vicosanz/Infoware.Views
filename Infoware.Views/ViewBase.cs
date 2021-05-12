using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Infoware.Views
{
    public abstract class ViewBase<TDomain> : IView
    {
        protected ViewBase(TDomain domain, bool isNewRecord = false)
        {
            Domain_ = domain;
            IsNewRecord = isNewRecord;
        }

        #region Domain
        protected TDomain Domain_;
        public TDomain GetDomain() => Domain_;
        public bool IsNewRecord { get; set; }

        public abstract TDomain UpdateDomain();
        public abstract void RevertFromDomain();
        #endregion

        #region Operations
        public abstract bool SaveChanges();
        public abstract bool Remove();
        #endregion

        #region Validations
        [Browsable(false)]
        public string this[string property]
        {
            get
            {
                var propertyDescriptor = TypeDescriptor.GetProperties(this)[property];
                if (propertyDescriptor == null)
                    return string.Empty;

                var results = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(
                                          propertyDescriptor.GetValue(this),
                                          new ValidationContext(this, null, null) { MemberName = property },
                                          results);
                var result2 = Validate(property, results);

                if (!result || !result2)
                    return results.First().ErrorMessage;

                return string.Empty;
            }
        }

        [Browsable(false)]
        public string Error
        {
            get
            {
                var results = new List<ValidationResult>();
                Validate(null, results);

                var result = Validator.TryValidateObject(this,
                    new ValidationContext(this, null, null), results, true);
                if (!result)
                    return string.Join("\n", results.Select(x => x.ErrorMessage));
                else
                    return null;
            }
        }

        public bool Validate(string property, List<ValidationResult> results)
        {
            return true;
        }
        #endregion

    }
}