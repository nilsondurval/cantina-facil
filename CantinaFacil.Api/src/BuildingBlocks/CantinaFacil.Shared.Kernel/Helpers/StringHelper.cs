using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CantinaFacil.Shared.Kernel.Helpers
{
    public static class StringHelper
    {
        public static string ToFormat(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        public static string RemoveAccents(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            byte[] bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string OnlyNumbers(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
