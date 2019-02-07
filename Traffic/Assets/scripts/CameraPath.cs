using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraPath: MonoBehaviour {

	public Color linecolor;
	public bool showPath;

	private List<Transform> shots= new List<Transform>();

	void OnDrawGizmos(){
		Gizmos.color = linecolor;

		Transform[] pathTransforms= GetComponentsInChildren<Transform>();
		shots = new List<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms [i] != transform) {
				shots.Add (pathTransforms [i]);
			}
		}
		for (int i = 0; i < shots.Count; i++) {
			Vector3 currentShot = shots [i].position;
			Vector3 previousShot= Vector3.zero;
			if (i > 0) {
				previousShot = shots [i - 1].position;
			} else if (i == 0 && shots.Count > 1) {
				previousShot = shots [shots.Count - 1].position;
			}
			if (showPath) {
				Gizmos.DrawLine (previousShot, currentShot);
				Gizmos.DrawWireSphere (currentShot, 0.3f);
			}
		} 
	}
}
