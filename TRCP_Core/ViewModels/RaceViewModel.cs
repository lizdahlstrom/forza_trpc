﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRPC_Core.Datatypes;
using TRPC_Core.Models;
using TRPC_Core.Utils;

namespace TRPC_Core.ViewModels
{
    public class RaceViewModel: Screen
    {
        private int _teamRedResult;
        private int _teamBlueResult;
        private BindableCollection<PlayerModel> _players;
        private BindableCollection<string> _gamertagsData;

        public BindableCollection<string> GamertagsData
        {
            get => _gamertagsData;
            set
            {
                _gamertagsData = value;
                NotifyOfPropertyChange(() => GamertagsData);
            }
        }

        public BindableCollection<PlayerModel> Players
        {
            get => _players;
            set
            {
                _players = value;
                NotifyOfPropertyChange(() => Players);
            }
        }

        public int TeamRedResult
        {
            get => _teamRedResult;
            set
            {
                _teamRedResult = value;
                NotifyOfPropertyChange(() => TeamRedResult);
            }
        }

        public int TeamBlueResult
        {
            get => _teamBlueResult;
            set
            {
                _teamBlueResult = value;
                NotifyOfPropertyChange(() => TeamBlueResult);
            } 
        }

        public RaceViewModel()
        {
            UpdateGamertagsData();
            ClearPlayers();
        }

        public void UpdateResult()
        {
            CalculateTeamPoints();
        }

        public void UpdateGamertagsData()
        {
            GamertagsData = new BindableCollection<string>(FileOperations.ReadData(Globals.FilePath).ToList());
        }

        public void ClearPlayers()
        {
            Players = new BindableCollection<PlayerModel>();
            for (var i = 0; i < 12; i++)
            {
                Players.Add((i + 1) > 6 ? new PlayerModel(i + 1, Team.Blue) : new PlayerModel(i + 1, Team.Red));
            }
        }

        public void CalculateTeamPoints()
        {
            // Validate input
            // 50/50 red blue team members
            ResetResults();

            var sorted = Players.OrderBy(player => player.Position).ToList();
            sorted[0].Points += 50;

            if (sorted[0].Team == Team.Red)
            {
                TeamRedResult += 50;
            }
            else
            {
                TeamBlueResult += 50;
            }

            // for each player, starting on top
            for (var i = 0; i < sorted.Count; i++)
            {
                // check the players under that player
                for (var j = i +1; j < sorted.Count; j++)
                {
                    if (sorted[j].Team != sorted[i].Team)
                    {
                        sorted[i].Points += 100;
                        if (sorted[j].Team == Team.Red)
                        {
                            TeamBlueResult += 100;
                        }
                        else
                        {
                            TeamRedResult += 100;
                        }
                    }
                }
            }

            Players = new BindableCollection<PlayerModel>(sorted);
        }

        private void ResetResults()
        {
            TeamRedResult = 0;
            TeamBlueResult = 0;
            Players.Apply(player => player.Points = 0);
        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return base.OnActivateAsync(cancellationToken);
        }
    }
}