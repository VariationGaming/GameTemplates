﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public PlayerControl thePlayer;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;


	void Start () {
		thePlayer = FindObjectOfType<PlayerControl> ();
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y,transform.position.z);


		lastPlayerPosition = thePlayer.transform.position;
	}
}
