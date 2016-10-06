package md5cce6193c8fe45ac8edc2b79204eee4c7;


public class FragmentFavourite
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CreactPager.FragmentFavourite, CreactPager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FragmentFavourite.class, __md_methods);
	}


	public FragmentFavourite () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FragmentFavourite.class)
			mono.android.TypeManager.Activate ("CreactPager.FragmentFavourite, CreactPager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public FragmentFavourite (int p0, java.lang.String p1, android.support.v4.app.FragmentActivity p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == FragmentFavourite.class)
			mono.android.TypeManager.Activate ("CreactPager.FragmentFavourite, CreactPager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:Android.Support.V4.App.FragmentActivity, Xamarin.Android.Support.v4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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
