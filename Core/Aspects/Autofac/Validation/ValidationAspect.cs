using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        //validatorType ver
        public ValidationAspect(Type validatorType)
        {
            //gönderilen validator type IValidator değil ise ozaman doğrulama olduğunu söyle car için car validatorType
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //çalışma anında CreateInstance oluştur 
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //çalışma tipini bul,onun GetGenericArguments ilkini bul
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //ilgili methodun parametrelerini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                //her birini tek tek gez ValidationTool dan Validate et
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
