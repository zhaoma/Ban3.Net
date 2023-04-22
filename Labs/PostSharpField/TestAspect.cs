using System;
using Microsoft.Win32;
using PostSharp.Aspects;
using PostSharp.Reflection;

namespace PostSharpMethod
{
    [Serializable]
    public class TestAspect : LocationInterceptionAspect
    {
        //当目标类初始化属性的时候运行此函数。
        public override void RuntimeInitialize(LocationInfo locationInfo)
        {
            //打印类名、属性或字段名、字段类型
            string name = locationInfo.DeclaringType.Name + "." + 
                locationInfo.Name + " (" + locationInfo.LocationType.Name + ")"; ;
            Console.WriteLine(name);
            Console.WriteLine("A");
            System.Reflection.FieldInfo finfo = locationInfo.FieldInfo;
        }
        //设置属性的时候运行
        public override void OnSetValue(LocationInterceptionArgs args)
        {
            Console.WriteLine(args.LocationName);
            Console.WriteLine("B");
            base.OnSetValue(args);
        }
        //获取属性的时候运行
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            Console.WriteLine("C");
            base.OnGetValue(args);
        }
    }
}
