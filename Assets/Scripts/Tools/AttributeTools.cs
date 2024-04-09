using System;
using System.Collections.Generic;
using System.Reflection;
public class AttributeTools
{

    /// <summary>
    /// 获得对应对象里  指定属性的方法信息
    /// </summary>
    /// <typeparam name="TAtrribute">对应属性</typeparam>
    /// <param name="type">对应类</param>
    public static Dictionary<TAttribute, MethodInfo> GetAttributeMethods<TAttribute>(object obj) where TAttribute : Attribute
    {
        var methods = obj.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        var resDic = new Dictionary<TAttribute, MethodInfo>();
        foreach (var method in methods)
        {
            var attribute = method.GetCustomAttribute<TAttribute>();
            if (attribute != null)
            {
                resDic.Add(attribute, method);
            }
        }
        return resDic;
    }
}