using System;

namespace CantinaFacil.Shared.Kernel.Helpers
{
    public static class DateTimeHelper
    {
        public static long ToMilliSecondsFrom1970(this DateTime value)
        {
            return ((DateTimeOffset)value).ToUnixTimeSeconds();
        }
    }
}
