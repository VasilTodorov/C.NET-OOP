using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDownIterator
{
    #region Problem 7a
    public interface IEnumerator
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
    }
    public class Countdown : IEnumerator
    {
        int count = 17;
        public bool MoveNext() => count-- > 0;
        public object Current => count;
        public void Reset() { throw new NotSupportedException(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerator e = new Countdown();
            while (e.MoveNext())
                Console.Write(e.Current);
            Console.WriteLine();

        }
    }
    #endregion

    #region Problem 7b
    public interface IEnumeratorWithInternal
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
        public class Countdown : IEnumeratorWithInternal
        {
            int count = 17;
            public virtual bool MoveNext() => count-- > 0;
            public virtual object Current => count;
            public virtual void Reset() { throw new NotSupportedException(); }
        }
    }
    class IEnumeratorWithInternalImplementation
    {
        static void Main(string[] args)
        {
            IEnumeratorWithInternal e = new IEnumeratorWithInternal.Countdown();
            while (e.MoveNext())
                Console.Write(e.Current);
            Console.WriteLine();
        }
    }
    #endregion

    #region Problem 7c

    class IEnumeratorWithInternalWithOverride : IEnumeratorWithInternal.Countdown
    {
        int count = -1;
        public override bool MoveNext() => count++ < 16;
        public override object Current => count;
        public override void Reset()
        {
            throw new NotSupportedException();
        }
        static void Main(string[] args)
        {
            IEnumeratorWithInternal e = new IEnumeratorWithInternalWithOverride();
            while (e.MoveNext())
                Console.Write(e.Current);
            Console.WriteLine();

        }
    }
    #endregion

    #region Problem 7d
    public interface IEnumeratorWithInternalEx
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
        public class Countdown : IEnumeratorWithInternalEx
        {
            int count = 17;
            bool IEnumeratorWithInternalEx.MoveNext() => count-- > 0;
            object IEnumeratorWithInternalEx.Current => count;
            void IEnumeratorWithInternalEx.Reset() { throw new NotSupportedException(); }
        }
    }
    class IEnumeratorWithInternalImplementationEx
    {
        static void Main(string[] args)
        {
            IEnumeratorWithInternalEx e = new IEnumeratorWithInternalEx.Countdown();
            while (e.MoveNext())
                Console.Write(e.Current);
            Console.WriteLine();
        }
    } 
    #endregion

}
