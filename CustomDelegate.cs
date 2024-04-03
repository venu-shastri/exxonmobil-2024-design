using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigm
{
  // int *p;
  // 
    public  class PredicateCommand
    {
        object targetObj;
        string methodName;
        //Execute
        public PredicateCommand(object target,string method)
        {
            this.targetObj= target; 
            this.methodName= method;
           System.Reflection.MethodInfo methodMetadata=
                this.targetObj.GetType().GetMethod(this.methodName);
            if(methodMetadata.ReturnType==typeof(bool) && methodMetadata.GetParameters().Length==1&& methodMetadata.GetParameters()[0].ParameterType == typeof(string))
            {

            }
        }
        public bool Invoke(string item)
        {
           object result= this.targetObj.GetType().
                GetMethod(this.methodName).Invoke(this.targetObj,new object[] { item });
            return Convert.ToBoolean(result);
        }
    }
}
