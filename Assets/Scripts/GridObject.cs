﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Base class for all objects that can be instantiated within the Grid.
public class GridObject : MonoBehaviour {

	public bool lClick, rClick; //If the left and right click menus
	public GridTile ownerTile; //The tile that the object is located in
	public Canvas lClickCanvas, rClickCanvas; //what shows up when you left/right click

	// Use this for initialization
	public void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
		lClickCanvas.enabled = lClick;
		rClickCanvas.enabled = rClick;

		lClickCanvas.transform.position = rClickCanvas.transform.position = ownerTile.transform.position;
		
		if(ownerTile.MouseOver()) {
			if(Input.GetMouseButtonDown(0)) lClick = !lClick;
			else if(Input.GetMouseButtonDown(1)) rClick = !rClick;
		}
		if(!ownerTile.theGrid.GetGridTile(ownerTile.owner).Equals(ownerTile) && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
			lClick = rClick = false;
	}

	///Left Click Action
	public void ClickAction () {
		lClick = !lClick;
	}

	///Right Click Action
	public void RightClickAction () {
		rClick = !rClick;
	}
}
