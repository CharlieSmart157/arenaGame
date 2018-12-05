using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability {

    public GameObject projectileEntity;
    public int initialForce;
    public override void castAbility() {
        base.castAbility();
        spawnMissile();
    }

    void spawnMissile() {
        //Create Projectile Entity
        print(target.transform.position);
        var projectile = Instantiate(projectileEntity) as GameObject;
        projectile.transform.position = target.transform.position;
        projectile.transform.rotation = target.transform.rotation;
        projectile.GetComponent<Rigidbody>().velocity = target.transform.TransformDirection(Vector3.forward * initialForce);
    }

}
 

