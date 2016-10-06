using System;
using Android.App;
using Android.Content;
using Android.Widget;

namespace CreactPager
{
	[Activity(Label = "Home1", MainLauncher= false)]
	public class SettingsActivity:Activity
	{
		protected override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.settingslayout);
			string pathToDb = Intent.GetStringExtra("nameDatabase") ?? "error";

			SeekBar seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
			EditText textWeight = FindViewById<EditText>(Resource.Id.textForWeight);
			Button saveButton = FindViewById<Button>(Resource.Id.saveButton);
			CheckBox box1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
			CheckBox box2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
			CheckBox box3 = FindViewById<CheckBox>(Resource.Id.checkBox3);
			textWeight.Text = 50.ToString();
			textWeight.Focusable = false;
			seekBar.ProgressChanged+=delegate 
			{
				int minValue = 50;
				if (seekBar.Progress > 100) seekBar.Progress = 100;
				textWeight.Text = (seekBar.Progress+minValue).ToString();
			};
			saveButton.Click+=delegate 
			{
				if (pathToDb != "error")
				{
					User user = new User();
					user.ID = 0;
					user.LastTime = DateTime.Now;
					user.Weight = seekBar.Progress + 50;
					user.DegreeOfDrunk=0;
					user.MetDegree=1;
					MyDataBase.Update(user, pathToDb);
					var intent = new Intent(this,typeof(MainPageActivity));
					StartActivity(intent);
				}
			};
		}
	}
}