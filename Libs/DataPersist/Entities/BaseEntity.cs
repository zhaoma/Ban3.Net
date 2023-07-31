/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
namespace Ban3.Infrastructures.DataPersist.Entities;

public class BaseEntity
{

    public virtual object KeyValue()
    {
        return null;
    }

    public virtual string EqualCondition()
    {
        return string.Empty;
    }
}