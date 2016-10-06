using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android.Views;
using Android.Support.V7.App;
using System;
using Android.Widget;
//using Android;

namespace CreactPager
{
	[Activity(Label = "empty", MainLauncher = true)]
	public class MainActivity_pager :FragmentActivity
	{
		//ActionBar actionbar;
		ViewPager _viewpager;
		MyViewPagerAdapter myadapter;
		public  Activity GetActivity()
		{
			return this;
		}
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			if ( ActionBar!= null)
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			SetContentView(Resource.Layout.GridFavouritePager);
			_viewpager = FindViewById<ViewPager>(Resource.Id.myViewPager);
			myadapter = new MyViewPagerAdapter(SupportFragmentManager);
			_viewpager.Adapter = myadapter;
		
			var tab1 = ActionBar.NewTab();
			tab1.SetText("tab1");

			tab1.TabSelected += (sender, args) =>
			{
				_viewpager.SetCurrentItem(((Android.App.ActionBar.Tab)sender).Position, true);
			};
			ActionBar.AddTab(tab1);


			var tab2 = ActionBar.NewTab();
			tab2.SetText("tab2");
			//tab.SetIcon(Resource.Drawable.tab2_icon);

			tab2.TabSelected += (sender, args) =>
			{
				_viewpager.SetCurrentItem(((Android.App.ActionBar.Tab)sender).Position,true);
				//SetContentView(Resource.Layout.fragment_red);
			};
			ActionBar.AddTab(tab2);


			_viewpager.PageSelected+= (sender, args) =>
			{
				switch (args.Position)
				{
					case 0:tab1.Select(); break;
					case 1:tab2.Select();break;
				}
			};
	        

		}

	}




}

