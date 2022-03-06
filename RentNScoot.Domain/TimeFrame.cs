using System;

namespace RentNScoot
{
    public class RentingTime
    {
        public DateTime? CollectTime { get; set; } = null;
        public DateTime? GiveOffTime { get; set; } = null;

        //ctor
        public RentingTime(DateTime? collectTime, DateTime? giveOffTime)
        {
            CollectTime = collectTime;
            GiveOffTime = giveOffTime;
        }
    }
}