﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_EmitHazards : MonoBehaviour {

	//private GameManager_Master gmMaster;
	[SerializeField]
	private GameObject[] hazards;
	private FixedRandom fr;
	private float nextEm;
	public float minRate;
	public float maxRate;
	public float fixedZPosition;
	public float burstRate = 0.2f;

	void OnEnable() {
		
	}
	
	void OnDisable() {
		
	}
	
	void Start () {
		fr = new FixedRandom(-7, 7, 1);
	}
	
	void FixedUpdate () {
		if (Time.time > nextEm) {
			nextEm = Time.time + Random.Range (minRate, maxRate);
			if (Random.Range (0.0f, 1) < burstRate)
				HazardBurst ();
			else
				HazardEmission ();
		}
	}

	private void HazardEmission() {
		//TODO - Random hazard emission...
		float xPos = fr.GetFloatRange();
		Instantiate (hazards [Random.Range (0, hazards.Length)], new Vector3(xPos, 0.0f, fixedZPosition), Quaternion.identity);
	}

	private void HazardBurst() {
		float xPos;
		for (int i = 0; i < (int)Random.Range (2, 4); i++) {
			xPos = fr.GetFloatRange();
			Instantiate (hazards [Random.Range (0, hazards.Length)], new Vector3(xPos, 0.0f, fixedZPosition), Quaternion.identity);
		}
	}
	
	private void InitializeReferences() {
		//gmMaster = GetComponent<GameManager_Master> ();
	}
}