﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
	public GameObject Menu;
	

	// Use this for initialization
	void Start()
	{
		Menu = GameObject.Find("Canvas");
	}

	// Update is called once per frame
	void Update()
	{
		if (Grid.instance.units[Grid.instance.currentPlayer] == this)
		{
			GetComponent<Renderer>().material.color = Color.yellow;
		}
		else
		{
			GetComponent<Renderer>().material.color = Color.grey;
		}

		if (currentHP <= 0)
		{
			GetComponent<Renderer>().material.color = Color.red;
			//gameObject.SetActive(false);
		}
	}


	/**
	* Move the current unit to the destination tile
	* Moves in an L shape to the destination, vertical first
	* Can navigate around obstacles, and will pick the shortest path
	* @param destTile The destination tile
	* @author Jeffrey Goh
	* @version 1.2
	* @updated 2/6/2017
	*/
	public override void turnUpdate()
	{
		if (positionQueue.Count > 0)
		{
			if (Vector3.Distance(positionQueue[0], transform.position) > 0.1f)
			{
				transform.position += ((Vector3)positionQueue[0] - transform.position).normalized * moveSpeed * Time.deltaTime;

				if (Vector3.Distance(positionQueue[0], transform.position) <= 0.1f)
				{
					transform.position = positionQueue[0];
					positionQueue.RemoveAt(0);
					if (positionQueue.Count == 0)
					{
						isMoving = false;
					}
				}
			}
		}


		//v1.1
		/*
		// Move to its destination
		if (Vector3.Distance(moveTo, transform.position) > 0.1f)
		{
			Debug.Log("End");
			transform.position += (moveTo - transform.position).normalized * moveSpeed * Time.deltaTime;

			// When the unit has reached its destination
			if (Vector3.Distance(moveTo, transform.position) <= 0.1f)
			{
				transform.position = moveTo;

				// Reset unit status after moving
				isMoving = false;
			}
		}
		*/
		base.turnUpdate();
	}


	private void OnMouseDown()
	{
		selected = !selected;

		if (Grid.instance.units[Grid.instance.currentPlayer].isFighting && Grid.instance.units[Grid.instance.currentPlayer] != this)
		{
			Grid.instance.attackWithCurrentUnit(this);
		}
		isMoving = false;
		isFighting = false;
	}


	public override void OnGUI()
	{
		if (selected && Grid.instance.units[Grid.instance.currentPlayer] == this)
		{
			Rect buttonRect = new Rect(0, Screen.height - 150, 150, 50);

			//Move
			if (GUI.Button(buttonRect, "Move"))
			{
				Grid.instance.removeTileHighlight();
				isFighting = false;

				if (isMoving)
				{
					isMoving = false;
					Grid.instance.removeTileHighlight();
				}
				else
				{
					isMoving = true;
					Grid.instance.highlightTilesAt(gridPosition, new Vector4(0f,1f,0f,0.5f), 1, mov, true);
				}
			}


			buttonRect = new Rect(0, Screen.height - 100, 150, 50);

			//Attack
			if (GUI.Button(buttonRect, "Attack"))
			{
				Grid.instance.removeTileHighlight();
				isMoving = false;

				if (isFighting)
				{
					isFighting = false;
					Grid.instance.removeTileHighlight();
				}
				else
				{
					isFighting = true;
					Grid.instance.highlightTilesAt(gridPosition, new Vector4(1f,0f,0f,0.5f), weaponMinRange, weaponMaxRange, false);
				}
			}


			buttonRect = new Rect(0, Screen.height - 50, 150, 50);

			//End Turn

			if (GUI.Button(buttonRect, "End"))
			{
				Grid.instance.removeTileHighlight();
				isMoving = false;
				isFighting = false;
				Grid.instance.nextTurn();
			}
			base.OnGUI();
		}
	}
}