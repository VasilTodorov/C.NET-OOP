using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInOut
{
    class Animal { }

    class Mammal : Animal { }

    class Dog : Mammal { }
    interface IInvariant<T>
    {
        T Get(); // ok, an invariant type can be both put into and returned
        void Set(T t); // ok, an invariant type can be both put into and returned
    }
    /// <summary>
    /// Declares 2 things:
    /// Some of my methods accept a Mammal(hence in generic modifier)
    /// None of my methods return a Mammal - this is interesting though, 
    /// because this is the actual restriction imposed by the in generic modifier
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IContravariant<in T>
    {
        //T Get(); // compilation error, cannot return a contravariant type
        void Set(T t); // ok, a contravariant type can only be **put into** our class (hence "in")
    }
    /// <summary>
    /// ICovariant<Mammal>, it declares 2 things:
    /// Some of my methods return a Mammal(hence out generic modifier)
    /// None of my methods accept a Mammal - this is interesting though, 
    /// because this is the actual restriction imposed by the out generic modifier
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICovariant<out T>
    {
        T Get(); // ok, a covariant type can only be **returned** from our class (hence "out")
                 //void Set(T t); // compilation error, cannot put a covariant type into our class
    }

    class Program
    {
        /// <summary>
        /// DerivedType = BaseType
        /// IInvariant<Mammal> invariantMammal = (IInvariant<Animal>)null
        /// Whoever calls IInvariant<Mammal>.Get() expects a Mammal, 
        /// but IInvariant<Animal>.Get() -returns an Animal. 
        /// Not every Animal is a Mammal so it's incompatible.
        /// BaseType=DerivedType
        /// IInvariant<Mammal> invariantMammal = (IInvariant<Dog>)null
        /// Whoever calls IInvariant<Mammal>.Set(Mammal) expects that a Mammal
        /// can be passed.Since IInvariant<Animal>.Set(Animal) accepts any Animal 
        /// (including Mammal), it's compatible

        /// </summary>
        static void TestInvariance()
        {
            IInvariant<Animal> invariantAnimal1 = (IInvariant<Animal>)null; // ok
                                                                            // IInvariant<Animal> invariantAnimal2 = (IInvariant<Mammal>)null; // compilation error
                                                                            // IInvariant<Animal> invariantAnimal3 = (IInvariant<Dog>)null; // compilation error

            // IInvariant<Mammal> invariantMammal1 = (IInvariant<Animal>)null; // compilation error
            IInvariant<Mammal> invariantMammal2 = (IInvariant<Mammal>)null; // ok
                                                                            // IInvariant<Mammal> invariantMammal3 = (IInvariant<Dog>)null; // compilation error

            //IInvariant<Dog> invariantDog1 = (IInvariant<Animal>)null; // compilation error
            //IInvariant<Dog> invariantDog2 = (IInvariant<Mammal>)null; // compilation error
            IInvariant<Dog> invariantDog3 = (IInvariant<Dog>)null; // ok
        }
        /// <summary>
        /// Derived = Base
        /// ICovariant<Mammal> covariantMammal = (ICovariant<Animal>)null
        /// Whoever calls ICovariant<Mammal>.Get() expects a Mammal,
        /// but ICovariant<Animal>.Get() - returns an Animal. 
        /// Not every Animal is a Mammal so it's incompatible.
        /// ICovariant.Set(Mammal) - this is no longer an issue thanks to the out modifier
        /// restrictions!
        /// Base = Derived
        /// ICovariant<Mammal> covariantMammal = (ICovariant<Dog>)null
        /// Whoever calls ICovariant<Mammal>.Get() expects a Mammal, 
        /// ICovariant<Dog>.Get() - returns a Dog, every Dog is a Mammal, 
        /// so it's compatible.
        /// ICovariant.Set(Mammal) - this is no longer an issue thanks to the out modifier
        /// restrictions!
        /// CONCLUSION such assignment is COMPATIBLE
        /// </summary>
        /// </summary>
        static void TestCovariance()
        {
            ICovariant<Animal> covariantAnimal1 = (ICovariant<Animal>)null; // ok
            ICovariant<Animal> covariantAnimal2 = (ICovariant<Mammal>)null; // ok!!!
            ICovariant<Animal> covariantAnimal3 = (ICovariant<Dog>)null; // ok!!!

            //ICovariant<Mammal> covariantMammal1 = (ICovariant<Animal>)null; // compilation error
            ICovariant<Mammal> covariantMammal2 = (ICovariant<Mammal>)null; // ok
            ICovariant<Mammal> covariantMammal3 = (ICovariant<Dog>)null; // ok!!!

            //ICovariant<Dog> covariantDog1 = (ICovariant<Animal>)null; // compilation error
            ICovariant<Dog> covariantDog3 = (ICovariant<Dog>)null; // ok
        }

        /// <summary>
        /// Derived = Base
        /// IContravariant<Mammal> contravariantMammal = (IContravariant<Animal>)null
        /// IContravariant<Mammal>.Get() - this is no longer an issue thanks to the in modifier
        /// restrictions!
        /// Whoever calls IContravariant<Mammal>.Set(Mammal) expects that a Mammal 
        /// can be passed.
        /// Since IContravariant<Animal>.Set(Animal) accepts any Animal (including Mammal),
        /// it's compatible
        /// Base = Derived
        /// IContravariant<Mammal> contravariantMammal = (IContravariant<Dog>)null
        /// IContravariant<Mammal>.Get() - this is no longer an issue thanks to the in modifier 
        /// restrictions!
        /// Whoever calls IContravariant<Mammal>.Set(Mammal) expects that a Mammal can be passed.
        /// Since IContravariant<Dog>.Set(Dog) accepts only Dogs (and not every Mammal as a Dog), 
        /// it's incompatible
        /// </summary>
        static void TestContravariance()
        {
            IContravariant<Animal> contravariantAnimal1 = (IContravariant<Animal>)null; // ok
            //IContravariant<Animal> contravariantAnimal2 = (IContravariant<Mammal>)null; // compilation error
            //IContravariant<Animal> contravariantAnimal3 = (IContravariant<Dog>)null; // compilation error

            IContravariant<Mammal> contravariantMammal1 = (IContravariant<Animal>)null; // ok!!!
            IContravariant<Mammal> contravariantMammal2 = (IContravariant<Mammal>)null; // ok
            //IContravariant<Mammal> contravariantMammal3 = (IContravariant<Dog>)null; // compilation error

            IContravariant<Dog> contravariantDog1 = (IContravariant<Animal>)null; // ok!!!
            IContravariant<Dog> contravariantDog2 = (IContravariant<Mammal>)null; // ok!!!
            IContravariant<Dog> contravariantDog3 = (IContravariant<Dog>)null; // ok

        }
        static void Main(string[] args)
        {


        }
    }
}
