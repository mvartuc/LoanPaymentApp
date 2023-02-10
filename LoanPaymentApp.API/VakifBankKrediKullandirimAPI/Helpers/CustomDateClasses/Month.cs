using VakifBankKrediKullandirimAPI.Interfaces;

namespace VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses
{
    public class Month: IDatePart
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Month must be between 1 and 12.");
                }
                _value = value;
            }
        }
        public int Limit { get; set; } = 12;
    }
}
