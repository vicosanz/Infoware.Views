using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Infoware.Core.Extensions;
using Infoware.Views.Attributes;
using Infoware.Views.Extensions;

namespace Infoware.Views.Controles
{
    public static class Utils
    {
        public static List<ShowAsAttribute> GetProperties(IList source, Expression<Func<ShowAsAttribute, bool>> expression = null)
        {
            Type SourceType = source[0].GetType();
            return GetProperties(SourceType, expression);
        }

        public static List<ShowAsAttribute> GetProperties(Type sourceType, Expression<Func<ShowAsAttribute, bool>> expression = null)
        {
            Func<ShowAsAttribute, bool> expcompiled = null;
            if (expression != null)
                expcompiled = expression.Compile();

            List<ShowAsAttribute> result = new();
            foreach (PropertyInfo mInfo in sourceType.GetProperties())
            {
                var attr = mInfo.GetShowAsAttribute();

                if (attr != null)
                {
                    bool isOk = true;
                    if (expcompiled != null)
                    {
                        isOk = expcompiled.Invoke(attr);
                    }

                    if (isOk)
                    {
                        //attr.ValueType = mInfo.PropertyType;
                        //attr.Field = mInfo.Name;
                        attr.PropertyInfo = mInfo;
                        attr.DisplayAttribute = DisplayAttributeExtensions.GetDisplayAttribute(mInfo);
                        result.Add(attr);
                    }
                }
            }
            return result;
        }

        public static List<KeyValuePair<object, string>> EnumToComboData(ShowAsAttribute attr)
        {
            return EnumToComboData(attr.PropertyInfo.PropertyType);
        }

        public static List<KeyValuePair<object, string>> EnumToComboData(Type type)
        {
            List<KeyValuePair<object, string>> items = new();
            var typeNullable = Nullable.GetUnderlyingType(type);
            var values = Enum.GetValues(typeNullable ?? type);
            if (typeNullable != null)
            {
                items.Add(new KeyValuePair<object, string>(null, "<Vacío>"));
            }
            foreach (var value in values)
            {
                var attribute = ExternalCodeAttributeExtensions.GetExternalCodeAttribute(value);
                var display = DisplayAttributeExtensions.GetDisplayAttribute(value);

                var displayName = display?.GetName() ?? value.ToString();

                string description = attribute is null ? displayName : $"{attribute.Code} {displayName}";
                items.Add(new KeyValuePair<object, string>(
                    value,
                    description
                ));
            }

            return items;
        }

        public static List<KeyValuePair<int, string>> EnumToComboDataInt(ShowAsAttribute attr)
        {
            return EnumToComboDataInt(attr.PropertyInfo.PropertyType);
        }

        public static List<KeyValuePair<int, string>> EnumToComboDataInt(Type type)
        {
            List<KeyValuePair<int, string>> items = new();
            var typeNullable = Nullable.GetUnderlyingType(type);
            var values = Enum.GetValues(typeNullable ?? type);
            if (typeNullable != null)
            {
                items.Add(new KeyValuePair<int, string>(-1, "<Vacío>"));
            }
            Type enumType = typeNullable ?? type;
            foreach (var value in values)
            {
                var attribute = ExternalCodeAttributeExtensions.GetExternalCodeAttribute(value);
                var display = DisplayAttributeExtensions.GetDisplayAttribute(value);

                var displayName = display?.GetName() ?? value.ToString();

                string description = attribute is null ? displayName : $"{attribute.Code} {displayName}";
                items.Add(new KeyValuePair<int, string>(
                    (int)Enum.Parse(enumType, value.ToString(), false),
                    description
                ));
            }

            return items;
        }

        public static bool IsNullableEnum(this Type t)
        {
            Type u = Nullable.GetUnderlyingType(t);
            return (u != null) && u.IsEnum;
        }
    }

}
