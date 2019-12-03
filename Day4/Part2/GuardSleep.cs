namespace Day4 
{
    class GuardSleep
    {
        public int MinuteStart { get; set; }
        public int MinuteStop { get; set; }

        public int Length => MinuteStop - MinuteStart;

        public bool Contains(int minute)
        {
            return minute >= MinuteStart && minute < MinuteStop;
        }
    }
}