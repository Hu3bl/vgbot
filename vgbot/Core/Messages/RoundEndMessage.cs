using vgbot.Model;
using Vgbot.Model.Events;

namespace Vgbot.Core.Messages
{
    public class RoundEndMessage : AbstractMessage
    {
        public override void Process(Match match)
        {
            var round = match.GetCurrentRound();
            var endEvent = new RoundEnd();
            round.RoundEvents.Add(endEvent);
        }
    }
}