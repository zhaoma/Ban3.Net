using System;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace Ban3.Infrastructures.NativeLibs.Extensions
{
	public static partial class Helper
	{
        public static void ExecuteProgram(string code)
        {
            try
            {
                CodeDomProvider cdp = CodeDomProvider.CreateProvider("C#");
                CompilerParameters cps = new CompilerParameters();
                //添加DLL引用，设置参数
                var reference = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
                string[] dll = new string[reference.Length];
                for (int i = 0; i < reference.Length; i++)
                {
                    dll[i] = reference[i].Name + ".dll";
                }
                cps.ReferencedAssemblies.AddRange(dll);
                cps.GenerateInMemory = true;
                cps.GenerateExecutable = false;

                string codeTxt = code; //这里就是要编译的代码

                //编译
                CompilerResults rst = cdp.CompileAssemblyFromSource(cps, codeTxt);
                if (rst.Errors.HasErrors)
                {
                    for (int i = 0; i < rst.Errors.Count; i++)
                    {
                        //MessageBox.Show(rst.Errors[i].FileName + ":\n" + rst.Errors[i].ErrorText);
                    }
                }
                else
                {
                    try
                    {
                        Assembly asy = rst.CompiledAssembly; //拿到编译后的程序集
                        Type tp = asy.GetType("DynamicCode.Program"); //获取其中的类
                        object obj = asy.CreateInstance(tp.FullName);
                        var aa = tp.GetMethod("Main");//执行方法
                        aa.Invoke(obj, null);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("实例化应用时出错：\r\n" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("编译出错：\r\n" + ex.Message);
            }
        }

        //代码模板案例
        //using System;
        //using System.CodeDom.Compiler;
        //using System.Collections.Generic;
        //using System.ComponentModel;
        //using System.Diagnostics;
        //using System.Drawing;
        //using System.IO;
        //using System.Reflection;
        //using System.Text;
        //using System.Threading;
        //using System.Threading.Tasks;
        //using System.Windows.Forms;

        //namespace DynamicCode
        //{
        //    //Here is class place//
        //    //===Class===//
        //    public class Program
        //    {

        //        /// <summary>
        //        /// 应用程序的主入口点。
        //        /// </summary>
        //        public void Main()
        //        {
        //            MessageBox.Show("123");
        //            //Here is code body place//
        //            //===Code===//
        //        }
        //    }
        //}
    }
}

