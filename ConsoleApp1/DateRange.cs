namespace ConsoleApp1.ManageDate
{
    public sealed struct DateRange
    {
        private System.DateTime start;
        private System.DateTime end;

        public System.DateTime? Start
        {
            get => start;

            set
            {
                if (value != null && value is System.DateTime)
                    start = (System.DateTime)value;
            }
        }

        public System.DateTime? End
        {
            get => start;

            set
            {
                if (value != null && value is System.DateTime)
                    start = (System.DateTime)value;
            }
        }

        public static implicit operator DateRange(System.DateTime date)
        {

            return new DateRange(System.DateTime.UtcNow);
        }

        private DateRange(System.DateTime Start)
        {
            this.Start = Start;
            this.End = Start;
        }

        public DateRange()
        {

        }
    }
}
