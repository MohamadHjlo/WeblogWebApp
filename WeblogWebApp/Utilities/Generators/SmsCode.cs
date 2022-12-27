namespace WeblogWebApp.Utilities.Generators
{
    public class SmsCode
    {
        public static string GenerateSmsCode()
        {
            Random rand = new Random();
            string smsCode = rand.Next(99999, 999999).ToString();
            return smsCode;
        }
    }
}
