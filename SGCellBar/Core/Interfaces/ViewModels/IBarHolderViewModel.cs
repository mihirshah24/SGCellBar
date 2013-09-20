using SGCellBar.Core.Interfaces.ViewModels.Common;
using SGCellBar.Core.Interfaces.Views;

namespace SGCellBar.Core.Interfaces.ViewModels
{
    /// <summary />
    public interface IBarHolderViewModel : IViewModel<IBarHolderView>
    {
        void Initialize();
    }
}