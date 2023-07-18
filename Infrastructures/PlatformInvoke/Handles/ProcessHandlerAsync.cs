/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            外部程序执行
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Diagnostics;

namespace Ban3.Infrastructures.PlatformInvoke.Handles;

/// <summary>
/// 外部程序执行
/// </summary>
public class ProcessHandlerAsync
{
    /// <summary>
    /// 命令文件
    /// </summary>
    public string CommandFileName { get; set; }

    /// <summary>
    /// 命令参数
    /// </summary>
    public string[] CommandArguments { get; set; }

    /// ctor
    public ProcessHandlerAsync()
    {
    }

    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="arguments"></param>
    public ProcessHandlerAsync(string fileName, string arguments)
    {
        CommandFileName = fileName;
        CommandArguments = arguments.Split(' ');
    }

    /// <summary>
    /// 异步调用
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="arguments"></param>
    public ProcessHandlerAsync(string fileName, string[] arguments)
    {
        CommandFileName = fileName;
        CommandArguments = arguments;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Execute()
    {
        if (string.IsNullOrEmpty(CommandFileName))
        {
            if (ReceivedError != null)
                ReceivedError("NONE COMMAND.");

            return;
        }

        _exe = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = $"\"{CommandFileName}\"",
                Arguments = string.Join(" ", CommandArguments),
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            }
        };

        _exe.EnableRaisingEvents = true;
        _exe.ErrorDataReceived += OnErrorDataReceived;
        _exe.OutputDataReceived += OnOutputDataReceived;
        _exe.Exited += OnExited;

        _exe.Start();

        _exe.BeginOutputReadLine();
        _exe.BeginErrorReadLine();

        _exe.WaitForExit();
    }

    private Process _exe;

    /// <summary>
    /// 
    /// </summary>
    public int ExitCode { get; set; }

    /// <summary>
    /// 已结束
    /// </summary>
    public bool Ended;

    /// <summary>
    /// terminal
    /// </summary>
    public void Kill()
    {
        _exe.Kill();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void OnErrorDataReceived(object sender, DataReceivedEventArgs args)
    {
        if (ReceivedError is null || args?.Data is null)
            return;

        ReceivedError(args.Data);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void OnOutputDataReceived(object sender, DataReceivedEventArgs args)
    {
        if (ReceivedData is null || args?.Data is null)
            return;

        ReceivedData(args.Data);
    }

    private void OnExited(object sender, EventArgs e)
    {
        ExitCode = _exe.ExitCode;
        if (Exited != null)
            Exited();

        Ended = true;
    }

    /// <summary>
    /// 收到错误事件
    /// </summary>
    public Action<string> ReceivedError;

    /// <summary>
    /// 收到信息事件
    /// </summary>
    public Action<string> ReceivedData;

    /// <summary>
    /// 退出事件
    /// </summary>
    public Action Exited;
}