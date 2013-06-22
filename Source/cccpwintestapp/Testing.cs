using System;
using System.Collections.Generic;
using System.Text;

namespace TestingOnly
{
    public abstract class MyBaseClass
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract void SayHello();
    }

    public class MyDerivedClass : MyBaseClass
    {
        public override void SayHello()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
