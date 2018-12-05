using UnityEngine;
using System.Collections;

public class SpawnAtCursor : MonoBehaviour {

	public GameObject prefab;

	void OnFire() {
		var obj = Instantiate(prefab) as GameObject;
		obj.transform.position = GetSpawnPoint();
	}

	private Vector3 GetSpawnPoint() {
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100f)) {
			return hit.point;
		} else {
			return transform.position;
		}
	}

}
