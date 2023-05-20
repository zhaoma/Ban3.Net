﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Consoles.Entries;

namespace AttrRead
{
    internal class Program
    {
        static Program()
        {

            AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
            {

            Console.WriteLine(e.Name);



            return Assembly.LoadFile(@"D:\GIT\Ban3.Net\Labs\ConsolesDemo\Lost\bin\Debug\netstandard2.0\Lost.dll");
      
            };
        }
        
        static void Main(string[] args)
        {

            Lost.Deleted.Found();

            //var x = Probe(@"root/CIMV2", "Win32_PerfFormattedData_Counters_ThermalZoneInformation", "Temperature");
            //Console.WriteLine($"x={x}");
            //Probe<double>(@"root/wmi", "MSAcpi_ThermalZoneTemperature", "CurrentTemperature");

            Console.ReadKey();
        }

        /*
         *
            var file = args != null&&args.Any() ? args[0] : @"D:\GIT\Ban3.Net\Labs\ConsolesDemo\AttrTest\bin\Debug\AttrTest.exe";

            P();
         *
         */

        static void P()
        {
            var method = new DynamicMethod("D", typeof(void), null);
            var il=method.GetILGenerator();

            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldstr,"ao");
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
            il.Emit(OpCodes.Ret);

            Action a=(Action)method.CreateDelegate(typeof(Action));
            a();
        }

