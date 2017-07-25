using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class GameStateInfo
	{		
		public List<WorkbenchInfo> workBenches = new List<WorkbenchInfo>();
		public ContentsManagerInfo inventoryContents = new ContentsManagerInfo();

		public List<HeroInfo> heroes = new List<HeroInfo>();

		public GameStateInfo ()
		{
			//new game
			//workBenches.Add(new WorkbenchInfo());

		}

	}
}

