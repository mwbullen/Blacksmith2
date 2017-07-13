using System;
using System.Collections.Generic;


namespace AssemblyCSharp
{
	[Serializable]
	public class ContentsManagerInfo
	{
		public string guid;

		public List<ContentType.contentItem> contents;

		public ContentsManagerInfo ()
		{
			guid = System.Guid.NewGuid ().ToString ();
		}
	}
}

