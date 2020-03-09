using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace TRPC_Core.ViewModels
{
    public class RaceViewModel: Screen
    {

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Omg");
            return base.OnActivateAsync(cancellationToken);
        }
    }
}