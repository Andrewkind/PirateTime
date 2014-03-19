﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO; 

public class CameraScript : MonoBehaviour {
	Vector3 pos;
	public Vector3 pos_original = Camera.main.transform.position;
	public Vector3 ship_coords = GameObject.Find("Object_1").transform.position; //this is a reference to ships coordinates

	//level variables
	public int level = 1;
	public GameObject ship;
	public ShipScript shipScript; //need to access island script;

	public Transform islandPrefab; 
	public Transform enemyPrefab; 
	
	public List<Quests> questList;
	// Use this for initialization
	void Start () {
		Debug.Log("Game start!");
		//initialize the questlist
		questList = new List<Quests>();


		//need something like this, for now just drawg variable
		//islandPrefab = Resources.Load ("prefabs/island", Transform) as Transform;
		//enemyPrefab = Resources.Load ("prefabs/enemyPrefab") as Transform;

		//create event list
		generateQuests();
		//generate random level
		shipScript = GameObject.Find ("Ship").GetComponent<ShipScript> ();
		ship = GameObject.FindGameObjectWithTag ("ship"); //we need the island data
		generateLevel(level);

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Total number of quests = " + questList.Count);
		/*
		//MOUSE SCROLL BACK
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			
			if (Camera.main.transform.position.y <= 30)
			{
				
				pos = new Vector3(0,1,-1); //Translate 1 unit on x, and 1 unit on z
				Camera.main.transform.position += pos;
				
			}
		}
		
		// MOUSE SCROLL FORWARD
		if ( Input.GetAxis("Mouse ScrollWheel") > 0 ) // forward
		{
			if ( Camera.main.transform.position.y >= 4 )
			{
				pos = new Vector3(0,-1,1); //Translate 1 unit on x, and 1 unit on z
				Camera.main.transform.position += pos;
				
			}
		}
		
		
		//MIDDLE CLICK
		if (Input.GetMouseButtonDown(2)) {		
			Camera.main.transform.position = new Vector3(0,10,-2);
			pos = new Vector3(0,10,-2);
		}
		*/
	}
	
