/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（枚举）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Models;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 枚举操作
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// 获取到对应枚举的描述-没有描述信息，返回枚举值
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string EnumDescription(this Enum @enum)
        {
            Type type = @enum.GetType();
            string name = nameof(@enum);// Enum.GetName(type, @enum);
            if (name == null)
            {
                return @enum.ToString();
            }

            FieldInfo field = type.GetField(name);
            if (!(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute))
            {
                return name;
            }

            return attribute?.Description ?? @enum.ToString();
        }

        /// <summary>
        /// 枚举转列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumOption> EnumOptions<T>()
        {
            return typeof(T).EnumOptions();
        }

        /// <summary>
        /// 枚举转列表
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumOption> EnumOptions(this Type enumType)
        {
            var options = new List<EnumOption>();
            foreach (var e in Enum.GetValues(enumType))
            {
                var m = new EnumOption();
                object[] attacheds = e.GetType()
                                      .GetField(e.ToString())
                                      .GetCustomAttributes(typeof(EnumAttachedAttribute), true);

                if (attacheds.Length > 0)
                {
                    EnumAttachedAttribute aa = attacheds[0] as EnumAttachedAttribute;

                    m.TagType = aa.TagType;
                    m.Description = aa.Description;
                    m.Icon = aa.Icon;
                    m.IconColor = aa.IconColor;
                }

                m.Value = Convert.ToInt32(e);
                m.Name = e.ToString();
                options.Add(m);
            }

            return options;
        }

        /// <summary>
        /// 定义值转枚举(大小写敏感)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static T StringToEnum<T>(this string val) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), val);
        }

        /// <summary>
        /// 枚举转枚举
        /// </summary>
        /// <typeparam name="Told"></typeparam>
        /// <typeparam name="Tnew"></typeparam>
        /// <param name="inVal"></param>
        /// <returns></returns>
        public static Tnew EnumToEnum<Told, Tnew>(this Told inVal)
                where Told : Enum
                where Tnew : struct
        {
            var success = Enum.TryParse<Tnew>($"{inVal}", out var result);

            return !success ? default(Tnew) : result;
        }
    }
}