using VakifBankKrediKullandirimAPI.Interfaces;

namespace VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses
{
    public class Day: IDatePart
    {
        private int _value;
        private int _year;
        private int _month;

        public Day(int year, int month)
        {
            Limit = DateTime.DaysInMonth(_year, _month);
        }
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 1 || value > Limit)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Day must be between 1 and {Limit}.");
                }
                _value = value;
            }
        }
        public int Limit { get; set; }
    }
}