        static void E()
        {
            var f1 = new DynamicMethod("F1", typeof(int), new []{typeof(int)});
            var il = f1.GetILGenerator();

            Label gt1=il.DefineLabel();
            Label next=il.DefineLabel();

            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Cgt);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Ceq);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Brfalse_S,gt1);     //label 0011
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Stloc_1);
            il.Emit(OpCodes.Br_S,next);          //label 0025

            il.MarkLabel(gt1);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Sub);
            il.Emit(OpCodes.Call,f1);          //call f1
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4_2);
            il.Emit(OpCodes.Sub);
            il.Emit(OpCodes.Call,f1);          //call f1
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc_1);
            il.Emit(OpCodes.Br_S,next);          //label 0025

            il.MarkLabel(next);

            il.Emit(OpCodes.Ldloc_1);
            il.Emit(OpCodes.Ret);

            f1.Invoke(null, BindingFlags.Public, null, new object[] { 11 }, CultureInfo.CurrentCulture);
        }

        static void F()
        {
            var f2 = new DynamicMethod("F2", typeof(int), new[] { typeof(int) });
            var il = f2.GetILGenerator();

            Label il_0013=il.DefineLabel();
            Label il_000d = il.DefineLabel();
            Label il_0018=il.DefineLabel();
            Label il_001d = il.DefineLabel();
            Label il_0028 = il.DefineLabel();
            Label il_0038 = il.DefineLabel();
            Label il_004b = il.DefineLabel();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Stloc_S,4);
            il.Emit(OpCodes.Ldloc_S,4);
            il.Emit(OpCodes.Stloc_3);
            il.Emit(OpCodes.Ldloc_3);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Beq_S, il_0013);
            il.Emit(OpCodes.Br_S, il_000d);

            il.MarkLabel(il_000d);

            il.Emit(OpCodes.Ldloc_3);
            il.Emit(OpCodes.Ldc_I4_2);
            il.Emit(OpCodes.Beq_S,il_0018);             //IL_0018
            il.Emit(OpCodes.Br_S, il_001d);              //IL_001d
            
            il.MarkLabel(il_0013);
            
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Stloc_S, 5);
            il.Emit(OpCodes.Br_S, il_004b);              //IL_004b

            il.MarkLabel(il_0018);

            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Stloc_S, 5);
            il.Emit(OpCodes.Br_S, il_004b);              //IL_004b

            il.MarkLabel(il_001d);

            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Stloc_1);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Stloc_2);
            il.Emit(OpCodes.Ldc_I4_3);
            il.Emit(OpCodes.Stloc_S, 6);
            il.Emit(OpCodes.Br_S, il_0038);              //IL_0038
            il.Emit(OpCodes.Nop);

            il.MarkLabel(il_0028);

            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ldloc_1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc_2);
            il.Emit(OpCodes.Ldloc_1);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_2);
            il.Emit(OpCodes.Stloc_1);
            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldloc_S, 6);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Stloc_S, 6);

            il.MarkLabel(il_0038);

            il.Emit(OpCodes.Ldloc_S, 6);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Cgt);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Ceq);
            il.Emit(OpCodes.Stloc_S, 7);
            il.Emit(OpCodes.Ldloc_S, 7);
            il.Emit(OpCodes.Brtrue_S,il_0028);          //IL_0028
            il.Emit(OpCodes.Ldloc_2);
            il.Emit(OpCodes.Stloc_S, 5);
            il.Emit(OpCodes.Br_S, il_004b);                      //IL_004b

            il.MarkLabel(il_004b);

            il.Emit(OpCodes.Ldloc_S, 5);
            il.Emit(OpCodes.Ret);

            Func<int, int> func2 = (Func<int, int>)f2.CreateDelegate(typeof(Func<int, int>));
            Console.WriteLine($"f1:10={func2(10)}");
        }

        static void Invoke(Assembly assembly)
        {
            var selectedType = assembly.GetType("AttrTest.Program");
            var method = selectedType.GetMethod("Fibonacci", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            if (method != null)
            {
                var result = method.Invoke(selectedType, new object[] { 11 });
                Console.WriteLine($"11={result}");
            }
            else
            {
                $"NOT found".WriteColorLine(ConsoleColor.Red);
            }

            selectedType.GetMethod("StaticWriteYes")?.Invoke(selectedType, null);

            dynamic at=Activator.CreateInstance(selectedType);
            //Console.WriteLine($"12={at.StaticWriteYes()}");
        }

        static void R(string file)
        {
            var assembly = Assembly.LoadFile(file);
            Display(assembly);
        }

        static void Display(Assembly assembly)
        {
            var cb = new ConsoleTable
            {
                Columns = new List<string> { "Module","Type","Method","Args","Body" }
            };

            foreach (var module in assembly.GetModules())
            {
                cb.Rows.Add(new[]{ module.Name ,"","", "", "" });

                foreach (var type in module.GetTypes())
                {
                    cb.Rows.Add(new[] {"", type.Name, "", "", "" });

                    foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
                    {
                        cb.Rows.Add(new[] { "","", methodInfo.Name, "", "" });

                        foreach (var parameter in methodInfo.GetParameters())
                        {
                            cb.Rows.Add(new[] { "", "","", parameter.Name, parameter.ParameterType.Name });
                        }

                        var body=methodInfo.GetMethodBody();
                        if (body == null)
                        {
                            cb.Rows.Add(new[] { "", "", "","","NOBODY" });
                        }
                        else
                        {
                            var bytes = body.GetILAsByteArray();
                            //Console.WriteLine(BitConverter.ToString(bytes));
                            //Decode(module, bytes);
                            
                            cb.Rows.Add(new[] { "", "", "", "", "bytes" });
                        }
                    }
                }
            }

            cb.Writer(ConsoleColor.DarkRed);
            
        }

        static void Decode(Module module, byte[] bytes)
        {
            foreach (var instruction in Decode(bytes))
            {
                string arg = instruction.Argument.ToString();
                if (instruction.OpCode == OpCodes.Ldfld || instruction.OpCode == OpCodes.Ldflda || instruction.OpCode == OpCodes.Ldsfld || instruction.OpCode == OpCodes.Ldsflda || instruction.OpCode == OpCodes.Stfld)
                    arg = module.ResolveField((int)instruction.Argument).Name;
                else if (instruction.OpCode == OpCodes.Call || instruction.OpCode == OpCodes.Calli || instruction.OpCode == OpCodes.Callvirt)
                    arg = module.ResolveMethod((int)instruction.Argument).Name;
                else if (instruction.OpCode == OpCodes.Newobj)
                    // This displays the type whose constructor is being called, but you can also determine the specific constructor and find out about its parameter types
                    arg = module.ResolveMethod((int)instruction.Argument).DeclaringType.FullName;
                else if (instruction.OpCode == OpCodes.Ldtoken)
                    arg = module.ResolveMember((int)instruction.Argument).Name;
                else if (instruction.OpCode == OpCodes.Ldstr)
                    arg = module.ResolveString((int)instruction.Argument);
                else if (instruction.OpCode == OpCodes.Constrained || instruction.OpCode == OpCodes.Box)
                    arg = module.ResolveType((int)instruction.Argument).FullName;
                else if (instruction.OpCode == OpCodes.Switch)
                    // For the 'switch' instruction, the "instruction.Argument" is meaningless. You'll need extra code to handle this.
                    arg = "?";
                Console.WriteLine(instruction.OpCode + " " + arg);
            }
            Console.ReadLine();
        }

        static IEnumerable<Instruction> Decode( byte[] bytes)
        {
            var opCodes = typeof(OpCodes).GetFields()
                .Where(f => f.FieldType == typeof(OpCode))
                .Select(f => (OpCode)f.GetValue(null))
                .ToDictionary(o => o.Value);

            int offset = 0;
            while (offset < bytes.Length)
            {
                int startOffset = offset;
                short opCodeValue = bytes[offset];

                offset++;

                if (opCodeValue == 0xFE || opCodes[opCodeValue].OpCodeType == OpCodeType.Prefix)
                {
                    opCodeValue = (short)((opCodeValue << 8) + bytes[offset]);
                    offset++;
                }

                OpCode code = opCodes[opCodeValue];


                Int64? argument = null;

                int argumentSize = 4;
                if (code.OperandType == OperandType.InlineNone)
                    argumentSize = 0;
                else if (code.OperandType == OperandType.ShortInlineBrTarget || code.OperandType == OperandType.ShortInlineI || code.OperandType == OperandType.ShortInlineVar)
                    argumentSize = 1;
                else if (code.OperandType == OperandType.InlineVar)
                    argumentSize = 2;
                else if (code.OperandType == OperandType.InlineI8 || code.OperandType == OperandType.InlineR)
                    argumentSize = 8;
                else if (code.OperandType == OperandType.InlineSwitch)
                {
                    long num = bytes[offset] + (bytes[offset + 1] << 8) + (bytes[offset + 2] << 16) + (bytes[offset + 3] << 24);
                    argumentSize = (int)(4 * num + 4);
                }

                // This does not currently handle the 'switch' instruction meaningfully.
                if (argumentSize > 0)
                {
                    Int64 arg = 0;
                    for (int i = 0; i < argumentSize; ++i)
                    {
                        Int64 v = bytes[offset + i];
                        arg += v << (i * 8);
                    }
                    argument = arg;
                    offset += argumentSize;
                }

                yield return new Instruction(startOffset, code, argument);
            }

        }
    }
}
