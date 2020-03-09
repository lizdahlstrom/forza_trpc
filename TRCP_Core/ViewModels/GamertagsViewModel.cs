using System;
using System.Linq;
using Caliburn.Micro;
using TRPC_Core.Utils;

namespace TRPC_Core.ViewModels
{
    public class GamertagsViewModel: Screen
    {
        private BindableCollection<string> _gamertags;

        private BindableCollection<string> Gamertags
        {
            get => _gamertags;
            set
            {
                _gamertags = value;
                NotifyOfPropertyChange(() => Gamertags);
            }
        }

        public GamertagsViewModel()
        {
            Gamertags =
            new BindableCollection<string>(FileOperations.ReadData(Globals.FilePath));
            Console.WriteLine(Gamertags.Count);
        }

        public void SaveData()
        {
            FileOperations.SaveData(Gamertags.ToArray(), Globals.FilePath);
        }

    }
}