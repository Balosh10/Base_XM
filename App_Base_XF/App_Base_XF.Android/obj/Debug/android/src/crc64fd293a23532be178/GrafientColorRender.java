package crc64fd293a23532be178;


public class GrafientColorRender
	extends crc643f46942d9dd1fff9.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dispatchDraw:(Landroid/graphics/Canvas;)V:GetDispatchDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("App_Base_XF.Droid.CustomRender.GrafientColorRender, App_Base_XF.Android", GrafientColorRender.class, __md_methods);
	}


	public GrafientColorRender (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == GrafientColorRender.class)
			mono.android.TypeManager.Activate ("App_Base_XF.Droid.CustomRender.GrafientColorRender, App_Base_XF.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public GrafientColorRender (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == GrafientColorRender.class)
			mono.android.TypeManager.Activate ("App_Base_XF.Droid.CustomRender.GrafientColorRender, App_Base_XF.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public GrafientColorRender (android.content.Context p0)
	{
		super (p0);
		if (getClass () == GrafientColorRender.class)
			mono.android.TypeManager.Activate ("App_Base_XF.Droid.CustomRender.GrafientColorRender, App_Base_XF.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void dispatchDraw (android.graphics.Canvas p0)
	{
		n_dispatchDraw (p0);
	}

	private native void n_dispatchDraw (android.graphics.Canvas p0);

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
