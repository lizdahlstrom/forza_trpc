﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPC_Core.Datatypes;

namespace TRPC_Core.Models
{
	public class PlayerModel
	{
        public int Position { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public Team Team { get; set; }

        public PlayerModel(int position, Team team = Team.Red, string name = "")
        {
            Position = position;
            Team = team;
            Name = name;
        }

    }
}
