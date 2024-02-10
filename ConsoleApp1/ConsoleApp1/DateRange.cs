namespace ConsoleApp1.ManageDate
{
    public struct DateRange
    {
        public System.DateTimeOffset Start;
        public System.DateTimeOffset End;

        public static implicit operator DateRange(System.DateTimeOffset date) =>
            new DateRange { Start = date, End = date };

        public DateRange(System.DateTimeOffset start, System.DateTimeOffset end)
        {
            this.Start = start;
            this.End = end;
        }

        public DateRange(System.DateTimeOffset start, System.TimeSpan duration)
        {
            this.Start = start;
            this.End = start + duration;
        }
    }
}