using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Views.InputMethods;
using Android.Content;
using System;
using Android.Views;

namespace CreactPager
{
	[Activity( MainLauncher = false)]
	public class CreateDrinkActivity : Activity, SeekBar.IOnSeekBarChangeListener
	{

		SeekBar _seekBar;
		TextView _textView;
		ColorAdapter adapterColor;
		ImageInaddPageAdapter adapter;
		Button saveButton;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			Gallery gallery = (Gallery)FindViewById<Gallery>(Resource.Id.gallery);
			Gallery galleryColor = (Gallery)FindViewById<Gallery>(Resource.Id.galleryForColor);
			Spinner spinner = FindViewById<Spinner>(Resource.Id.spinneSize);
			_seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
			var editText = FindViewById<EditText>(Resource.Id.plainForDrinkName);
			_textView = FindViewById<TextView>(Resource.Id.textBoxValueSpirt);
			saveButton = FindViewById<Button>(Resource.Id.saveButton);

			// create DB path
			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_drinks.db");
			int restProperty = Intent.GetIntExtra("rest_property", 1);
			string pathToUserDb = Intent.GetStringExtra("nameDatabase");

			adapterColor= new ColorAdapter(this);
			galleryColor.Adapter = adapterColor;

			adapter = new ImageInaddPageAdapter(this,"#f01313");
			gallery.Adapter = adapter;
			gallery.SetSelection(2);
            galleryColor.SetSelection(3);

			_seekBar.SetOnSeekBarChangeListener(this);

			var adapterSpiner = ArrayAdapter.CreateFromResource(
					this, Resource.Array.namess_array, Android.Resource.Layout.SimpleSpinnerItem);

		
			editText.KeyPress+=(object sender, View.KeyEventArgs e)=> 
			{
				e.Handled = false;
				if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
				{
					InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
					imm.HideSoftInputFromWindow(editText.WindowToken, 0);
					e.Handled = true;
				}
					
			};;
			adapterSpiner.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapterSpiner;


			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

			galleryColor.ItemClick += delegate (object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
			{
				int k = gallery.SelectedItemPosition;
				var pos=galleryColor.SelectedItemPosition;
				var colorString=adapterColor.CurrentColor(pos);
				adapter = new ImageInaddPageAdapter(this, colorString);
				gallery.Adapter = adapter;
				gallery.SetSelection(k);
			};
			saveButton.Click+=delegate 
			{
				
				Person person = new Person();
				person.isFavoutite = false;
				person.SizeOfImage = spinner.SelectedItem.ToString();
				person.NameOfDrink = editText.Text;
				person.ColorOfImage=adapter.color;
				person.ID = MyDataBase.GetId(pathToDatabase);
				person.DrinkImageId=(int)adapter.GetItemId(gallery.SelectedItemPosition);
				person.DegreeOfDrink = _seekBar.Progress;
				if (person.NameOfDrink != "" && MyDataBase.addData(person,pathToDatabase))
				{
					person.DrinkImageId = (int)adapter.GetItemId(gallery.SelectedItemPosition);

					Intent intent = new Intent(this, typeof(MainActivity));
					intent.PutExtra("rest_property", restProperty);
					intent.PutExtra("nameDatabase", pathToUserDb);
					StartActivity(intent);
				}
				else
				{
					//Intent intent = new Intent(this, typeof(CreateDrinkActivity));
					//StartActivity(intent);
				}
			};

		}



		private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			//Spinner spinner = (Spinner)sender;
			//spinner.SelectedItem.ToString();
			////string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
			//Toast.MakeText(this, spinner.SelectedItem.ToString(), ToastLength.Long).Show();
		}

		public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
		{
			if (fromUser)
			{
				if (seekBar.Progress > 96) seekBar.Progress = 96;
				_textView.Text= seekBar.Progress.ToString();

			}
		}

		public void OnStartTrackingTouch(SeekBar seekBar)
		{
			
		}

		public void OnStopTrackingTouch(SeekBar seekBar)
		{

		}



	}
}


