using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using CreactPager;
using Java.Lang;

namespace CreactPager
{

	public class MyAdapter : BaseAdapter<Person>
	{
		Person[] items;
		Activity context;
		string pathDb;
		ListView listView;
		FragmentActivity activity;
		string pathToUserDb;
		int restProperty;
		public MyAdapter(Activity context, Person[] items,string pathDataBase,ListView listView,FragmentActivity activity,string pathToUserDb,int restProperty) : base()
		{
			this.context = context;
			this.items = items;
			this.pathDb = pathDataBase;
			this.listView = listView;
			this.activity = activity;
			this.pathToUserDb = pathToUserDb;
			this.restProperty = restProperty;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override Person this[int position]
		{
			get { return items[position]; }

		}
		public override int Count
		{
			get { return items.Length; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{

			var item = items[position];
			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.listlayout, null);


			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.NameOfDrink;
			var imgDelete = view.FindViewById<ImageView>(Resource.Id.imagebut);
			var imgStar = view.FindViewById<ImageView>(Resource.Id.imageButton1);
			var dringImg = view.FindViewById<ImageView>(Resource.Id.DrinkImage);
			imgDelete.SetImageResource(Resource.Drawable.delete);
			imgStar.SetImageResource(Resource.Drawable.star);
			dringImg.SetImageResource(item.DrinkImageId);
			dringImg.SetColorFilter(Color.ParseColor(item.ColorOfImage));
			switch (item.SizeOfImage)
			{
				case "Small":dringImg.SetMaxHeight(130); break;
				case "Medium":dringImg.SetMaxHeight(140); break;
				case "Large":dringImg.SetMaxHeight(150); break;
				case "Very Small": dringImg.SetMaxHeight(110);break;
			}

			if (!item.isFavoutite)
				imgStar.ImageAlpha=30;
			else imgStar.ImageAlpha=255;
			imgDelete.Click+=(sender,e)=> 
			{
				bool result=MyDataBase.deleteItem(item, pathDb);
				if (result)
				{
					items = MyDataBase.GetNames(pathDb);
					listView.InvalidateViews();
				}
			};
			imgStar.Click+=delegate
			{
				if (item.isFavoutite)
				{
					imgStar.ImageAlpha = 30;
					item.isFavoutite = false;
				}
				else

				{
					imgStar.ImageAlpha = 255;
					item.isFavoutite = true;
				}
				bool result=MyDataBase.updateDate(item,pathDb);
				
			};
			view.LongClickable = true;
			view.Click += delegate
			{
				double oldDegree = MyDataBase.DegreeOfDrunk(pathToUserDb);
				if (oldDegree < restProperty + 0.3)
				{
					double degreeOfAlcohol = Calculator.CalculateDereeOfDrunk(pathToUserDb, item.SizeOfImage, item.DegreeOfDrink);
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
			return view;
		}
		public Person GetItemCur(int position)
		{
			return items[position];
		}
	}


}
