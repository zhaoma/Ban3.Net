// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Extensions;

public static partial class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="inputValue"></param>
    /// <param name="getValue"></param>
    /// <param name="getResult"></param>
    /// <param name="rangeFrom"></param>
    /// <param name="rangeTo"></param>
    /// <returns></returns>
    public static TValue Calculate<TInput, TValue>(
        this List<TInput> inputValue,
        Func<TInput, TValue> getValue,
        Func<IEnumerable<TValue>, TValue> getResult,
        int rangeFrom,
        int rangeTo
    )
    {
        var temp = new List<TValue>();

        for (var i = Math.Max(0, rangeFrom); i < Math.Min(inputValue.Count, rangeTo); i++)
        {
            temp.Add(getValue(inputValue[i]));
        }

        var result = getResult(temp);

        return result;
    }



}

