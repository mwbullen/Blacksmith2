using System;
using AssemblyCSharp;

namespace AssemblyCSharp
{
	[Serializable]
	public class WeaponTemplate
	{
		public WeaponInfo.weaponTypes weaponType;

		public int MinDamage;
		public int MaxDamage;
		public WeaponTemplate ()
		{
		}
	}
}

