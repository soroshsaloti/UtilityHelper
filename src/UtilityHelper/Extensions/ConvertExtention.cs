namespace UtilityHelper.Extensions;
using System;
using System.Reflection;
using UtilityHelper.Infostruct;

public static class ConvertExtention
{     
    public static string? CaptionEnum<TEnum>(this TEnum item) where TEnum : struct, IConvertible
    {
        if (!Enum.IsDefined(item.GetType(), item))
            return string.Empty;
        var caption = item.GetType().GetField(item.ToString()).GetCustomAttributes<TitleAtribute>().FirstOrDefault()?.Caption;
        
        return caption.IsNullOrEmpty() ? item.ToString() : caption;
    }
    
    public static IEnumerable<KeyValuePair<string, string>> GetTitleProperties(this Type type, bool justBrowsable = false)
    {

        foreach (var item in type.GetProperties())
        {
            var enumMetadataAttrib = item.GetCustomAttributes<TitleAtribute>().FirstOrDefault();

            if (enumMetadataAttrib != null)
            {
                yield return new KeyValuePair<string, string>(item.Name, string.IsNullOrEmpty(enumMetadataAttrib.Title) ? item.ToString() : enumMetadataAttrib.Title);
            }
            else
            {
                yield return new KeyValuePair<string, string>(item.Name, item.ToString());
            }
        }
    }
    public static IEnumerable<KeyValuePair<string, string>> GetCaptionProperties(this Type type, bool justBrowsable = false)
    {

        foreach (var item in type.GetProperties())
        {
            var enumMetadataAttrib = item.GetCustomAttributes<TitleAtribute>().FirstOrDefault();

            if (enumMetadataAttrib != null)
            {
                yield return new KeyValuePair<string, string>(item.Name, string.IsNullOrEmpty(enumMetadataAttrib.Caption) ? item.ToString() : enumMetadataAttrib.Caption);
            }
            else
            {
                yield return new KeyValuePair<string, string>(item.Name, item.ToString());
            }
        }
    }
    public static IEnumerable<KeyValuePair<int, string>> GetTitleFields(this Type enumType, bool justBrowsable = false)
    {
        if (enumType.BaseType != typeof(Enum))
        {
            throw new ArgumentException("T Must be of type System.Enum");
        }

        var items = Enum.GetValues(enumType);

        foreach (var item in items)
        {
            var browsableAttrib = item.GetType().GetField(item.ToString()).GetCustomAttributes<System.ComponentModel.BrowsableAttribute>().FirstOrDefault();
            bool isBrowsable = browsableAttrib == null || browsableAttrib.Browsable;

            if (!isBrowsable)
                continue;


            var enumMetadataAttrib = item.GetType().GetField(item.ToString()).GetCustomAttributes<TitleAtribute>().FirstOrDefault();

            if (enumMetadataAttrib != null)
            {
                isBrowsable = !enumMetadataAttrib.Hidden;
                if (!isBrowsable)
                    continue;

                yield return new KeyValuePair<int, string>(Convert.ToInt32(item), string.IsNullOrEmpty(enumMetadataAttrib.Title) ? item.ToString() : enumMetadataAttrib.Caption);
            }
            else
            {
                yield return new KeyValuePair<int, string>(Convert.ToInt32(item), item.ToString());
            }
        }
    }
    public static IEnumerable<KeyValuePair<int, string>> GetCaptionFields(this Type enumType, bool justBrowsable = false)
    {
        if (enumType.BaseType != typeof(Enum))
        {
            throw new ArgumentException("T Must be of type System.Enum");
        }

        var items = Enum.GetValues(enumType);

        foreach (var item in items)
        {
            var browsableAttrib = item.GetType().GetField(item.ToString()).GetCustomAttributes<System.ComponentModel.BrowsableAttribute>().FirstOrDefault();
            bool isBrowsable = browsableAttrib == null || browsableAttrib.Browsable;

            if (!isBrowsable)
                continue;


            var enumMetadataAttrib = item.GetType().GetField(item.ToString()).GetCustomAttributes<TitleAtribute>().FirstOrDefault();

            if (enumMetadataAttrib != null)
            {
                isBrowsable = !enumMetadataAttrib.Hidden;
                if (!isBrowsable)
                    continue;

                yield return new KeyValuePair<int, string>(Convert.ToInt32(item), string.IsNullOrEmpty(enumMetadataAttrib.Caption) ? item.ToString() : enumMetadataAttrib.Caption);
            }
            else
            {
                yield return new KeyValuePair<int, string>(Convert.ToInt32(item), item.ToString());
            }
        }
    }

}

