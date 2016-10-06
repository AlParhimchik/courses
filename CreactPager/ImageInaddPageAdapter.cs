using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace CreactPager
{
	public class ImageInaddPageAdapter: BaseAdapter
	{
		Context context;
		public string color { get; set; }
		public ImageInaddPageAdapter(Context c, string color)
		{
			context = c;
			this.color = color;
		}
		public override int Count { get { return thumbIds.Length; } }

		public override Java.Lang.Object GetItem(int position)
		{
			return thumbIds[position];
		}

		public override long GetItemId(int position)
		{
			return thumbIds[position];
		}


		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			ImageView i = new ImageView(context);

			i.SetImageResource(thumbIds[position]);
			i.SetColorFilter(Color.ParseColor(color));
			i.SetAdjustViewBounds(true);
			i.SetScaleType(ImageView.ScaleType.FitCenter);

			return i;
		}


		int[] thumbIds =
		{
			Resource.Drawable.beerbig,
			Resource.Drawable.laber_beer,
			Resource.Drawable.beer_can,
	        Resource.Drawable.ice,
	        Resource.Drawable.bottle,
	        Resource.Drawable.laber_beer,
	        Resource.Drawable.tallglass,
			Resource.Drawable.wine,
			Resource.Drawable.winebott,
			Resource.Drawable.wineglass,
			Resource.Drawable.winebottle
		};

	}
}

