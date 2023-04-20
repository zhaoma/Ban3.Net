using System;
using PostSharp.Aspects;
using PostSharp.Reflection;
using PostSharp.Serialization;

namespace AttrTest
{
    [PSerializable]
    public class TargetAspect : LocationInterceptionAspect
    {

        //当目标类初始化属性的时候运行此函数。
        public override void RuntimeInitialize(LocationInfo locationInfo)

        {
            /*
            string name = locationInfo.DeclaringType.Name + "." +
                          locationInfo.Name + " (" + locationInfo.LocationType.Name + ")"; 

            System.Reflection.FieldInfo finfo = locationInfo.FieldInfo;
            */
            Console.WriteLine($"RuntimeInitialize:{locationInfo.DeclaringType.FullName}.[{locationInfo.FieldInfo.Name}]");
            
        }

        public override void OnSetValue(LocationInterceptionArgs args)
        {
            Console.WriteLine($"SET:{args.Value}");
            args.Value = 81;
            base.OnSetValue(args);
        }

        public override void OnGetValue(LocationInterceptionArgs args)
        {
            Console.WriteLine($"GET:{args.Value}");

            args.Value = 49;

            base.OnGetValue(args);
        }
    }
}