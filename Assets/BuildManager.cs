using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public GameObject buildButton;
	public GameObject buildButtonText;

	public GameObject gameControl;
	public int copperIngotCount;
	public int ironIngotCount;

	public WeaponInfo currentWeaponInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void checkForBuildableItem() {
		buildButton.GetComponent<UnityEngine.UI.Button> ().interactable = false;
		currentWeaponInfo = null;

		//ContentType.contentItem lastContentItem = ContentType.contentItem.none;

		copperIngotCount = 0;
		 ironIngotCount = 0;

		foreach (tileDetail t in  gameObject.transform.GetComponentsInChildren<tileDetail>()) {
			if (t.tileContentType == ContentType.contentItem.copper_ingot) {
				copperIngotCount += 1;
			}

			if (t.tileContentType == ContentType.contentItem.iron_ingot) {
				ironIngotCount += 1;
			}
		}

		if (copperIngotCount >= 2) {
			//build something copper
			currentWeaponInfo = getItemforRecipe(ContentType.contentItem.copper_ingot, copperIngotCount);
			displayBuildableWeaponInfo ();
		} else 	if (ironIngotCount >= 2) {
			currentWeaponInfo = getItemforRecipe(ContentType.contentItem.iron_ingot, ironIngotCount);
			displayBuildableWeaponInfo ();
		}

	}

	void displayBuildableWeaponInfo() {
		buildButton.GetComponent<UnityEngine.UI.Button> ().interactable = true;

		buildButtonText.GetComponent<UnityEngine.UI.Text> ().text = "Build " + currentWeaponInfo.weaponType.ToString ();
	}

	WeaponInfo getItemforRecipe(ContentType.contentItem ingredient, int ingredientCount) {
		//2 metals = dagger
		//3 metals = sword
		//4 metals = greatsword

		gameControl = GameObject.Find ("GameControl");

		int damageMultiplier = 1;

		if (ingredient == ContentType.contentItem.copper_ingot || ingredient == ContentType.contentItem.iron_ingot) {
			if (ingredient == ContentType.contentItem.copper_ingot) {
				damageMultiplier = 1;
			}

			if (ingredient == ContentType.contentItem.iron_ingot) {
				damageMultiplier = 2;
			}
		
			WeaponInfo.weaponTypes newWeaponType = WeaponInfo.weaponTypes.none;
			switch (ingredientCount) {
			case 2:
				newWeaponType = WeaponInfo.weaponTypes.Dagger;
				break;
			case 3:
				newWeaponType = WeaponInfo.weaponTypes.LongSword;
				break;
			case 4:
				newWeaponType = WeaponInfo.weaponTypes.GreatSword;
				break;
			}

			WeaponTemplate template = gameControl.GetComponent<CraftingManager> ().getTemplateforType (newWeaponType);

			return new WeaponInfo (template, damageMultiplier);
		}
		return null;
		//2 berries = weak hp potion
		//3 berries = med hp potion
		//4 berries = strong hp potion

		//2 wood = short bow
		//3 wood = recurve box
		//4 wood = longbox
	}


}
