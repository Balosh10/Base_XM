package crc64fcfceb47582a9f46;


public class EntryCustomRenderer
	extends crc643f46942d9dd1fff9.EntryRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App_Base_XF.Droid.CustomRenderers.EntryCustomRenderer, App_Base_XF.Android", EntryCustomRenderer.class, __md_methods);
	}


	public EntryCustomRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == EntryCustomRenderer.class)
			mono.android.TypeManager.Activate ("App_Base_XF.Droid.CustomRenderers.EntryCustomRenderer, App_Base_XF.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public EntryCustomRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == EntryCustomRenderer.class)
			mono.android.TypeManager.Activate ("App_Base_XF.Droid.CustomRenderers.EntryCustomRenderer, App_Base_XF.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public EntryCustomRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == EntryCustomRenderer.class)
			mono.android.TypeManager.Activate ("App_Base_XF.Droid.CustomRenderers.EntryCustomRenderer, App_Base_XF.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
