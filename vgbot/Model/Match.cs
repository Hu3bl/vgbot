using System.Collections.Generic;

namespace vgbot.Model
{
    public enum eMatchStatus
    {
        NotStarted,
        Warmup,
        Live,
        Finished,
        Paused
    }

    public class Match
    {
        private Round _currentRound;

        public int ScoreCT { get; set; }
        public int ScoreT { get; set; }
        public string Map { get; set; }
        public List<Round> Rounds { get; } = new List<Round>();
        public eMatchStatus Status { get; set; }
        public Dictionary<string, Player> Players { get; } = new Dictionary<string, Player>();

        public void Reset()
        {

        }

        public void StartNewRound()
        {
            var newRound = new Round();
            Rounds.Add(newRound);
            _currentRound = newRound;
        }

        public Round GetCurrentRound()
        {
            if (_currentRound == null)
            {
                StartNewRound();
            }

            return _currentRound;
        }

        public Player GetPlayerWithId(string steamId)
        {
            if (Players.ContainsKey(steamId))
            {
                return Players[steamId];
            }
            var player = new Player {SteamId = steamId};
            Players.Add(steamId, player);
            return player;
        }
    }
}
