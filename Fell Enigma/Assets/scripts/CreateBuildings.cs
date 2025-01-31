﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuildings : MonoBehaviour
{
	

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}



	/**
	* Generates the buildings that will appear in the map
	* Have to assign everything manually
	* 
	* 
	* @author Jeffrey Goh
	* @version 1.0
	* @updated 12/7/2017
	*/
	public static void generateBuildings(string mapName)
	{
		Grid.instance.waitUpTime = 0.25f;
		if (mapName == "tutorial")
		{
			//Set next scene
			Grid.instance.nextScene = "Chapter1";

			// Link Taverns and spawn point
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[16][12].gridPosition, Grid.instance.map[16][11].gridPosition);

			//Set level of units that can be recruited
			Grid.instance.tavernLevel = 1;

			Grid.instance.gold = 500;
			Grid.instance.goldCap = 1000;

			Grid.instance.commander = 0;
			Grid.instance.ultCharge = 70;
			ActivateTextAtLine.instance.startScript(0, 10);
		}
		else if (mapName == "chapter1")
		{
			GameControl.instance.Load();

			//Set next scene
			Grid.instance.nextScene = "Battle Prep";
			
			// Link Taverns and spawn point
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[1][15].gridPosition, Grid.instance.map[2][15].gridPosition);
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[4][18].gridPosition, Grid.instance.map[4][17].gridPosition);
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[13][16].gridPosition, Grid.instance.map[13][15].gridPosition);

			// Precap villages
			Grid.instance.villageStatus[Grid.instance.map[1][18].gridPosition][0] = 0;
			Grid.instance.villageStatus[Grid.instance.map[1][17].gridPosition][0] = 0;
			Grid.instance.villageStatus[Grid.instance.map[2][18].gridPosition][0] = 0;
			Grid.instance.villageStatus[Grid.instance.map[2][17].gridPosition][0] = 0;

			//Set level of units that can be recruited
			Grid.instance.tavernLevel = 3;

			Grid.instance.gold = GameControl.instance.gold;
			Grid.instance.goldCap = 1500;

			Grid.instance.commander = 0;
			Grid.instance.ultCharge = 0;

			Grid.instance.objectiveSpecificTiles.Add(Grid.instance.map[14][0].gridPosition, "Escape");

			ActivateTextAtLine.instance.startScript(0, 16);
		}
		else if (mapName == "chapter2")
		{
			GameControl.instance.Load();

			//Set next scene


			// Link Taverns and spawn point
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[6][24].gridPosition, Grid.instance.map[6][23].gridPosition);
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[4][14].gridPosition, Grid.instance.map[4][13].gridPosition);
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[8][15].gridPosition, Grid.instance.map[7][15].gridPosition);
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[8][11].gridPosition, Grid.instance.map[8][10].gridPosition);
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[14][11].gridPosition, Grid.instance.map[14][10].gridPosition);
			Grid.instance.tavernAndSpawn.Add(Grid.instance.map[1][1].gridPosition, Grid.instance.map[2][1].gridPosition);

			// Precap villages
			Grid.instance.villageStatus[Grid.instance.map[10][11].gridPosition][0] = 0;
			Grid.instance.villageStatus[Grid.instance.map[10][10].gridPosition][0] = 0;
			Grid.instance.villageStatus[Grid.instance.map[11][11].gridPosition][0] = 0;
			Grid.instance.villageStatus[Grid.instance.map[11][10].gridPosition][0] = 0;

			//Set level of units that can be recruited
			Grid.instance.tavernLevel = 5;

			Grid.instance.gold = GameControl.instance.gold;
			Grid.instance.goldCap = 2000;

			Grid.instance.commander = GameControl.instance.ultID;
			Grid.instance.ultCharge = 0;

			ActivateTextAtLine.instance.startScript(0, 8);
		}
	}
}
