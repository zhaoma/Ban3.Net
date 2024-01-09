//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Microsoft.CSharp;

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// (动态)编译相关
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 编译源码
    /// </summary>
    /// <param name="codeFiles">源码(每文件)</param>
    /// <param name="references">引用/依赖库(.dll)</param>
    /// <returns></returns>
    public static Assembly? CompileSourceCodes( this string[] codeFiles, List<string> references )
    {
        try
        {
            using var codeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new()
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };

            references.ForEach( r =>
            {
                compilerParameters.ReferencedAssemblies.Add( r );
            } );

            var compilerResult = codeProvider.CompileAssemblyFromSource( compilerParameters, codeFiles );

            if( compilerResult.Errors.HasErrors )
            {
                foreach( CompilerError err in compilerResult.Errors )
                {
                    Logger.Error( $"{err.ErrorNumber}:{err.ErrorText}" );
                }

                return null;
            }

            return compilerResult.CompiledAssembly;
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return null;
    }
}