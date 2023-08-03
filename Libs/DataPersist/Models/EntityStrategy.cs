
using System;
using System.Collections.Generic;
using System.Text;
using Ban3.Infrastructures.DataPersist.Attributes;

namespace Ban3.Infrastructures.DataPersist.Models;

public class EntityStrategy
{
    public TableIsAttribute? Table { get; set; }

    public Dictionary<string, FieldIsAttribute>? Fields { get; set; }


}