namespace Example.Singleton.Pure
{
	public class Singleton
	{
		// private by default
		static Singleton instance;

		Singleton ()
		{
		}

		public static Singleton Instance {
			get { 
				if (instance == null) {
					instance = new Singleton ();
				}
				return instance;
			}
		}

		// set to zero by default
		int Counter;

		public int Add (int count)
		{
			return Counter += count;
		}
	}
}