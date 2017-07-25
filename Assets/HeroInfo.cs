using System;
//using UnityEngine;

namespace AssemblyCSharp
{
	[Serializable]
	public class HeroInfo
	{		
		static string[] possibleNames = { "Archer", "Cyril", "Lana", "Pam", "Mallory", "Kreiger", "Cheryl" , "Barry"}; 
		public enum Activity{Shop, Exploring, Fighting, Returning	};

		//desired Mission
		//Equipped item

		static System.Random r = new Random ();

		public string heroName;
		public int maxHealth;
		public int currentHealth;


		public Activity currentActivity;

		public HeroInfo ()
		{
			heroName= possibleNames[r.Next(0, possibleNames.Length)];							
		}
	}
}

