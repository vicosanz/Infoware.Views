﻿using System;
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
        [ShowAs(EnumControls.TextBox, Size = 38, Format ="0.00")]
        [Display(Name = "Income:")]

        public decimal Income { get; set; }



        public CustomerView(Customer customer) :base(customer, true)
        {
            MapFromDomain();
        }

        private void MapFromDomain()
        {
            Name = Domain_.Name;
            Income = Domain_.Income;
        }


        public override void RevertFromDomain()
        {
            MapFromDomain();
        }

        public override Customer UpdateDomain()
        {
            Domain_.Name = Name;
            Domain_.Income = Income;
            return Domain_;
        }
    }
}
