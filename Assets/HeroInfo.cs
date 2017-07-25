using System;
//using UnityEngine;

namespace AssemblyCSharp
{
	[Serializable]
	public class HeroInfo
	{		
		
		public string heroName;
		public int maxHealth;
		public int currentHealth;

		public enum Activity	{none, atShop, Exploring, Fighting, Returning	};
		public Activity currentActivity = Activity.none;

		public HeroInfo (string newHeroName)
		{
			//System.Random r = new Random ();
			heroName = newHeroName;
			//Name = possibleNames[r.Next(0, possibleNames.Length)];
							
		}
	}
}

