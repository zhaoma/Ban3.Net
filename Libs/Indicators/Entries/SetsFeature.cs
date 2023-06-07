using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Indicators.Entries;

public class SetsFeature
{
    public SetsFeature(string key, string subject,  int value)
    {
        Key = key;
        Subject = subject;
        Value = value;
    }

    public string Key { get; set; }

    public string Subject { get; set; }
    
    public int Value { get; set; } 
}
