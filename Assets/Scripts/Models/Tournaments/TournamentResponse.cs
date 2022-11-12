using System;
using System.Collections.Generic;

namespace Ariel.Models
{
    public class TournamentResponse
    {
        public List<TournamentData> Tournaments;
        public int TournamentsCount;
        public DateTime LastDateTimeResponded;
    }
}
