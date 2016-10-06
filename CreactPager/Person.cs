using SQLite;

namespace CreactPager
{
	public class Person
	{
		[PrimaryKey]
		public int ID { get; set; }

		public bool isFavoutite { get; set; }

		public int DrinkImageId { get; set; }

		public string SizeOfImage { get; set; }

		public string ColorOfImage { get; set; }

		public string NameOfDrink { get; set; }

		public int DegreeOfDrink { get; set; }

		}
}

