using foo = System.Collections;

class X : foo::IEnumerable {
	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator () { return null; }
	static void Main ()
	{
		System.Collections.IEnumerable x = new X ();
	}
}
