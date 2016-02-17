using UnityEngine;
using foo;

public class NamespaceController : MonoBehaviour
{

	public void Start ()
	{
		bar.print ("Hello"); 		// bar Hello
		foo.bar.print ("World");	// foo.bar World
		global::bar.print ("!");	// bar !
	}

}
