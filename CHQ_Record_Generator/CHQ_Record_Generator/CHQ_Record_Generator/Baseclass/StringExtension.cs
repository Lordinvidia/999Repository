using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


public static class StringExtension
{
    public static int ToInt(this string number, int defaultInt)
    {
        int resultNum = defaultInt;
        try
        {
            if (!string.IsNullOrEmpty(number))
                resultNum = Convert.ToInt32(number);
        }
        catch
        {
        }
        return resultNum;
    }


    public static bool IsNumeric(this string value)
    {
        Regex regex = new Regex(@"[0-9]");



        return regex.IsMatch(value);
    }

    public static decimal ToDecimal(this string value)
    {
        decimal number;

        Decimal.TryParse(value, out number);

        return number;
    }

    public static Boolean IsDecimal(this string value)
    {
        decimal number;
        try
        {
            decimal.Parse(value);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public static String ToYearToMilisecond(this DateTime value)
    {
        return value.ToString("yyyyMMddHHmmssss");
    }


    public static bool In(this string value, params string[] stringValues)
    {
        foreach (string otherValue in stringValues)
            if (string.Compare(value, otherValue) == 0)
                return true;

        return false;
    }

    /// <summary>
    /// Converts string to enum object
    /// </summary>
    /// <typeparam name="T">Type of enum</typeparam>
    /// <param name="value">String value to convert</param>
    /// <returns>Returns enum object</returns>
    public static T ToEnum<T>(this string value)
        where T : struct
    {
        return (T)System.Enum.Parse(typeof(T), value, true);
    }

    /// <summary>
    /// Returns characters from right of specified length
    /// </summary>
    /// <param name="value">String value</param>
    /// <param name="length">Max number of charaters to return</param>
    /// <returns>Returns string from right</returns>
    public static string Right(this string value, int length)
    {
        return value != null && value.Length > length ? value.Substring(value.Length - length) : value;
    }

    public static string ReplaceByDic(this string value, Dictionary<String, String> Dic)
    {
        //return value != null && value.Length > length ? value.Substring(value.Length - length) : value;
        /*
        string NewValue= value;
        foreach (String Key in Dic.Keys)
        {
            NewValue = NewValue.Replace(Key, Dic[Key]);
        }
        return NewValue;
        */
        return ReplaceByDic(value, Dic, false);
    }

    public static String CutBetween(this string ori, string between, string and)
    {
        int pFrom = ori.IndexOf(between) + between.Length;
        int pTo = ori.LastIndexOf(and);

        String result = ori.Substring(pFrom, pTo - pFrom);
        return result;
    }


    public static String CutBetweenFirst(this string ori, string between, string andFirstString)
    {
        int pFrom = ori.IndexOf(between) + between.Length;
        int pTo = ori.IndexOf(andFirstString);

        String result = ori.Substring(pFrom, pTo - pFrom);
        return result;
    }
    public static String[] SplitBetter(this string ori, String Delimitler)
    {
        return ori.Split(new[] { Delimitler }, StringSplitOptions.None);
    }

    public static string ReplaceByDic(this string value, Dictionary<String, String> Dic, Boolean IfNotExitsThrowException)
    {
        //return value != null && value.Length > length ? value.Substring(value.Length - length) : value;


        string NewValue = value;
        foreach (String Key in Dic.Keys)
        {
            if (NewValue.IndexOf(Key) == -1)
            {
                throw new Exception("Error in ReplaceByDic there is no " + Key + " in string");
            }
            NewValue = NewValue.Replace(Key, Dic[Key]);
        }
        return NewValue;
    }
    /// <summary>
    /// Returns characters from left of specified length
    /// </summary>
    /// <param name="value">String value</param>
    /// <param name="length">Max number of charaters to return</param>
    /// <returns>Returns string from left</returns>
    public static string Left(this string value, int length)
    {
        return value != null && value.Length > length ? value.Substring(0, length) : value;
    }

    /// <summary>
    ///  Replaces the format item in a specified System.String with the text equivalent
    ///  of the value of a specified System.Object instance.
    /// </summary>
    /// <param name="value">A composite format string</param>
    /// <param name="arg0">An System.Object to format</param>
    /// <returns>A copy of format in which the first format item has been replaced by the
    /// System.String equivalent of arg0</returns>
    public static string Format(this string value, object arg0)
    {
        return string.Format(value, arg0);
    }

    /// <summary>
    ///  Replaces the format item in a specified System.String with the text equivalent
    ///  of the value of a specified System.Object instance.
    /// </summary>
    /// <param name="value">A composite format string</param>
    /// <param name="args">An System.Object array containing zero or more objects to format.</param>
    /// <returns>A copy of format in which the format items have been replaced by the System.String
    /// equivalent of the corresponding instances of System.Object in args.</returns>
    public static string Format(this string value, params object[] args)
    {
        return string.Format(value, args);
    }
}

