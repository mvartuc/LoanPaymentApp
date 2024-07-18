using Microsoft.EntityFrameworkCore;
using VakifBankKrediKullandirimAPI.Interfaces;
using static VakifBankKrediKullandirimAPI.Helpers.Helpers;

namespace VakifBankKrediKullandirimAPI.Helpers.CustomDateClasses
{
    [Index(nameof(Code), IsUnique = true)]
    public class DatePart : IDatePart
    {
        private int _value;

        public DatePart(string name, int limit)
        {
            Limit = limit;
            Name = name;
        }
        public int Id { get; set; }
        public string Code { get; set; } = RandomCode();
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 0 || value > Limit)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"DatePart must be between 0 and {Limit}.");
                }
                _value = value;
            }
        }
        public int Limit { get; private set; }
        public string Name { get; private set; }
    }
}
