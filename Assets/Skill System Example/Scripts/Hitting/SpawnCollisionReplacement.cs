using UnityEngine;
using System.Collections;

public class SpawnCollisionReplacement : MonoBehaviour {

	public GameObject prefab;

	void OnCollisionEnter(Collision collision) {
		var replacement = Instantiate(prefab) as GameObject;
		replacement.transform.position = transform.position;
		replacement.transform.rotation = transform.rotation;
		Destroy(gameObject);
	}

}
