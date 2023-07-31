/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using Ban3.Infrastructures.DataPersist.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.DataPersist.Models;

public class DB
{
    [JsonProperty("database", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Database Database { get; set; }

    [JsonProperty("connectionString", NullValueHandling = NullValueHandling.Ignore)]
    public string ConnectionString { get; set; }
}