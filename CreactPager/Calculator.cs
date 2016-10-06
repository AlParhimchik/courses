namespace CreactPager
{
	class Calculator
	{
		public static double CalculateDereeOfDrunk(string pathToUserDb, string size, int gradus)
		{
			int weight = MyDataBase.GetUserWeight(pathToUserDb);
			int sizeInDouble = 0;
			switch (size)
			{
				case "Very Small": sizeInDouble = 330; break;
				case "Small": sizeInDouble = 500; break;
				case "Medium": sizeInDouble = 1000; break;
				case "Big": sizeInDouble = 1500; break;
			}
			double WeightSpirt = MyDataBase.DegreeOfDrunk(pathToUserDb);
			double degreeNew = (sizeInDouble * gradus * 0.8/100);
			double b =(degreeNew-degreeNew/10) / (weight * 0.7);
			return b+WeightSpirt;
		}

	}
}