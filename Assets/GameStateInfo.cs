using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class GameStateInfo
	{		
		public List<WorkbenchInfo> workBenches = new List<WorkbenchInfo>();

		public GameStateInfo ()
		{
			//new game
			workBenches.Add(new WorkbenchInfo());

		}

	}
}

