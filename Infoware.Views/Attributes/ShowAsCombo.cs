using Infoware.Views.Enums;

namespace Infoware.Views.Attributes
{
    public class ShowAsComboAttribute : ShowAsAttribute
    {
        public ShowAsComboAttribute(string updateField) : base(EnumControls.ComboBox)
        {
            UpdateField = updateField;
        }
    }
}
