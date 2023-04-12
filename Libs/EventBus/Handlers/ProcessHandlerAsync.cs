/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            外部程序执行
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Diagnostics;

namespace  Ban3.Infrastructures.EventBus.Handlers
{
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
        public string CommandArguments { get; set; }

        /// ctor
        public ProcessHandlerAsync() {}

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="arguments"></param>
        public ProcessHandlerAsync( string fileName, string arguments )
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
                if( ReceivedError != null )
                    ReceivedError( "NONE COMMAND." );

                return;
            }

            exe = new Process
            {
                    StartInfo = new ProcessStartInfo
                    {
                            FileName = CommandFileName,
                            Arguments = CommandArguments,
                            ErrorDialog = false,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                    }
            };

            exe.Start();

            exe.ErrorDataReceived += OnErrorDataReceived;
            exe.OutputDataReceived += OnOutputDataReceived;

            exe.EnableRaisingEvents = true;
            exe.Exited += Exited;
        }

        private Process exe;

        /// <summary>
        /// 
        /// </summary>
        public int ExitCode { get; set; }

        /// <summary>
        /// terminal
        /// </summary>
        public void Kill()
        {
            exe.Kill();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnErrorDataReceived( object sender, DataReceivedEventArgs args )
        {
            if( ReceivedError is null || args?.Data is null )
                return;

            ReceivedError( args.Data );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnOutputDataReceived( object sender, DataReceivedEventArgs args )
        {
            if( ReceivedData is null || args?.Data is null )
                return;

            ReceivedData( args.Data );
        }

        private void OnExited( object sender, EventArgs e )
        {
            ExitCode = exe.ExitCode;
            if( Exited != null )
                Exited( sender, e );
        }

        /// <summary>
        /// 收到错误事件
        /// </summary>
        public event DataHandle<string> ReceivedError;

        /// <summary>
        /// 收到信息事件
        /// </summary>
        public event DataHandle<string> ReceivedData;

        /// <summary>
        /// 退出事件
        /// </summary>
        public event EventHandler Exited;
    }

    public delegate void DataHandle<in T>(T data);
}