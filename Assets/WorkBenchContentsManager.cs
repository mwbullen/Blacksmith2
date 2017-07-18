﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class WorkBenchContentsManager : MonoBehaviour {
	public WorkbenchInfo contentInfo;
	public GameObject slotsParent;

	public GameObject gameControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadContents(WorkbenchInfo contents) {
		gameControl = GameObject.Find ("GameControl");
		contentInfo = contents;

		//int i = 0;
		foreach (ContentType.contentItem contentItem in contentInfo.contents) {
			//GameObject childContainer = gameObject.transform.GetChild (i).gameObject;

			GameObject newSlot = gameControl.GetComponent<TileManager> ().getPrefabforContentType (ContentType.contentItem.slot);
			newSlot.transform.SetParent (slotsParent.transform);

			if (contentItem != ContentType.contentItem.none) {
				GameObject newItem = gameControl.GetComponent<TileManager> ().getPrefabforContentType (contentItem);

				newItem.transform.SetParent (newSlot.transform);
				newItem.transform.position = new Vector3 (0, 0, 0);

			}

			//	i +=1;
		}
	}

	public ContentsManagerInfo getCurrentContents() {
		contentInfo.contents.Clear ();

		for (int i =0; i < slotsParent.transform.childCount; i++) {
			GameObject slot = slotsParent.transform.GetChild (i).gameObject;

			if (slot.transform.childCount > 0) {
				GameObject slotteditem = slot.transform.GetChild (0).gameObject;
				string slottedItemName = slotteditem.name;

				slottedItemName = slottedItemName.Replace ("(Clone)", "");

				Debug.Log (slottedItemName);
				ContentType.contentItem childContent = (ContentType.contentItem) System.Enum.Parse (typeof(ContentType.contentItem), slottedItemName);

				contentInfo.contents.Add (childContent);
			}

		}

		return contentInfo;
	}

}