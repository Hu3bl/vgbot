using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class MatchStartMessage : AbstractMessage
    {
        public string Map { get; set; }

        public override void Process(Match match)
        {
            //if (match.Status == eMatchStatus.NotStarted)
            //{
            //    match.Status = eMatchStatus.Live;
            //}

            if (match.Status == eMatchStatus.Live)
            {
                match.Reset();
            }
            match.Status = eMatchStatus.Live;
        }
    }
}
