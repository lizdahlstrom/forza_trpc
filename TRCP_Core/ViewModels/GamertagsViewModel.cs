using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using TRPC_Core.Utils;

namespace TRPC_Core.ViewModels
{
    public class GamertagsViewModel : Screen
    {
        private BindableCollection<string> _gamertags;
        private string _searchBox;
        private string _selectedTag;

        public BindableCollection<string> Gamertags
        {
            get => _gamertags;
            set
            {
                _gamertags = value;
                NotifyOfPropertyChange(() => Gamertags);
            }
        }

        public List<string> FilteredTags => (from tag in Gamertags
            where tag.StartsWith(SearchBox, StringComparison.InvariantCultureIgnoreCase)
            select tag).ToList();

        public string SearchBox
        {
            get => _searchBox;
            set
            {
                _searchBox = value;
                NotifyOfPropertyChange(() => SearchBox);
                NotifyOfPropertyChange(() => Gamertags);
                NotifyOfPropertyChange(() => FilteredTags);
            }
        }

        public string SelectedTag
        {
            get => _selectedTag;
            set
            {
                _selectedTag = value;
                NotifyOfPropertyChange(() => SelectedTag);
            }
        }

        public GamertagsViewModel()
        {
            SearchBox = "";
            Gamertags =
                new BindableCollection<string>(FileOperations.ReadData(Globals.FilePath));
        }

        public void SaveData()
        {
            FileOperations.SaveData(Gamertags.ToArray(), Globals.FilePath);
        }

        public void AddBtn()
        {
            if (SearchBox.Equals("")) return;

            Gamertags.Add(SearchBox);
            NotifyOfPropertyChange(() => Gamertags);
            SearchBox = "";
        }

        public void DeleteBtn()
        {
            if (SelectedTag == null|| !Gamertags.Contains(SelectedTag)) return;

            Gamertags.Remove(SelectedTag);
            NotifyOfPropertyChange(() => FilteredTags);
        }

    }
}