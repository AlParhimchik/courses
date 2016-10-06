using System;
using System.Drawing;
using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace CreactPager
{
	class GridViewAdapter : BaseAdapter
	{
		Context ctx;
		Person[] persons;
		string pathtoDb;
		int restProperty;
		string pathToUserDb;
		FragmentActivity activity;
		private static LayoutInflater inflater = null;
		public GridViewAdapter(Context ctx, string pathToDb, Person[] persons,int restProperty,string pathToUserDb,FragmentActivity activity)
		{
			this.ctx = ctx;
			this.persons = persons;
			this.pathtoDb = pathToDb;
			this.pathToUserDb = pathToUserDb;
			this.restProperty = restProperty;
			inflater = (LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
			this.activity = activity;

		}

		public override int Count
		{
			get
			{
				return persons.Length;
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return position;
		}


		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			if (persons.Length == 0) return null;
			persons = MyDataBase.GetFavouriteDrinks(pathtoDb);
			var holder = new Holder();
			View rowview;
			rowview = inflater.Inflate(Resource.Layout.CustomGrid, null);
			holder.img = rowview.FindViewById<ImageView>(Resource.Id.imageView1);
			holder.txt = rowview.FindViewById<TextView>(Resource.Id.textView1);
			holder.img.SetImageResource(persons[position].DrinkImageId);
			holder.img.SetColorFilter(Android.Graphics.Color.ParseColor(persons[position].ColorOfImage));
			holder.txt.Text = persons[position].NameOfDrink;
			rowview.Clickable = true;
			rowview.Click += (sender, e) =>
			  {
				  double oldDegree = MyDataBase.DegreeOfDrunk(pathToUserDb);
				  if (oldDegree < restProperty + 0.3)
				  {
					  double degreeOfAlcohol = Calculator.CalculateDereeOfDrunk(pathToUserDb, persons[position].SizeOfImage, persons[position].DegreeOfDrink);
					  if (degreeOfAlcohol < restProperty + 0.3)
					  {
						  MyDataBase.SetDegreeOfAlcohol(pathToUserDb, degreeOfAlcohol);
						  var intent = new Intent(activity, typeof(MainActivity));
						  intent.PutExtra("rest_property", restProperty);
						  intent.PutExtra("nameDatabase", pathToUserDb);
						  activity.StartActivity(intent);
					}
				}
				};
			return rowview;

		}

	}
	public class Holder
	{
		public ImageView img;
	    public TextView txt;
	}
}