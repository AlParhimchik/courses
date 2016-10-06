using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CreactPager
{
[Activity(Label = "Home",MainLauncher=true)]
	public class MainPageActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.newlayout1);

			View viewForRest1 = FindViewById<RelativeLayout>(Resource.Id.viewForRest1);
			View viewForRest2 = FindViewById<RelativeLayout>(Resource.Id.viewForRest2);
			View viewForRest3 = FindViewById<RelativeLayout>(Resource.Id.viewForRest3);
			View viewForRest4 = FindViewById<RelativeLayout>(Resource.Id.viewForRest4);
			ImageButton setingsButton = FindViewById<ImageButton>(Resource.Id.butsetings);
			viewForRest1.Clickable = viewForRest2.Clickable = viewForRest3.Clickable = viewForRest4.Clickable=true;

			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_drinks.db");
			var result = MyDataBase.createDatabase(pathToDatabase);

			var pathToUserDatabase = System.IO.Path.Combine(docsFolder, "db_user.db");
			MyDataBase.CreateUserDataBase(pathToUserDatabase);
			MyDataBase.SetDegreeOfAlcohol(pathToUserDatabase, 0);

			viewForRest1.Click += delegate
			  {
				  var intent = new Intent(this, typeof(MainActivity));
				intent.PutExtra("rest_property", 1);
				intent.PutExtra("nameDatabase", pathToUserDatabase);
				  StartActivity(intent);
			  };
			viewForRest2.Click+=delegate 
			{
				var intent = new Intent(this, typeof(MainActivity));
				intent.PutExtra("rest_property", 2);
				intent.PutExtra("nameDatabase", pathToUserDatabase);
				StartActivity(intent);
				
			};	
			viewForRest3.Click += delegate
			  {
				  var intent = new Intent(this, typeof(MainActivity));
				intent.PutExtra("rest_property", 3);
				intent.PutExtra("nameDatabase", pathToUserDatabase);
				  StartActivity(intent);
			  };
			viewForRest4.Click += delegate
			  {
				  var intent = new Intent(this, typeof(MainActivity));
				intent.PutExtra("rest_property", 4);
				intent.PutExtra("nameDatabase", pathToUserDatabase);
				  StartActivity(intent);
			  };
			setingsButton.Click+=delegate 
			{
				var intent = new Intent(this, typeof(SettingsActivity));
				intent.PutExtra("nameDatabase",pathToUserDatabase);
				StartActivity(intent);
			};
		}
	}
}

