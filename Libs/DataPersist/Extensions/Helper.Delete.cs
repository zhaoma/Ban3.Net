/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ban3.Infrastructures.DataPersist.Extensions;

public static partial class Helper
{
    public static int Delete<T>(this T entity, IDbTransaction? transaction = null) where T : class
        => typeof(T)
            .DB()!
            .Command(typeof(T).SqlForDelete(), transaction)
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQuery();
}