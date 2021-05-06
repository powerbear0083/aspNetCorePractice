using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MockSchoolManagement.Extensions
{
    /// <summary>
    ///  列舉的擴充 method
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 顯示列舉中文名字，可對應 MajorEnum
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDisplayName(this System.Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if ( memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), true);
                if ( attrs.Length > 0)
                {
                    return ((DisplayAttribute) attrs[0]).Name;
                }
            }

            return en.ToString();
        }
    }
}