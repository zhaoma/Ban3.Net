﻿namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response;

public class CountedResult<T>
{
    public CountedResult()
    {
    }

    
    public int Count { get; set; }

    
    public List<T> Value { get; set; }
}