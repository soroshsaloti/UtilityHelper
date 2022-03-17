namespace UtilityHelper.Extensions;
using System;
using System.Reflection;
using UtilityHelper.Infostruct;

public static class ConvertExtention
{

    /// <summary>
    /// string to decimal null able
    /// </summary>
    /// <param name="arg">string</param>
    /// <returns>decimal</returns>
    public static System.Nullable<decimal> ToDecimalNull(this string arg)
    {
        int no = 0;

        if (int.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }
    /// <summary>
    /// string to decimal
    /// </summary>
    /// <param name="arg">string</param>
    /// <returns>decimal</returns>
    public static decimal ToDecimal(this string arg)
    {
        decimal no = 0;

        if (decimal.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }
    /// <summary>
    /// object to decimal null able
    /// </summary>
    /// <param name="arg">object</param>
    /// <returns>decimal</returns>
    public static System.Nullable<decimal> ToDecimalNull(this object arg)
    {
        if (arg == null)
        {
            return default;

        }
        return arg.ToString().ToDecimalNull();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    public static Int16 ToInt16(this string arg)
    {
        Int16 no;

        if (Int16.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    public static Int16 ToInt16(this object arg)
    {
        if (arg == null)
        {
            return default;

        }
#pragma warning disable CS8604 // Possible null reference argument.
        return arg.ToString().ToInt16();
#pragma warning restore CS8604 // Possible null reference argument.
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    public static System.Nullable<Int16> ToInt16Null(this string arg)
    {
        Int16 no = default(Int16);

        if (Int16.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    public static System.Nullable<Int16> ToInt16Null(this object arg)
    {

        if (arg == null)
        {
            return default;

        }
        return arg.ToString().ToInt16Null();
    }
    public static System.Nullable<byte> ToByteNull(this string arg)
    {
        byte no = 0;

        if (byte.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }
    public static System.Nullable<byte> ToByteNull(this object obj)
    {
        if (obj == null)
        {
            return default;

        }
        return obj.ToString().ToByteNull();
    }

    public static byte ToByte(this string arg)
    {
        byte no;

        if (byte.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }

    public static byte ToByte(this object obj)
    {
        if (obj == null)
        {
            return default;

        }
        return obj.ToString().ToByte();
    }
    public static System.Nullable<int> ToInt32Null(this string arg)
    {
        int no = 0;

        if (int.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }
    public static System.Nullable<int> ToInt32Null(this object obj)
    {
        if (obj == null)
        {
            return default;
        }

        return obj.ToString().ToInt32Null();
    }
    public static System.Nullable<Int64> ToInt64Null(this string arg)
    {
        Int64 no = default(Int64);

        if (Int64.TryParse(arg, out no))
        {
            return no;
        }

        return default;
    }
    public static System.Nullable<double> ToDoubleNull(this string arg)
    {
        double no = default(double);

        if (double.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }
    public static Int64 ToRound(this double arg)
    {
        return Convert.ToInt64(Math.Round(arg));
    }
    public static Int64 DoubleToInt64(this double arg)
    {

        return Convert.ToInt64(arg);
    }
    public static System.Nullable<Int64> ToInt64Null(this object arg)
    {
        if (arg == null)
        {
            return default;

        }
        return arg.ToString().ToInt64Null();
    }
    public static int ToInt32(this string arg)
    {
        int no = 0;

        if (int.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }
    public static int ToInt32(this object arg)
    {
        if (arg == null)
        {
            return default;

        }
        return arg.ToString().ToInt32();
    }

    public static Guid ToGuid(this string arg)
    {
        Guid no = new Guid();

        if (Guid.TryParse(arg, out no))
        {
            return no;
        }
        return Guid.Empty;
    }

    public static Guid ToGuid(this object arg)
    {
        if (arg == null)
        {
            return Guid.Empty;

        }
        return arg.ToString().ToGuid();
    }

    public static bool IsNumericData(this string arg)
    {
        if (arg.IsNullOrEmpty())
        {
            return false;
        }
        if (arg.ToInt64Null().HasValue)
            return true;
        return false;
    }

    public static Int64 ToInt64(this string arg)
    {
        Int64 no = default(Int64);

        if (Int64.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }

    public static double ToDouble(this string arg)
    {
        double no = default(double);

        if (double.TryParse(arg, out no))
        {
            return no;
        }
        return default;
    }

    public static string CaptionEnum<TEnum>(this TEnum item) where TEnum : struct, IConvertible
    {
        if (!Enum.IsDefined(item.GetType(), item))
            return string.Empty;
        var enumMetadataAttrib = item.GetType().GetField(item.ToString()).GetCustomAttributes<TitleAtribute>().FirstOrDefault();
        if (enumMetadataAttrib != null)
            return enumMetadataAttrib.Caption;
        else
            return item.ToString();
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

