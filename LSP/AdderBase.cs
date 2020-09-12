using System;

namespace LSP
{
    public class AdderBase
    {
        public virtual int Add(int a, int b)
        {
            return a + b;
        }
    }

    public class BadAdder : AdderBase
    {
        public override int Add(int a, int b)
        {
            // violates the LSP
            return a - b;
        }
    }

    public class GoodAdder : AdderBase
    {
        public override int Add(int a, int b)
        {
            var fa = a + 0.0;
            var fb = b + 0.0;
            return (int) (fa + fb);
        }
    }

    public class AnotherAdder : AdderBase
    {
        public override int Add(int a, int b)
        {
            // some other implmentation;
            return a > b ? base.Add(a, b) : base.Add(b, a);
        }
    }
}
