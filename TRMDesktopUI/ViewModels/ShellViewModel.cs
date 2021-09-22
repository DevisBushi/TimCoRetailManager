using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginVM;

        // ReSharper disable once InconsistentNaming
        public ShellViewModel(LoginViewModel loginVM)
        {
            _loginVM = loginVM;
            ActivateItemAsync(_loginVM);


        }

        public sealed override Task ActivateItemAsync(object item, CancellationToken cancellationToken = new CancellationToken())
        {
            return base.ActivateItemAsync(item, cancellationToken);
        }
    }
}
