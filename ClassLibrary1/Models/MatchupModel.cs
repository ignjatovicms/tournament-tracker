using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
        /// <summary>
        /// Represents one match in the tournament.
        /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// The unique identifier for the matchup.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The set of teams that were involved in this match.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        
        /// <summary>
        /// The winner of the match.
        /// </summary>
        public TeamModel Winner { get; set; }

        public int WinnerId { get; set; }

        /// <summary>
        /// Which round this match is part of.
        /// </summary>
        public int MatchupRound { get; set; }

        public string DisplayName
        {
            get
            {
                string teamOne = "Not yet set";
                string teamTwo = "Not yet set";

                if (Entries.Count > 0)
                {
                    if (Entries[0].TeamCompeting != null)
                    {
                        teamOne = Entries[0].TeamCompeting.TeamName;
                    }
                    else if (Entries[0].ParentMatchup?.Winner != null)
                    {
                        teamOne = Entries[0].ParentMatchup.Winner.TeamName;
                    }
                }

                if (Entries.Count > 1)
                {
                    if (Entries[1].TeamCompeting != null)
                    {
                        teamTwo = Entries[1].TeamCompeting.TeamName;
                    }
                    else if (Entries[1].ParentMatchup?.Winner != null)
                    {
                        teamTwo = Entries[1].ParentMatchup.Winner.TeamName;
                    }
                }

                return $"{teamOne} vs. {teamTwo}";
            }
        }

    }
}
