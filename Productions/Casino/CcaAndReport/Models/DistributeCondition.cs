using System;
using Ban3.Productions.Casino.Contracts.Request;

namespace Ban3.Productions.Casino.CcaAndReport.Models;

public class DistributeCondition
{
    public DistributeCondition() { }

    public DistributeCondition(int rank, string subject, RenderView request)
    {
        Rank = rank;
        Subject = subject;
        Request = request;
    }

    public int Rank { get; set; }

	public string Subject { get; set; }

	public RenderView Request { get; set; }
}