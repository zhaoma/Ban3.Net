namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IInternetHost
{
    bool Anonymous { get; set; }

    string AuthenticationType { get; set; }

    string Domain { get; set; }

    string BaseUrl { get; set; }

    string UserName { get; set; }

    string Password { get; set; }
}