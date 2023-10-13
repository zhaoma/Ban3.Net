/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IMailServer
{
    string ServerEndpoint { get; set; }

    int ServerPort { get; set; }

    bool EnableSsl { get; set; }

    bool UseDefaultCredentials { get; set; }

    string UserName { get; set; }

    string Password { get; set; }
}