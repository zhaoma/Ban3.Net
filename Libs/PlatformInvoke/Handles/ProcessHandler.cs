/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            外部程序执行
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Diagnostics;
using System.Threading;

namespace Ban3.Infrastructures.PlatformInvoke.Handles
{
    /// <summary>
    /// 外部程序执行
    /// </summary>
    public class ProcessHandler
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
        public ProcessHandler() {}

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="arguments"></param>
        public ProcessHandler( string fileName, string arguments )
        {
            CommandFileName = fileName;
            CommandArguments = arguments.Split(' ');
        }

        public ProcessHandler(string fileName, string[] arguments)
        {
            CommandFileName = fileName;
            CommandArguments = arguments;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            if( string.IsNullOrEmpty( CommandFileName ) )
            {
                Error = "NONE COMMAND.";
                return;
            }

            exe = new Process
            {
                    StartInfo = new ProcessStartInfo
                    {
                            FileName =$"\"{ CommandFileName}\"",
                            Arguments = string.Join(" ",CommandArguments),
                            ErrorDialog = false,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                    }
            };

            exe.Start();

            Output=exe.StandardOutput.ReadToEnd();
            Error=exe.StandardError.ReadToEnd();

            ExitCode=exe.ExitCode;
            exe.WaitForExit();
        }

        private Process exe;

        /// <summary>
        /// 
        /// </summary>
        public int ExitCode { get; set; }

        public string Output { get; set; }

        public string Error { get; set; }
    }
}