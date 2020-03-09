using System;
using Caliburn.Micro;
using TRPC_Core.Models;
using TRPC_Core.ViewModels;

namespace TRPC_Core
{
    public class ShellViewModel : Conductor<Object>
    {

        public async void RaceEntry()
        {
            await ActivateItemAsync(new RaceViewModel());
        }
    }
}