using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Infoware.Views.Enums;

namespace Infoware.Views.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class ShowAsAttribute : Attribute
    {
        public static string GeneralName = "---General";
        public EnumControls Control { get; internal set; }
        public bool ShowInEdition { get; set; } = true;
        public bool ShowInList { get; set; } = true;
        public bool IsOptional { get; set; }
        //public string? Field { get; set; }
        public string Category { get; set; } = GeneralName;
        public bool IsDefaultValue { get; set; }
        public bool IsDefaultId { get; set; }
        public string UpdateField { get; set; } = null!;
        public int Size { get; set; }
        public DisplayAttribute DisplayAttribute { get; set; }
        public string Label => DisplayAttribute?.GetName() ?? PropertyInfo.Name;

        public PropertyInfo PropertyInfo { get; set; }

        public ShowAsAttribute(EnumControls enumControl)
        {
            Control = enumControl;
        }

    }
}