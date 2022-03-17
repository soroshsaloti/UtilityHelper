namespace UtilityHelper;
/// <summary>
/// This Extension Helper for developers
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// check string
    /// </summary>
    /// <param name="obj"> string object</param>
    /// <param name="isNullOrWhiteSpace">check space</param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string obj, bool isNullOrWhiteSpace = false)
    {
        if (!isNullOrWhiteSpace)
            return string.IsNullOrEmpty(obj);

        return string.IsNullOrWhiteSpace(obj);
    }
    /// <summary>
    /// Added zero to string for accounting system 
    /// </summary>
    /// <param name="InputStr"> string </param>
    /// <param name="OutLen">count of zero </param>
    /// <returns></returns>
    public static string Add_Zero_Before(this string InputStr, int OutLen)
    {
        string Output = "";
        InputStr = InputStr.Trim();
        for (int i = 1; i <= OutLen - InputStr.Length; i++)
        {
            Output += "0";
        }
        Output += InputStr;
        return Output;
    }
    /// <summary>
    /// Added zero to string for accounting system 
    /// </summary>
    /// <param name="InputStr"> string </param>
    /// <param name="OutLen">count of zero </param>
    /// <returns></returns>
    public static string Add_Zero_After(this string InputStr, int OutLen)
    {
        string Output = "";
        InputStr = InputStr.Trim();
        for (int i = 1; i <= OutLen - InputStr.Length; i++)
        {
            Output += "0";
        }
        Output = InputStr + Output;
        return Output;
    }
    /// <summary>
    /// Added space to string for accounting system 
    /// </summary>
    /// <param name="InputStr"> string </param>
    /// <param name="OutLen">count of space </param>
    /// <returns></returns>
    public static string Add_SpaceAfter(this string InStr, int OutLen)
    {
        string Output = "";
        InStr = InStr.Trim();
        for (int i = 1; i <= OutLen - InStr.Length; i++)
        {
            Output += " ";
        }
        Output = InStr + Output;
        return Output;

    }

    public static string SepratorCurrncey(this int intCurrncey)
    {
        return string.Format("{0:0,0}", intCurrncey);
    }

    public static string SepratorCurrncey(this decimal intCurrncey)
    {
        return string.Format("{0:0,0}", intCurrncey);
    }

    public static string SepratorCurrncey(this float intCurrncey)
    {
        return string.Format("{0:0,0}", intCurrncey);
    }

    public static string SepratorCurrncey(this double intCurrncey)
    {
        return string.Format("{0:0,0}", intCurrncey);
    }
    public static string SepratorCurrncey(this Int64 intCurrncey)
    {
        return string.Format("{0:0,0}", intCurrncey);
    }
}

