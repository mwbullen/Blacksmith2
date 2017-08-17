using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void checkForBuildableItem() {
		List<ContentType.contentItem> currentContents=	gameObject.GetComponent<WorkBenchContentsManager>().getCurrentContents ().contents;

		int matchedItemCount = 0;
		ContentType.contentItem lastContentItem = ContentType.contentItem.none;


		foreach (ContentType.contentItem item in currentContents) {
			if (lastContentItem == ContentType.contentItem.none) {
				lastContentItem = item;
				matchedItemCount += 1;
			} else if (item == lastContentItem) {
				matchedItemCount += 1;
			} else {
				matchedItemCount = 0;
			}
		}

		if (matchedItemCount == currentContents.Count) {
			//all items match
			WeaponInfo buildAbleWeapon = getItemforRecipe(currentContents[0], matchedItemCount);

			//display button to builditem
		}
	}

	WeaponInfo getItemforRecipe(ContentType.contentItem ingredient, int ingredientCount) {
		//2 metals = dagger
		//3 metals = sword
		//4 metals = greatsword

		GameObject gameControl = GameObject.Find ("GameControl");


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
