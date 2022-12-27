namespace WeblogWebApp.Utilities.Generators
{
    public class UniqueCode
    {
        public static string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString().Substring(0,15).Replace("-", "");
        }

    }
}
