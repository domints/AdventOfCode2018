using System;

namespace Day4
{
    class GuardLog
    {
        public DateTime Time { get; set; }
        public GuardEventType EventType { get; set; }
        public int GuardId { get; set; }

    }

    enum GuardEventType
    {
        ShiftStart,
        FallAsleep,
        WakeUp
    }
}