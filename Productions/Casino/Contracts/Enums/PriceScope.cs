﻿using System;
using System.ComponentModel;

namespace Ban3.Productions.Casino.Contracts.Enums;

/// <summary>
/// 价格区间
/// </summary>
public enum PriceScope
{
    /// 5块及以下
    [Description("P<=5")]
    LE5=0,

    /// 5-10
    [Description("5<P<=10")]
    LE10 =1,

    /// 10-20
    [Description("10<P<=20")]
    LE20 =2,

    /// 
    [Description("20<P<=30")]
    LE30 =3,

    /// 
    [Description("30<P<=50")]
    LE50 =4,

    /// 
    [Description("50<P<=100")]
    LE100,

    /// 
    [Description("100<P<=200")]
    LE200,

    /// 高于200
    [Description("P>200")]
    GT200
}

