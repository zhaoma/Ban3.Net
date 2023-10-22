using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 股东类型
/// </summary>
public enum HolderIs
{
    [Description("其它")]
    Other=1,

    [Description("个人")]
    Person=2,

    [Description("基金")]
    Fund=3,

    [Description("投资公司")]
    Investment=4,

    [Description("券商")]
    Securities=5,

    [Description("保险")]
    Insurance=6,

    [Description("社保")]
    SocialSecurity=7,

    [Description("信托")]
    Loan=8,

    [Description("集合理财计划")]
    FinancialPlan=9,

    [Description("企业年金")]
    EnterpriseAnnuity=10,

    [Description("合格境外投资者")]
    QFII=11,

    [Description("财务公司")]
    FinanceCompany=12,

    [Description("金融")]
    Financial=13,

    [Description("基本养老基金")]
    PensionFund=14,

    [Description("高校")]
    Universities=15
}

