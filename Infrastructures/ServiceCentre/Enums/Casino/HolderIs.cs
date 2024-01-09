//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 股东类型
/// </summary>
public enum HolderIs
{
    /// <summary />
    [Description( "其它" )]
    Other = 1,

    /// <summary />
    [Description( "个人" )]
    Person = 2,

    /// <summary />
    [Description( "基金" )]
    Fund = 3,

    /// <summary />
    [Description( "投资公司" )]
    Investment = 4,

    /// <summary />
    [Description( "券商" )]
    Securities = 5,

    /// <summary />
    [Description( "保险" )]
    Insurance = 6,

    /// <summary />
    [Description( "社保" )]
    SocialSecurity = 7,

    /// <summary />
    [Description( "信托" )]
    Loan = 8,

    /// <summary />
    [Description( "集合理财计划" )]
    FinancialPlan = 9,

    /// <summary />
    [Description( "企业年金" )]
    EnterpriseAnnuity = 10,

    /// <summary />
    [Description( "合格境外投资者" )]
    QFII = 11,

    /// <summary />
    [Description( "财务公司" )]
    FinanceCompany = 12,

    /// <summary />
    [Description( "金融" )]
    Financial = 13,

    /// <summary />
    [Description( "基本养老基金" )]
    PensionFund = 14,

    /// <summary />
    [Description( "高校" )]
    Universities = 15
}