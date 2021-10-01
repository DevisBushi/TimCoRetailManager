using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.EventModels;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IEventAggregator _events;
        private readonly SalesViewModel _salesVm;
        private readonly SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, SimpleContainer container)
        {
            _events = events;
            _salesVm = salesVM;
            _container = container;
#pragma warning disable CS0618 // Type or member is obsolete
            _events.Subscribe(this);
#pragma warning restore CS0618 // Type or member is obsolete
            ActivateItemAsync(_container.GetInstance<LoginViewModel>());


        }

        public sealed override Task ActivateItemAsync(object item, CancellationToken cancellationToken = new CancellationToken())
        {
            return base.ActivateItemAsync(item, cancellationToken);
        }

        
        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVm);
        }
    }
}
