using System.Diagnostics.CodeAnalysis;

namespace Example.Singleton.Pure
{
	// Creating a singleton class is just a few lines of code, and
	// with the difficulty of making a generic singleton i always write those lines of code
	// from http://stackoverflow.com/questions/380755/a-generic-singleton
	public class Singleton
	{
		Singleton ()
		{
		}

		static Singleton ()
		{
		}

		static Singleton _instance = new Singleton ();

		public static Singleton Instance {
			get { 
				return _instance;
			}
		}

		// Actual functions starts here.
		int counter;

		public int Add (int count)
		{
			return counter += count;
		}
	}

	// Do not use generic Singleton Generics becasue
	// There's no good way to hide constructor in subclass.

	// Analysis disable once ConvertToStaticType
	public class Singleton<T> where T: class, new()
	{
		[SuppressMessage ("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		static readonly T _instance = new T ();

		public static T Instance {
			get {
				return _instance;
			}
		}
	}
		
	public class Counter: Singleton <Counter>
	{
		// Default constructor is here !!!
		// People can do `var c = new Counter();` easily!!!

		static Counter ()
		{
		}

		int counter;

		public int Add (int count)
		{
			return counter += count;
		}
	}
}