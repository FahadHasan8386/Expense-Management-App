using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            if (enumValue == null) return string.Empty;

            var member = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();

            if (member == null) return enumValue.ToString();

            var displayName = member.GetCustomAttribute<DisplayAttribute>();
            return displayName?.GetName() ?? enumValue.ToString();

        }
    }
}
