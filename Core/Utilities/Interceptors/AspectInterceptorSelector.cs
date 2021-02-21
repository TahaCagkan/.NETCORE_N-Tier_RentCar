using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //class Attribute oku
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                          (true).ToList();
            //method Attribute oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //çalışma sırasını önceliğe göre sırala
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
