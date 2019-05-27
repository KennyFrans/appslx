using System.Globalization;
using System.Text.RegularExpressions;

namespace Appslx.Web.Helper
{
    public static class Currency
    {
        public static string ToRupiah(this int angka)
        {
            return string.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", angka);
        }

        
        public static string ToRupiah(this decimal angka)
        {
            return string.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", angka);
        }

        public static int ToAngka(this string rupiah)
        {
            return int.Parse(Regex.Replace(rupiah, @",.*|\D", ""));
        }
    }
}
