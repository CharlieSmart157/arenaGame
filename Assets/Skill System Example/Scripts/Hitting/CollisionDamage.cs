using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {

	public float damage = 1;

	void OnCollisionEnter(Collision collision) {
		collision.collider.SendMessage("OnTakeDamage", damage, SendMessageOptions.DontRequireReceiver);
	}

}
