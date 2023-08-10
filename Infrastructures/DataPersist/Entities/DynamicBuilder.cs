using System;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace Ban3.Infrastructures.DataPersist.Entities;

/// <summary>
/// 快速实例填充
/// </summary>
/// <typeparam name="T"></typeparam>
public class DynamicBuilder<T>
{
    private static readonly MethodInfo GetValueMethod =
        typeof(IDataRecord).GetMethod("get_Item", new [] { typeof(int) })!;

    private static readonly MethodInfo IsDBNullMethod =
        typeof(IDataRecord).GetMethod("IsDBNull", new [] { typeof(int) })!;

    private delegate T Load(IDataRecord dataRecord);

    private Load? _handler;

    /// 
    private DynamicBuilder()
    {
    }

    /// <summary>
    /// Builds the specified data record.
    /// </summary>
    /// <param name="dataRecord">The data record.</param>
    /// <returns></returns>
    public T Build(IDataRecord dataRecord)
    {
        return _handler!(dataRecord);
    }

    /// <summary>
    /// Creates the builder.
    /// </summary>
    /// <param name="dataRecord">The data record.</param>
    /// <returns></returns>
    public static DynamicBuilder<T> CreateBuilder(IDataRecord dataRecord)
    {
        var dynamicBuilder = new DynamicBuilder<T>();

        DynamicMethod method = new DynamicMethod("DynamicCreate", typeof(T), new [] { typeof(IDataRecord) },
            typeof(T), true);
        ILGenerator generator = method.GetILGenerator();

        LocalBuilder result = generator.DeclareLocal(typeof(T));
        generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes)!);
        generator.Emit(OpCodes.Stloc, result);

        for (int i = 0; i < dataRecord.FieldCount; i++)
        {
            var propertyInfo = typeof(T).GetProperty(dataRecord.GetName(i));
            Label endIfLabel = generator.DefineLabel();

            if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
            {
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Callvirt, IsDBNullMethod);
                generator.Emit(OpCodes.Brtrue, endIfLabel);

                generator.Emit(OpCodes.Ldloc, result);
                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Callvirt, GetValueMethod);
                generator.Emit(OpCodes.Unbox_Any, dataRecord.GetFieldType(i));
                generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());

                generator.MarkLabel(endIfLabel);
            }
        }

        generator.Emit(OpCodes.Ldloc, result);
        generator.Emit(OpCodes.Ret);

        dynamicBuilder._handler = (Load)method.CreateDelegate(typeof(Load));
        return dynamicBuilder;
    }
}