using System;
//using UnityEngine;

namespace AssemblyCSharp
{
	[Serializable]
	public class HeroInfo
	{		
		static string[] possibleNames = { "Archer", "Cyril", "Lana", "Pam", "Mallory", "Kreiger" }; 

		static System.Random r = new Random ();

		public string heroName;
		public int maxHealth;
		public int currentHealth;

		public enum Activity	{none, atShop, Exploring, Fighting, Returning	};
		public Activity currentActivity = Activity.none;

		public HeroInfo ()
		{
			heroName= possibleNames[r.Next(0, possibleNames.Length)];							
		}
	}
}

