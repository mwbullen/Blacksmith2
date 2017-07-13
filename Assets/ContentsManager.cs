using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ContentsManager : MonoBehaviour {
	public ContentsManagerInfo contentInfo;

	// Use this for initialization
	void Start () {
		contentInfo = loadContentInfo ();

		saveContentInfo ();
	}

	void displayContents() {
		int i = 0;
		foreach (ContentType.contentItem contentItem in contentInfo.contents) {
			GameObject childContainer = gameObject.transform.GetChild (i).gameObject;
		
			if (childContainer != null) {
			}
					
			i +=1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void saveContentInfo() {
		//serialize contentinfo

		BinaryFormatter bf = new BinaryFormatter ();

		FileStream fs = File.Create (Application.persistentDataPath + "/" + contentInfo.guid + ".gam");

		bf.Serialize (fs, contentInfo);

		fs.Flush();
		fs.Close();
	}

	ContentsManagerInfo loadContentInfo() {
		//load contentinfo from disk or return new

		if (File.Exists (Application.persistentDataPath + "/" + contentInfo.guid + ".gam")) {
			BinaryFormatter bf = new BinaryFormatter ();

			FileStream fs = File.Open (Application.persistentDataPath + "/" + contentInfo.guid + ".gam", FileMode.Open);

			ContentsManagerInfo savedContent = (ContentsManagerInfo)bf.Deserialize (fs);

			fs.Close ();

			return savedContent;
		}

		return new ContentsManagerInfo ();
	}
}
