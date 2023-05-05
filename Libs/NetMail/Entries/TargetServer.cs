using System;
namespace Ban3.Infrastructures.NetMail.Entries;

	public class TargetServer
	{

    public string ServerEndpoint{get;set;} = string.Empty;

    public int ServerPort{get;set;}=25;

    public bool EnableSsl{get;set;}=true;

    public string UserName{get;set;}=string.Empty;


    public string Password { get; set; } = string.Empty;

    public string TagName { get; set; } = string.Empty;
    }
