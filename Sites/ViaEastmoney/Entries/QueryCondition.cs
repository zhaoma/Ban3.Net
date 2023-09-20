using System;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaEastmoney.Entries;

public class QueryCondition
{
    /*
    https://datacenter-web.eastmoney.com/api/data/v1/get?
    
    //sortColumns=UPDATE_DATE%2CSECURITY_CODE%2CHOLDER_RANK
    //&sortTypes=-1%2C1%2C1
    &pageSize=50
    &pageNumber=1
    &reportName=RPT_CUSTOM_F10_EH_FREEHOLDERS_JOIN_FREEHOLDER_SHAREANALYSIS
    &columns=ALL%3BD10_ADJCHRATE%2CD30_ADJCHRATE%2CD60_ADJCHRATE
    &source=WEB
    &client=WEB
    &filter=(END_DATE%3E=%272023-01-1%27)

    https://datacenter-web.eastmoney.com/api/data/v1/get?
    pageSize=50
    &pageNumber=1
    &reportName=RPT_CUSTOM_F10_EH_FREEHOLDERS_JOIN_FREEHOLDER_SHAREANALYSIS
    &columns=ALL
    &filter=(END_DATE%3E=%272023-01-1%27)
    
    https://datacenter-web.eastmoney.com/api/data/v1/get?pageSize=50&pageNumber=1&reportName=RPT_CUSTOM_F10_EH_FREEHOLDERS_JOIN_FREEHOLDER_SHAREANALYSIS&columns=ALL&filter=(END_DATE>='2023-01-1')
    
    */

    public int PageSize { get; set; } = 50;

    public int PageNumber { get; set; } = 1;

    public Enums.ReportName ReportName { get; set; } 

    public string Columns { get; set; } = "ALL";

    public string Filter { get; set; } = $"(END_DATE%3E='{DateTime.Now.Year}-01-01')";

    public string QueryString() => $"pageSize={PageSize}&pageNumber={PageNumber}&reportName={ReportName.EnumDescription()}&columns={Columns}&filter={Filter}";
}

