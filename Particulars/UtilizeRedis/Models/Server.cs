namespace Ban3.Particulars.UtilizeRedis.Models;

public class Server
{
	public string Endpoints { get; set; } = string.Empty;

	public string Password { get; set; } = string.Empty;

	public int DbNumber { get; set; }

	public int KeepAlive { get; set; }

	public bool HasValue() => !string.IsNullOrEmpty(Endpoints);
}

