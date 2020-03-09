using System;
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

            await ActivateItemAsync(RaceViewModel);
        }

        public async void GamertagsView()
        {
            if (GamertagsViewModel == null)
                GamertagsViewModel = new GamertagsViewModel();
            await ActivateItemAsync(GamertagsViewModel);
        }
    }
}