using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WeblogWebApp.Utilities.Enum
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this System.Enum val)
        {
            return val.GetType()
                       .GetMember(val.ToString())
                       .FirstOrDefault()
                       ?.GetCustomAttribute<DisplayAttribute>(false)
                       ?.Name
                   ?? val.ToString();
        }
    }
}
