namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IInternetResponse
{
    int StatusCode { get; set; }

    IInternetData Response { get; set; }
}