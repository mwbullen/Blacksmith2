using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;


public class ContentsManager : MonoBehaviour {
	public ContentsManagerInfo contentInfo;

	public GameObject gameControl;
	// Use this for initialization
	void Start () {
		//contentInfo = loadContentInfo ();

	//	saveContentInfo ();

		gameControl = GameObject.Find ("GameControl");

	}


	public void loadContents(ContentsManagerInfo contents) {
		contentInfo = contents;

		//int i = 0;
		foreach (ContentType.contentItem contentItem in contentInfo.contents) {
			//GameObject childContainer = gameObject.transform.GetChild (i).gameObject;

			GameObject newSlot = gameControl.GetComponent<TileManager> ().getPrefabforContentType (ContentType.contentItem.slot);
			newSlot.transform.SetParent (gameObject.transform);

			if (contentItem != ContentType.contentItem.none) {
				GameObject newItem = gameControl.GetComponent<TileManager> ().getPrefabforContentType (contentItem);

				newItem.transform.SetParent (newSlot.transform);
				newItem.transform.position = new Vector3 (0, 0, 0);

			}

		//	i +=1;
		}
	}


	
	// Update is called once per frame
	void Update () {
		
	}


}
