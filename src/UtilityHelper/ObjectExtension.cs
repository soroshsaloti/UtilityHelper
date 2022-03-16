using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;

namespace UtilityHelper;
/// <summary>
/// This Extension Helper for developers
/// </summary>
public static class ObjectExtension
{
    /// <summary>
    /// Compress data byte array
    /// </summary>
    /// <param name="data">data as byte array </param>
    /// <returns> byte  array</returns>
    public static byte[] Compress(this byte[] data)
    {
        using (var compressedStream = new MemoryStream())
        using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
        {
            zipStream.Write(data, 0, data.Length);
            zipStream.Close();
            return compressedStream.ToArray();
        }
    }

    /// <summary>
    /// Decompress data byte array
    /// </summary>
    /// <param name="data">data as byte array </param>
    /// <returns> byte  array</returns>
    public static byte[] Decompress(this byte[] data)
    {
        using (var compressedStream = new MemoryStream(data))
        using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
        using (var resultStream = new MemoryStream())
        {
            zipStream.CopyTo(resultStream);
            return resultStream.ToArray();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static MemoryStream DecompressMemoryStream(this byte[] data)
    {
        using (var compressedStream = new MemoryStream(data))
        using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
        using (var resultStream = new MemoryStream())
        {
            zipStream.CopyTo(resultStream);
            return resultStream;
        }
    }

    /// <summary>
    /// Number generator from new GUID 
    /// </summary>
    /// <returns></returns>
    public static string GetNumberByGuid()
    {

        return GetNumberByGuid(Guid.NewGuid());
    }
    /// <summary>
    /// Number generator from GUID 
    /// </summary>
    /// <param name="guid">Guid</param>
    /// <returns>string</returns>
    public static string GetNumberByGuid(this Guid guid)
    {
        byte[] buffer = guid.ToByteArray();
        var FormNumber = BitConverter.ToUInt32(buffer, 0) ^ BitConverter.ToUInt32(buffer, 4) ^ BitConverter.ToUInt32(buffer, 8) ^ BitConverter.ToUInt32(buffer, 12);
        return FormNumber.ToString();
    }
    /// <summary>
    /// Number generator from GUID as string
    /// </summary>
    /// <param name="arg">string GUID</param>
    /// <returns>string</returns>
    public static string GetNumberByStringGuid(this string arg)
    {
        var id = new Guid(arg);
        return GetNumberByGuid(id);
    }

    /// <summary>
    /// Convert List to Data Table
    /// </summary>
    /// <typeparam name="T">type of data as class</typeparam>
    /// <param name="data">data list</param>
    /// <param name="tableName">data table name</param>
    /// <returns>Data table</returns>
    public static DataTable ConvertToDatatable<T>(this IList<T> data, string tableName)
    {
        PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable(tableName);
        for (int arg = 0; arg < props.Count; arg++)
        {
            PropertyDescriptor prop = props[arg];
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
        prop.PropertyType) ?? prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (T item in data)
        {
            for (int arg = 0; arg < values.Length; arg++)
            {
                values[arg] = props[arg].GetValue(item);
            }
            table.Rows.Add(values);
        }
        return table;
    }

    /// <summary>
    /// map property class as same property
    /// </summary>
    /// <typeparam name="T">Parent Class</typeparam>
    /// <param name="contractData">Class Destination</param>
    /// <param name="enjectData">Class Source</param>
    /// <param name="isCheckValue"></param>
    public static void BindDataClass<T>(this T contractData, T enjectData, bool isCheckValue = false)
    {
        foreach (PropertyInfo item in contractData.GetType().GetProperties())
        {
            if (!item.CanRead)
                continue;
            var val = item.GetValue(contractData, null);
            if (isCheckValue)
            {
                if (item.PropertyType.IsGenericType
            && item.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    if (object.Equals(null, val))
                        continue;
                }


                if (object.Equals(item.PropertyType.DefaultValue(), val))
                    continue;


            }
            try
            {
                var property = enjectData.GetType().GetProperty(item.Name);
                var pval = item.GetValue(enjectData, null);
                if (property != null)
                {

                    if (isCheckValue)
                    {
                        if (item.PropertyType.IsGenericType
                    && item.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                        {
                            if (object.Equals(null, pval))
                                continue;
                        }


                        if (!object.Equals(item.PropertyType.DefaultValue(), pval))
                            continue;


                    }


                    if (property.CanWrite)
                        property.SetValue(contractData, pval, null);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }



        }
    }

    /// <summary>
    /// return default value
    /// </summary>
    /// <param name="type">type of staruct</param>
    /// <returns>value</returns>
    public static object? DefaultValue(this Type type)
    {

        if (type.Name == "Guid")
            return Guid.Empty;

        if (type == typeof(int) || type == typeof(Int32) || type == typeof(Int16) || type == typeof(long) || type == typeof(short) || type == typeof(float) || type == typeof(decimal))
            return default;

        return default;
    }


    /// <summary>
    /// craate instance as assembly name
    /// </summary>
    /// <param name="ClassName">object name</param>
    /// <returns>object</returns>
    public static object CreateInstance(this string ClassName)
    {
        Type type = Type.GetType(ClassName);

        var item = Activator.CreateInstance(type);
        return item;

    }

    /// <summary>
    /// create instance as class
    /// </summary>
    /// <typeparam name="T">type of object</typeparam>
    /// <param name="ClassName"></param>
    /// <returns>object</returns>
    public static T CreateInstance<T>(this T ClassName) where T : class
    {
        Type type = typeof(T); ;

        var item = Activator.CreateInstance(type) as T;
        return item;

    }

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

    public static string sepratorCurrncey(this int intCurrncey)
    {
        return string.Format("{0:0,0}", intCurrncey);
    }


    public static string sepratorCurrncey(this Int64 intCurrncey)
    {
        return string.Format("{0:0,0}", intCurrncey);
    }

}