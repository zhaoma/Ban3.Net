using System;
using System.Collections.Generic;
using System.Linq;
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
        static void Main(string[] args)
        {

            var file = args != null&&args.Any() ? args[0] : @"D:\GIT\Ban3.Net\Labs\ConsolesDemo\AttrTest\bin\Debug\AttrTest.exe";
            


            
            Console.ReadKey();
        }

        static void E()
        {
            var f1 = new DynamicMethod("F1", typeof(int), new []{typeof(int)});
            var il = f1.GetILGenerator();

            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Cgt);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Ceq);
            il.Emit(OpCodes.Stloc_0);
            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Brfalse_S);
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
