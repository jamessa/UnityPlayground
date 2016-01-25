using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class Fruit
{
	public string color;

	public Fruit () // Constructor
	{
		color = "orange";
//		Debug.Log ("1st Fruit Constructor is called");
	}

	public Fruit (string newColor) // 2nd Constructor
	{
		color = newColor;
//		Debug.Log ("2nd Fruit Constructor is called");
	}

	public string Chop ()
	{
		return "The " + color + " fruit has been chopped.";
	}
}

public class Apple : Fruit
{
	public Apple () // 1st constructor calls before everything
	{
		color = "red";
//		Debug.Log ("1st Apple Constructor is called");
	}

	// specify the which parent constructor will be called by base
	public Apple (string newColor) : base (newColor)
	{
//		Debug.Log ("2nd Apple Constructor called.");
	}

}

// Extension Method
// http://unity3d.com/learn/tutorials/modules/intermediate/scripting/extension-methods?playlist=17117
// The extension method format is very stricted, must follow this form. It looks like a compiler hack rather than a language feature.
public static class ExtensionMethods
{
	public static void Reset (this Apple app)
	{
		// extend the functionality
	}
}

public class CSharpLanguageTest
{

	// From http://unity3d.com/learn/tutorials/modules/intermediate/scripting/inheritance
	[Test]
	public void InheritanceTest ()
	{
		Apple anApple = new Apple ();
		Assert.AreEqual (typeof(Apple), anApple.GetType ());
		Assert.AreEqual ("The red fruit has been chopped.", anApple.Chop ());

		Fruit aFruit = new Fruit ();
		Assert.AreEqual (typeof(Fruit), aFruit.GetType ());
		Assert.AreEqual ("The orange fruit has been chopped.", aFruit.Chop ());
	}

	// From http://unity3d.com/learn/tutorials/modules/intermediate/scripting/polymorphism?playlist=17117
	[Test]
	public void PolymorphismTest ()
	{
		// Polymorphism
		Fruit[] fruitSalad = new Fruit[2];
		fruitSalad [0] = new Fruit ();
		fruitSalad [1] = new Apple ();
		Assert.AreEqual ("The orange fruit has been chopped.", fruitSalad [0].Chop ());
		Assert.AreEqual ("The red fruit has been chopped.", fruitSalad [1].Chop ());

		// Polymorphism
		Fruit myFruit = new Apple ();
		Assert.AreEqual ("The red fruit has been chopped.", myFruit.Chop ());

		// Downcasting
		Apple myApple = (Apple)myFruit;
		Assert.AreEqual ("The red fruit has been chopped.", myApple.Chop ());
	}

	// Test virtual
	class A
	{
		public string N ()
		{
			return "A.N";
		}

		public virtual string V ()
		{
			return "A.V";
		}

		public string H ()
		{
			return "A.H";
		}
	}

	class B:A
	{
		public string N ()
		{
			return "B.N";
		}

		public override string V ()
		{
			return "B.V";
		}

		new public string H ()
		{
			return "B.N";
		}
	}

	[Test]
	public void VirtualTest ()
	{
		B b = new B ();
		A a = b;
		Assert.AreEqual ("A.N", a.N ());
		Assert.AreEqual ("B.N", b.N ());

		// https://msdn.microsoft.com/en-us/library/aa645767(v=vs.71).aspx
		Assert.AreEqual ("B.V", a.V ()); // Virtual Func kicked in.
		Assert.AreEqual ("B.V", b.V ());

		Assert.AreEqual ("A.N", a.N ());
		Assert.AreEqual ("B.N", b.N ());
	}

	// Interface
	// http://unity3d.com/learn/tutorials/modules/intermediate/scripting/interfaces?playlist=17117
	interface IKillable
	{
		void Kill ();
	}

	interface IDamageable<T>
	{
		void Damage (T damageTaken);
	}

	class Avatar : Object, IKillable, IDamageable<int>
	{
		// must implement and must be public
		public void Kill ()
		{
		}

		public void Damage (int damageTaken)
		{
		}
	}

	[Test]
	public void InterfaceTest ()
	{
		Avatar a = new Avatar ();
		a.Kill ();
		a.Damage (10);
	}

	[Test]
	public void ExtensionMethodsTest ()
	{
		Apple a = new Apple ();
		a.Reset ();
	}

	// Coroutine with property
	// http://unity3d.com/learn/tutorials/modules/intermediate/scripting/coroutines
	class T
	{
		public int delay {
			get { return 0; }
			set {
				delay = value;
//				WaitFor (delay); // Crashes Unit Tests
			}
		}

		public System.Collections.IEnumerator WaitFor (int n)
		{
			yield return new WaitForSeconds (n);
		}
	}

	[Test]
	public void CoroutineTest ()
	{
		float begin = Time.time;
		T t = new T ();
		t.WaitFor (1);
//		t.delay = 1;
		float end = Time.time;
		// Should return immediately.
		Assert.GreaterOrEqual (0.1, end - begin);
	}

	class Calculator
	{
		public delegate int Operation (int n, int m);

		public Operation operation;

		public int add (int n, int m)
		{
			return n + m;
		}

		public int sub (int n, int m)
		{
			return n - m;
		}
	}

	// Delegates, function pointer actually.
	[Test]
	public void DelegateTest ()
	{
		Calculator c = new Calculator ();
		c.operation = c.add;
		Assert.AreEqual (2, c.operation (1, 1));
		c.operation = c.sub;
		Assert.AreEqual (0, c.operation (1, 1));

		// Muliple Delegate (closure)
		c.operation = null;
		c.operation += c.sub;
		c.operation += c.add;
		Assert.AreEqual (2, c.operation (1, 1));
		c.operation -= c.add;
		Assert.AreEqual (0, c.operation (1, 1));
	}


}
