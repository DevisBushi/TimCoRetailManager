using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IEventAggregator _events;
        private readonly SalesViewModel _salesVm;
        private readonly ILoggedInUserModel _user;


        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, ILoggedInUserModel user)
        {
            _events = events;
            _salesVm = salesVM;
            _user = user;
#pragma warning disable CS0618 // Type or member is obsolete
            _events.Subscribe(this);
#pragma warning restore CS0618 // Type or member is obsolete
            ActivateItemAsync(IoC.Get<LoginViewModel>());

        }

        public bool IsLoggedIn
        {
            get
            {
                bool output = false;
                if (string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }

                return output;
            }
        }
        
        public sealed override Task ActivateItemAsync(object item, CancellationToken cancellationToken = new CancellationToken())
        {
            return base.ActivateItemAsync(item, cancellationToken);
        }

        public void ExitApplication()
        {
            TryCloseAsync();
        }

        public void LogOut()
        {
            _user.LogOffUser();
            ActivateItemAsync(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
        
        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVm);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
