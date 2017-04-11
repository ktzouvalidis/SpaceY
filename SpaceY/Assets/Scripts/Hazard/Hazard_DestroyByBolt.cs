﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_DestroyByBolt : MonoBehaviour {
	private Hazard_Master hazardMaster;
	
	void Start () {
		InitializeReferences ();
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.layer == 12) {
			try {
				hazardMaster.CallEventDestroyed ();
			} catch (System.Exception e) {
				Debug.Log (this.name + " - " + col.name);
				Debug.Break ();
			}
		}
	}
	
	private void InitializeReferences() {
		hazardMaster = GetComponent<Hazard_Master> ();
	}
}
