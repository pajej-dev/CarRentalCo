using System;

namespace CarRentalCo.Common.Other
{
    public static class SystemTime
    {
        private static DateTime? settedDate;

        public static DateTime UtcNow
        {
            get
            {
                if (settedDate.HasValue)
                {
                    return settedDate.Value;
                }

                return DateTime.UtcNow;
            }
        }

        //usefull for mocking date in unit tests
        public static void Set(DateTime dateTime) => settedDate = dateTime;
        public static void Reset() => settedDate = null;

    }
}
