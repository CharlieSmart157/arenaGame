using UnityEngine;

public class Damageable : MonoBehaviour {

	void OnTakeDamage(float damage) {
		Destroy(gameObject);
	}

}
