namespace simaira_backend_playground.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public interface ICustomeList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        
    }

    public class Parent
    {
        int jk;
        public void SimpleParentMethod()
        {
            Console.WriteLine("Simple Parent Method:" + jk);
        }
        public void ParentMethod()
        {
            Console.WriteLine("Parent Method");
        }
        public virtual void VirtualParentMethod()
        {
            Console.WriteLine("Virtual Parent Method");
        }

    }

    public class Child : Parent
    {
        public void SimpleChildMethod()
        {
            Console.WriteLine("Simple Child Method");
        }
        public new void ParentMethod()
        {
            Console.WriteLine("Child new Parent Method");
        }

        public override void VirtualParentMethod()
        {
            Console.WriteLine("child Virtual Parent Method");
        }

    }
    
}
