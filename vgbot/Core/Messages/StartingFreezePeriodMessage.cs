using vgbot.Model;

namespace Vgbot.Core.Messages
{
    public class StartingFreezePeriodMessage : AbstractMessage
    {
        public override void Process(Match match)
        {
            match.StartNewRound();
            var round = match.GetCurrentRound();
            round.Status = eRoundStatus.FreezeTime;
        }
    }
}
