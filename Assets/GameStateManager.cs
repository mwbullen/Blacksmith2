using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameStateManager : MonoBehaviour {

	public GameStateInfo currentGameStateInfo;
	public GameObject workBenchPrefab;
	public GameObject heroPrefab;

	public GameObject WorkBenchArea;
	public GameObject Inventory;
	public GameObject HeroArea;

	// Use this for initialization
	void Start () {
		//load saved game
		//if saved null, create new GameStateInfo

		currentGameStateInfo = loadSavedGame ();

		if (currentGameStateInfo == null) {
			currentGameStateInfo = new GameStateInfo ();
		}

		loadWorkBenches ();
		loadInventory ();
		loadHeroes ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void newGame() {
		deleteSavedGame();
		currentGameStateInfo = new GameStateInfo ();

		addEmptyWorkBench ();
		createDefaultInventory ();
		createRandomHeroes ();

		saveContentInfo();
		reloadScene();


	}

	void createRandomHeroes() {
		for (int i = 0; i < 3; i++) {
			HeroInfo newHero = new HeroInfo ();
			currentGameStateInfo.heroes.Add (newHero);
		}
	}

	void createDefaultInventory() {
		currentGameStateInfo.inventoryContents = new ContentsManagerInfo ();
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.copper_ingot);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.iron_ingot);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.iron_ingot);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.iron_ingot);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.copper_ingot);

		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.none);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.none);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.none);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.none);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.none);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.none);
		currentGameStateInfo.inventoryContents.contents.Add (ContentType.contentItem.none);

	}

	void addEmptyWorkBench() {
		WorkbenchInfo newBenchInfo = new WorkbenchInfo ();

		newBenchInfo.contents = new List<ContentType.contentItem>();
		newBenchInfo.contents.Add(ContentType.contentItem.none);
		newBenchInfo.contents.Add(ContentType.contentItem.none);
		newBenchInfo.contents.Add(ContentType.contentItem.none);

		currentGameStateInfo.workBenches.Add(newBenchInfo);

	}

	void reloadScene() {
		Debug.Log ("reloading");
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (0);
	}

	public void saveGame() {
		//refresh gamecontentinfo
		refreshGameContentInfo();
		saveContentInfo();
	}

	void refreshGameContentInfo() {
		//GameStateInfo newGameStateInfo = new GameStateInfo ();

		currentGameStateInfo.workBenches.Clear ();

		foreach (GameObject workBench in GameObject.FindGameObjectsWithTag("WorkBench")) {
			WorkbenchInfo tmpWBInfo = (WorkbenchInfo) workBench.GetComponent<WorkBenchContentsManager>().getCurrentContents ();
			workBench.GetComponent<BuildManager>().checkForBuildableItem ();
			currentGameStateInfo.workBenches.Add (tmpWBInfo);
		}

		currentGameStateInfo.inventoryContents = Inventory.GetComponent<ContentsManager> ().getCurrentContents ();
	}

	void saveContentInfo() {
		//serialize gamestateinfo

		BinaryFormatter bf = new BinaryFormatter ();

		FileStream fs = File.Create (Application.persistentDataPath + "/" + "savegame.gam");

		bf.Serialize (fs, currentGameStateInfo);

		fs.Flush();
		fs.Close();

	}

	void deleteSavedGame() {
		File.Delete (Application.persistentDataPath + "/" + "savegame.gam");
	}

	GameStateInfo loadSavedGame() {
		GameStateInfo savedGameState = null;

		if (File.Exists (Application.persistentDataPath + "/" + "savegame.gam")) {
			BinaryFormatter bf = new BinaryFormatter ();

			FileStream fs = File.Open (Application.persistentDataPath + "/" + "savegame.gam", FileMode.Open);

			savedGameState = (GameStateInfo)bf.Deserialize (fs);

			fs.Close ();
		}

		return savedGameState;
	}

	void loadWorkBenches() {
		foreach (WorkbenchInfo workInfo in currentGameStateInfo.workBenches) {
			GameObject newWorkBench = GameObject.Instantiate (workBenchPrefab);

			newWorkBench.GetComponent<WorkBenchContentsManager> ().loadContents (workInfo);

			newWorkBench.transform.SetParent (WorkBenchArea.transform,false);
			newWorkBench.transform.localPosition = new Vector3 (0, 0,0);
		}
	}

	void loadInventory() {
		Inventory.GetComponent<ContentsManager> ().loadContents (currentGameStateInfo.inventoryContents);
	}

	void loadHeroes() {
		int y = 0;
		foreach (HeroInfo heroInfo in currentGameStateInfo.heroes) {
			GameObject newHero = GameObject.Instantiate (heroPrefab);
			newHero.GetComponent<HeroStatus> ().heroInfo = heroInfo;

			newHero.transform.SetParent (HeroArea.transform);
			newHero.transform.localPosition = new Vector3 (0, y, 0);

			newHero.GetComponent<HeroStatus> ().refreshDisplay ();

			y += 1;
		}
	}
}
