using System.Globalization;

namespace WeblogWebApp.Utilities.PersianTranslate
{

    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00") + "    " + pc.GetHour(value) + ":" + pc.GetMinute(value) + ":" + pc.GetSecond(value).ToString("00");

        }
        public static string ToShamsiCalender(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");

        }
        public static DateTime ToMiladi(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new PersianCalendar());
        }
        public static string ToShamsiForSearch(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString() + "/" +
                   pc.GetDayOfMonth(value).ToString();
        }

        public static DateTime ToDateTimeFormatFromPersianStr(this string persiandatetime)
        {
            var datetimeSplit = persiandatetime.Split('/');
            return new DateTime(int.Parse(datetimeSplit[0]), int.Parse(datetimeSplit[1]), int.Parse(datetimeSplit[2]), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second,new PersianCalendar());
        }
        public static string MonthName(string persianDate)
        {

            PersianCalendar pc = new PersianCalendar();
            var persianDateSplitedParts = persianDate.Split('/');

            var MonthId = persianDateSplitedParts[1];

            string MonthName = "";

            switch (MonthId)
            {
                case "01":
                    MonthName = "فروردین";
                    break;
                case "02":
                    MonthName = "اردیبهشت";
                    break;
                case "03":
                    MonthName = "خرداد";
                    break;
                case "04":
                    MonthName = "تير";
                    break;
                case "05":
                    MonthName = "مرداد";
                    break;
                case "06":
                    MonthName = "شهریور";
                    break;
                case "07":
                    MonthName = "مهر";
                    break;
                case "08":
                    MonthName = "آبان";
                    break;
                case "09":
                    MonthName = "آذر";
                    break;
                case "10":
                    MonthName = "دی";
                    break;
                case "11":
                    MonthName = "بهمن";
                    break;
                case "12":
                    MonthName = "اسفند";
                    break;
            }

            return MonthName;
        }

        public static string ConvertToPersianDateWithMonthName(DateTime date)
        {
            var persianDate = date.ToShamsiCalender();
            var monthName = MonthName(persianDate);
            var persianDateArr = persianDate.Split('/');
            var persianDateNewFormat = persianDateArr[2] + " " + monthName + " " + persianDateArr[0];

            return persianDateNewFormat;
        }
    }
}
