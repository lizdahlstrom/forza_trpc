using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPC_Core.Models
{
	class RaceModel
	{
		private TeamModel team1;
		private TeamModel team2;

		public RaceModel(TeamModel team1, TeamModel team2)
		{
			this.team1 = team1;
			this.team2 = team2;
        }

	}
}
