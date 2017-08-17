using System;

namespace AssemblyCSharp
{
	[Serializable]
	public class WeaponInfo
	{
		public  enum weaponTypes {none, Dagger, LongSword, GreatSword};

		public weaponTypes weaponType;

		public int minDamage;
		public int maxDamage;

		public WeaponInfo (WeaponTemplate template, int damageMultiplier)
		{
			minDamage = template.MinDamage * damageMultiplier;
			maxDamage = template.MaxDamage * damageMultiplier;
		}
	}
}