	void generateQuests() {
		//create a list of quests from the events file. 
		TextAsset file = (TextAsset)Resources.Load ("events", typeof(TextAsset));
		string questsText = file.text;
		int propertyCount = 0;
		string currentQuestProperty = "";

		Quests currentQuest = new Quests();

		int totalQuestCount=0;

		foreach( char c in questsText ) {
			if ( propertyCount < 75){ //if 70 properties added, then new event must be added to list

				if ( c == '~') {
					//write that property to the quest class

					//Debug.Log ("Current option is : " + currentQuestProperty);

					if (propertyCount == 1){ 
						currentQuest = new Quests();
						currentQuest.eventName = currentQuestProperty; }
					if (propertyCount == 2){ currentQuest.eventText = currentQuestProperty; }
					if (propertyCount == 3){ currentQuest.optionText1 = currentQuestProperty; }
					if (propertyCount == 4){ currentQuest.successText1 = currentQuestProperty; }
					if (propertyCount == 5){ currentQuest.failText1 = currentQuestProperty; }
					if (propertyCount == 6){ currentQuest.odds1 = System.Convert.ToInt32(currentQuestProperty) ; }
					if (propertyCount == 7){ currentQuest.oddsWit1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 8){ currentQuest.oddsMorale1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 9){ currentQuest.oddsNotoriety1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 10){ currentQuest.oddsCharisma1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 11){ currentQuest.oddsEvil1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 12){ currentQuest.oddsCrew1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 13){ currentQuest.oddsIntegrity1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 14){ currentQuest.oddsAle1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 15){ currentQuest.oddsGunpowder1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 16){ currentQuest.oddsCoins1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 17){ currentQuest.successWit1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 18){ currentQuest.successMorale1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 19){ currentQuest.successNotoriety1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 20){ currentQuest.successCharisma1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 21){ currentQuest.successEvil1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 22){ currentQuest.successCrew1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 23){ currentQuest.successIntegrity1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 24){ currentQuest.successAle1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 25){ currentQuest.successGunpowder1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 26){ currentQuest.successCoins1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 27){ currentQuest.failureWit1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 28){ currentQuest.failureMorale1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 29){ currentQuest.failureNotoriety1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 30){ currentQuest.failureCharisma1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 31){ currentQuest.failureEvil1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 32){ currentQuest.failureCrew1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 33){ currentQuest.failureIntegrity1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 34){ currentQuest.failureAle1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 35){ currentQuest.failureGunpowder1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 36){ currentQuest.failureCoins1 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 37){ 
						//currentQuestProperty == "true"
						if (currentQuestProperty == "True" ) {currentQuest.makeFight1 = true;}
						else currentQuest.makeFight1 = false;
					}
					if (propertyCount == 38){ currentQuest.fightDifficulty1 = currentQuestProperty; }

					//change below
					if (propertyCount == 39){ currentQuest.optionText2 = currentQuestProperty; }
					if (propertyCount == 40){ currentQuest.successText2 = currentQuestProperty; }
					if (propertyCount == 41){ currentQuest.failText2 = currentQuestProperty; }
					if (propertyCount == 42){ currentQuest.odds2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 43){ currentQuest.oddsWit2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 44){ currentQuest.oddsMorale2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 45){ currentQuest.oddsNotoriety2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 46){ currentQuest.oddsCharisma2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 47){ currentQuest.oddsEvil2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 48){ currentQuest.oddsCrew2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 49){ currentQuest.oddsIntegrity2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 50){ currentQuest.oddsAle2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 51){ currentQuest.oddsGunpowder2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 52){ currentQuest.oddsCoins2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 53){ currentQuest.successWit2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 54){ currentQuest.successMorale2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 55){ currentQuest.successNotoriety2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 56){ currentQuest.successCharisma2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 57){ currentQuest.successEvil2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 58){ currentQuest.successCrew2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 59){ currentQuest.successIntegrity2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 60){ currentQuest.successAle2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 61){ currentQuest.successGunpowder2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 62){ currentQuest.successCoins2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 63){ currentQuest.failureWit2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 64){ currentQuest.failureMorale2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 65){ currentQuest.failureNotoriety2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 66){ currentQuest.failureCharisma2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 67){ currentQuest.failureEvil2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 68){ currentQuest.failureCrew2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 69){ currentQuest.failureIntegrity2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 70){ currentQuest.failureAle2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 71){ currentQuest.failureGunpowder2 = System.Convert.ToInt32( currentQuestProperty) ; }
					if (propertyCount == 72){ currentQuest.failureCoins2 = System.Convert.ToInt32( currentQuestProperty) ; }

					if (propertyCount == 73){ 
						//currentQuestProperty == "true"
						if (currentQuestProperty == "True" ) {currentQuest.makeFight2 = true;}
						else currentQuest.makeFight2 = false; }
					if (propertyCount == 74){ currentQuest.fightDifficulty2 = currentQuestProperty; }

					currentQuestProperty=" "; //clear the property
					propertyCount++;

				} else { 
					//append character to string
					currentQuestProperty = currentQuestProperty + c;
					if (c == '^'){ //ignore text before semicolon
						currentQuestProperty = "";
					}	
				}	
			}
			if (propertyCount == 75){
					//currentQuest holds a fully populated quest, lets add it to the list!
					totalQuestCount++;
					Debug.Log ("ADDING A QUEST No. " + totalQuestCount + " with eventname " + currentQuest.eventName);
					questList.Add (currentQuest);
					propertyCount = 1;

			if (propertyCount == 0) propertyCount++;
			}
		}


	}

	void generateLevel(int levelNumber) {
		Debug.Log("Generate a quest!");

		//put ship in random location
		int shipStartX = Random.Range (-20, 20); 
		int shipStartZ = Random.Range (-20, 20);
		Vector3 position = new Vector3 (shipStartX, 0, shipStartZ);
		ship.transform.position = position;


		//generate 6-10 islands, put onto screen
		int islandCount = Random.Range (6, 10);
		int count = 0;
		while (count < islandCount){
			//create island, plob onto random spot
			//ad to a list of islands..?
			int islandStartX = Random.Range (-20, 20); 
			int islandStartZ = Random.Range (-20, 20);
			Vector3 islandposition = new Vector3 (islandStartX, 0, islandStartZ);
			GameObject.Instantiate(islandPrefab,islandposition,Quaternion.identity);
			count++;
		}
		int enemyCount = Random.Range (6, 10);
		count = 0;
		while (count < enemyCount){
			//create island, plob onto random spot
			//ad to a list of islands..?
			int enemyStartX = Random.Range (-20, 20); 
			int enemyStartZ = Random.Range (-20, 20);
			Vector3 enemyposition = new Vector3 (enemyStartX, 0, enemyStartZ);
			GameObject.Instantiate(enemyPrefab,enemyposition,Quaternion.identity);
			count++;
		}
	}
	
}