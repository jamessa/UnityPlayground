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
		int Counter;

		public int Add (int count)
		{
			return Counter += count;
		}
	}
}