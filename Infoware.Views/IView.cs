using System.ComponentModel;

namespace Infoware.Views
{
    public interface IView : IDataErrorInfo
    {
        bool IsNewRecord { get; set; }
    }
}