using System;
using System.Collections.Generic;


namespace AssemblyCSharp
{
	[Serializable]
	public class ContentsManagerInfo
	{
		
		public List<ContentType.contentItem> contents = new List<ContentType.contentItem>();

		public ContentsManagerInfo ()
		{
			//contents.Add (ContentType.contentItem.copper_ingot);
		}
	}
}

