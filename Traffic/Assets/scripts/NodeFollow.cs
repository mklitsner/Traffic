﻿using UnityEngine;
using System.Collections;

public class NodeFollow : MonoBehaviour {
	public Transform target;

	// Update is called once per frame
	void Update () {
		transform.position = target.position;
	}
}
