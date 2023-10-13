/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IMailTo
{
    string Email { get; set; }

    string Name { get; set; }
}