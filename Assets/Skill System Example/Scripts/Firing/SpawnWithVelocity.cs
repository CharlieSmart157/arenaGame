using UnityEngine;
using System.Collections;

public class SpawnWithVelocity : MonoBehaviour {

	public GameObject prefab;
	public GameObject origin;
	public float force = 500f;

	void OnFire() {
		var projectile = Instantiate(prefab) as GameObject;
		projectile.transform.position = origin.transform.position;
		projectile.transform.rotation = origin.transform.rotation;
		projectile.GetComponent<Rigidbody>().velocity = origin.transform.TransformDirection(Vector3.forward * force);
	}

}
