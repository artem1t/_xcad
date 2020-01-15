//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Xarial.XCad.Utils.Reflection
{
    /// <summary>
    /// Provides extension classes for the <see cref="Enum"/> enumerator
    /// </summary>
    public static class EnumExtension
    {
        public static Dictionary<Enum, string> GetEnumFields(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new InvalidCastException($"{enumType.FullName} must be an enum");
            }

            var enumValues = new List<Enum>();

            foreach (Enum en in Enum.GetValues(enumType)) 
            {
                enumValues.Add(en);
            }
            
            var values = enumValues.ToDictionary(e => e,
                e =>
                {
                    var text = "";

                    e.TryGetAttribute<DisplayNameAttribute>(a => text = a.DisplayName);

                    if (string.IsNullOrEmpty(text))
                    {
                        text = e.ToString();
                    }

                    return text;

                });

            return values;
        }

        /// <summary>
        /// Get the specified attribute from the enumerator field
        /// </summary>
        /// <typeparam name="TAtt">Attribute type</typeparam>
        /// <param name="enumer">Enumerator field</param>
        /// <returns>Attribute</returns>
        /// <exception cref="NullReferenceException"/>
        /// <remarks>This method throws an exception if attribute is missing</remarks>
        public static TAtt GetAttribute<TAtt>(this Enum enumer)
            where TAtt : Attribute
        {
            TAtt att = default;

            if (!TryGetAttribute<TAtt>(enumer, a => att = a))
            {
                throw new NullReferenceException($"Attribute of type {typeof(TAtt)} is not fond on {enumer}");
            }

            return att;
        }

        /// <summary>
        /// Attempts to the attribute from enumeration
        /// </summary>
        /// <typeparam name="TAtt">Type of the attribute</typeparam>
        /// <param name="type">Type to get attribute from</param>
        /// <returns>Attribute or null if not found</returns>
        public static TAtt TryGetAttribute<TAtt>(this Enum enumer)
            where TAtt : Attribute
        {
            TAtt thisAtt = null;
            TryGetAttribute<TAtt>(enumer, a => thisAtt = a);
            return thisAtt;
        }

        /// <summary>
        /// Tries to get attribute from the enumeration
        /// </summary>
        /// <typeparam name="TAtt">Type of attribute to get</typeparam>
        /// <param name="enumer">Enumerator value</param>
        /// <param name="attProc">Action to process attribute</param>
        /// <returns>True if attribute exists</returns>
        public static bool TryGetAttribute<TAtt>(this Enum enumer, Action<TAtt> attProc)
            where TAtt : Attribute
        {
            var enumType = enumer.GetType();
            var enumField = enumType.GetMember(enumer.ToString()).FirstOrDefault();
            var atts = enumField.GetCustomAttributes(typeof(TAtt), false);

            if (atts != null && atts.Any())
            {
                var att = atts.First() as TAtt;
                attProc.Invoke(att);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}