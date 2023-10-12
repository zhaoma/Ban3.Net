using System;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

public interface IStoragesHelper
{
    Task<bool> Save<T>(T data,Func<T,string> key);

    Task<bool> Load<T>(string key);

    Task<bool> Delete<T>(T data);
}

