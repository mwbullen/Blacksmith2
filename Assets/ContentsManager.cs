using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class ContentsManager : MonoBehaviour {
	ContentsManagerInfo contentInfo;

	// Use this for initialization
	void Start () {
		contentInfo = loadContentInfo ();
	}

	void displayContents() {
		foreach (int i in contentInfo.contentHT.Keys) {
			GameObject child = gameObject.transform.GetChild (i).gameObject;
			if (i != null) {

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void saveContentInfo() {
		//serialize contentinfo
	}

	ContentsManagerInfo loadContentInfo() {
		//load contentinfo from disk or return new

		return null;
	}
}
