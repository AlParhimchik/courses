using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.AppCompat;
using System;
using Android.Widget;

using Android.Content;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace CreactPager
{
	[Activity(Label = "empty", MainLauncher = false)]
	public class MainActivity :FragmentActivity
	{
		ViewPager _viewpager;
		MyViewPagerAdapter myadapter;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			
			base.OnCreate(savedInstanceState);
			Window.RequestFeature(WindowFeatures.ActionBar);
			SetContentView(Resource.Layout.GridFavouritePager);
			int restProperty = Intent.GetIntExtra("rest_property",1);
			string pathToUserDb=Intent.GetStringExtra("nameDatabase");
			double degreeOfAlcohol = MyDataBase.DegreeOfDrunk(pathToUserDb);
			var txt1 = FindViewById<TextView>(Resource.Id.textViewDrunkProcent);
			int colorMaker = Convert.ToInt32(degreeOfAlcohol * 100 / (restProperty + 0.3));
			string strColorMaker="";
			txt1.Text = colorMaker.ToString() + "%";
			if (colorMaker ==0) strColorMaker = "#f5f2f2";
			if (colorMaker <= 20 && colorMaker>0) strColorMaker = "#d19d9d";
			if (colorMaker > 20 && colorMaker<=40) strColorMaker = "#c28d8d";
			if (colorMaker > 40 && colorMaker <= 60) strColorMaker = "#d47979";
			if (colorMaker > 60 && colorMaker <= 80) strColorMaker = "#d14343";
			if (colorMaker > 80 && colorMaker <= 100) strColorMaker = "#d10000";
			RelativeLayout rl = FindViewById<RelativeLayout>(Resource.Id.pagerLayout);
			rl.SetBackgroundColor(Android.Graphics.Color.ParseColor(strColorMaker));																																																																																																																																																																																																																																																				

			if (ActionBar != null)

			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			_viewpager = FindViewById<ViewPager>(Resource.Id.myViewPager);
			myadapter = new MyViewPagerAdapter(SupportFragmentManager, restProperty, pathToUserDb, this);	
			_viewpager.Adapter = myadapter;
			var tab1 = ActionBar.NewTab();
			tab1.SetCustomView(Resource.Layout.text2layout);

			tab1.TabSelected += (sender, args) =>
			{
				_viewpager.SetCurrentItem(((Android.App.ActionBar.Tab)sender).Position, true);
			};
			ActionBar.AddTab(tab1);

			var tab2 = ActionBar.NewTab();
			tab2.SetCustomView(Resource.Layout.text1layout);
			//tab.SetIcon(Resource.Drawable.tab2_icon);

			tab2.TabSelected += (sender, args) =>
			{
				_viewpager.SetCurrentItem(((Android.App.ActionBar.Tab)sender).Position,true);
			};
			ActionBar.AddTab(tab2);

			var tab3 = ActionBar.NewTab();
			tab3.SetCustomView(Resource.Layout.fortab);
			tab3.TabSelected += (sender, args) =>
			{
				var intent = new Intent(this,typeof(CreateDrinkActivity));
				intent.PutExtra("rest_property", restProperty);
				intent.PutExtra("nameDatabase", pathToUserDb);
				StartActivity(intent);
			};
			ActionBar.AddTab(tab3);
			_viewpager.PageSelected += (sender, args) =>
			 {

				 switch (args.Position)
				 {
					 case 0: tab1.Select(); break;
					 case 1: tab2.Select(); break;
				 }
			 };        

		}

	}




}

