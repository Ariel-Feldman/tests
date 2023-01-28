using System;
using System.Collections.Generic;

namespace Ariel.Features
{
    public class TournamentResponse 
    {
        public List<LiveTournamentData> Tournaments;
        public int TournamentsCount;
        public DateTime LastDateTimeResponded;
    }
}
