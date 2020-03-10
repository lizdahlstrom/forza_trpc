using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRPC_Core.Models;
using TRPC_Core.ViewModels;

namespace TRPC_Core
{
    public class ShellViewModel : Conductor<Object>
    {
        public RaceViewModel RaceViewModel = new RaceViewModel();
        public GamertagsViewModel GamertagsViewModel;

        public async void RaceEntry()
        {
            GamertagsViewModel?.SaveData();
            RaceViewModel.UpdateGamertagsData();
            await ActivateItemAsync(RaceViewModel);
        }

        public async void GamertagsView()
        {
            if (GamertagsViewModel == null)
                GamertagsViewModel = new GamertagsViewModel();
            await ActivateItemAsync(GamertagsViewModel);
        }

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            GamertagsViewModel?.SaveData();
            return base.OnDeactivateAsync(close, cancellationToken);
        }

    }
}