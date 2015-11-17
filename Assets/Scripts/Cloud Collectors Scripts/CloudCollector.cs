﻿using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	void onTriggerEnter2D(Collider2D target) {
		if(target.tag == "Cloud" || target.tag == "Deadly"){
			target.gameObject.SetActive(false);
		}
	}
}
