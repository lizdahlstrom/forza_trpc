using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRPC_Core.Datatypes;
using TRPC_Core.Models;

namespace TRPC_Core.ViewModels
{
    public class RaceViewModel: Screen
    {
        private int _team1Result;
        private int _team2Result;
        private BindableCollection<PlayerModel> _players;

        public BindableCollection<PlayerModel> Players
        {
            get => _players;
            set
            {
                _players = value;
                NotifyOfPropertyChange(() => Players);
            }
        }

        public int Team1Result
        {
            get => _team1Result;
            set
            {
                _team1Result = value;
                NotifyOfPropertyChange(() => Team1Result);
            }
        }

        public int Team2Result
        {
            get => _team2Result;
            set
            {
                _team2Result = value;
                NotifyOfPropertyChange(() => Team2Result);
            } 
        }

        public RaceViewModel()
        {
            Console.WriteLine("called race view model");
            Players = new BindableCollection<PlayerModel>();
            for (var i = 0; i < 12; i++)
            {
                Players.Add((i + 1) % 2 == 0  ? new PlayerModel(i + 1, Team.Blue) : new PlayerModel(i + 1));
            }
        }

        public void UpdateResult()
        {
            CalculateTeamPoints();
        }

        public void CalculateTeamPoints()
        {
            Team1Result = 0;
            Team2Result = 0;
            Players.Apply(player => player.Points = 0);

            var sorted = Players.OrderBy(player => player.Position).ToList();
            sorted[0].Points += 50;

            if (sorted[0].Team == Team.Red)
            {
                Team1Result += 50;
            }
            else
            {
                Team2Result += 50;
            }

            // TODO: Set points for each player

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
                            Team1Result += 100;
                        }
                        else
                        {
                            Team2Result += 100;
                        }
                    }
                }
            }

            Players = new BindableCollection<PlayerModel>(sorted);
        }
            
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return base.OnActivateAsync(cancellationToken);
        }
    }
}