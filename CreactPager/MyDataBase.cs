using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using SQLite;

namespace CreactPager
{
	
	public class MyDataBase
	{
		public static bool deleteItem(Person person,string path)
		{
			try
			{
				var db = new SQLiteConnection(path);
				db.Delete<Person>(person.ID);
				return true;
			}
			catch (SQLiteException ex)
			{
				return true;
			}
		}
		public static int GetId(string path)
		{
			var db = new SQLiteConnection(path);
			Person last=db.Table<Person>().LastOrDefault();
			if (last ==null) return 0;
			else return last.ID+1;
		}
		public static Person[] GetFavouriteDrinks(string path)
		{
			var db = new SQLiteConnection(path);
			return db.Table<Person>().Where(obj => obj.isFavoutite == true).ToArray();
		}
		public static string createDatabase(string path)
		{
			try
			{
				var connection = new SQLiteConnection(path);
				connection.CreateTable<Person>();
				return "Database created";
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}
		}
		public static Person[] GetNames(string path)
		{
			var db = new SQLiteConnection(path);
			var tabs = db.Table<Person>();
			return tabs.ToArray();

		}
		public static bool updateDate(Person person, string path)
		{
			try
			{
				var db = new SQLiteConnection(path);
				db.Update(person);
				return true;
			}
			catch (SQLiteException ex)
			{
				return false;
			}
		}
		public static bool addData(Person data , string path)
		{
			try
			{
				var db = new SQLiteConnection(path);
				if (db.Insert(data) != 0)
					db.Update(data);
				return true;
			}
			catch (SQLiteException ex)
			{
				return false;
			}
		}

		internal static int Count(string path)
		{
			var db = new SQLiteConnection(path);
			return db.Table<Person>().Count();

		}
		public static void CreateUserDataBase(string path)
		{
			var connection = new SQLiteConnection(path);
			connection.CreateTable<User>();
		}
		public static int GetUserWeight(string path)
		{
			var db = new SQLiteConnection(path);
			return db.Table<User>().LastOrDefault().Weight;

		}
		public static void Update(User data,string path)
		{
			var db = new SQLiteConnection(path);
			db.DeleteAll<User>();
			db.Insert(data);
			var tables = db.Table<User>().ToArray();

		}
		public static double DegreeOfDrunk(string path)
		{
			var db = new SQLiteConnection(path);
			return db.Table<User>().FirstOrDefault().DegreeOfDrunk;

		}
		public static int DegreeOfMet(string path)
		{
			var db = new SQLiteConnection(path);
			return db.Table<User>().FirstOrDefault().MetDegree;

		}
		public static DateTime LastDatetime(string path)
		{
			var db = new SQLiteConnection(path);
			return db.Table<User>().FirstOrDefault().LastTime;

		}
		public static void SetDegreeOfAlcohol(string path, double degree)
		{
			var db = new SQLiteConnection(path);
			User user=db.Table<User>().FirstOrDefault();
			user.DegreeOfDrunk = degree;
			db.DeleteAll<User>();
			db.Insert(user);
		}

	}
	
}