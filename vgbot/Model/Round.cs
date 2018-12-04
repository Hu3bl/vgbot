using System;
using System.Collections.Generic;
using System.Text;

namespace vgbot.Model
{
    public enum eRoundStatus
    {
        NotStarted,
        FreezeTime,
        Started,
        Paused,
        BombPlanted,
        Finished
    }

    public class Round
    {
        public List<RoundEvent> RoundEvents { get; } = new List<RoundEvent>();
        public eRoundStatus Status { get; set; } = eRoundStatus.NotStarted;

    }
}
