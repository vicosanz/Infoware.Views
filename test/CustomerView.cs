using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infoware.Views;
using Infoware.Views.Attributes;
using Infoware.Views.Enums;

namespace test
{
    public class CustomerView : GenericView<Customer>
    {
        [Required]
        [ShowAs(EnumControls.TextBox, Size = 38)]
        [Display(Name = "Name:")]

        public string Name { get; set; }

        [Required]
        [ShowAs(EnumControls.TextBox, Size = 10, Format ="0.00")]
        [Display(Name = "Income:")]

        public decimal Income { get; set; }

        [Required]
        [ShowAs(EnumControls.ComboBox, Size = 15)]
        [Display(Name = "What kind of person are you?:")]
        public EnumTypePerson TypePerson { get; set; }

        [Required]
        [ShowAs(EnumControls.MaskedTextBox, Size = 15, Format = "000-000")]
        [Display(Name = "Enter your customer code?:")]
        public string CustomerCode { get; set; }

        [Required]
        [ShowAs(EnumControls.DateTimePicker, Size = 15, Format = "dd/MM/yyyy")]
        [Display(Name = "Customer since:")]
        public DateTime CustomerSince { get; set; }

        public CustomerView(Customer customer) :base(customer, true)
        {
            MapFromDomain();
        }

        private void MapFromDomain()
        {
            Name = Domain_.Name;
            Income = Domain_.Income;
            TypePerson = Domain_.TypePerson;
            CustomerCode = Domain_.CustomerCode;
            CustomerSince = Domain_.CustomerSince;
        }


        public override void RevertFromDomain()
        {
            MapFromDomain();
        }

        public override Customer UpdateDomain()
        {
            Domain_.Name = Name;
            Domain_.Income = Income;
            Domain_.TypePerson = TypePerson;
            Domain_.CustomerCode = CustomerCode;
            Domain_.CustomerSince = CustomerSince;
            return Domain_;
        }
    }
}
