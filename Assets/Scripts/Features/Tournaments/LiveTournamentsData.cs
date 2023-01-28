using System;
using System.Collections.Generic;

namespace Ariel.Features
{
    public class TournamentsData : BaseData
    {
        public List<LiveTournamentData> LiveTournamentsData;
    }
    
    public class LiveTournamentData : BaseData
    {
        public string TournamentHeader;
        public string TournamentName;
        public int PlayersCount;
        public int EntryFee;
        public List<Tuple<string, int>> Rewards;
    }
}
