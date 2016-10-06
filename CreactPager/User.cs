using System;
using SQLite;
namespace CreactPager
{
	public class User
	{
		//[AutoIncrement]
		public int ID { get; set; }
		public int Weight { get; set; }
		public int MetDegree { get; set; }
		public double DegreeOfDrunk { get; set; }
		public DateTime LastTime { get; set; }
	}
}