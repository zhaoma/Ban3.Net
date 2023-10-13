/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IMail
{
    IEnumerable<IMailTo> To { get; set; }

    IEnumerable<IMailTo> Cc { get; set; }

    string Subject { get; set; }

    string Body { get; set; }

    IMailTo From { get; set; }
}