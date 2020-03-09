using System.Collections.Generic;

namespace TRPC_Core.Models
{
	public class TeamModel
	{
		private string name { get; set; }
		private List<string> players { get; set; }

		public TeamModel(string name)
		{
			this.name = name;
		}

		public void addPlayer(string playerName)
		{
			players.Add(playerName);
		}

		public void clearTeam()
		{
			if (players.Count > 0) {
				players.Clear();
			}
		}

	}
}