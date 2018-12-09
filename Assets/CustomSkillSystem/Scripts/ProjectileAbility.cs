using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ProjectileAbility : Ability {

    public GameObject projectileEntity;
    public int initialForce;

    public override void castAbility() {
        base.castAbility();
        CmdSpawnMissile();
    }

    [Command]
    void CmdSpawnMissile() {
        //Create Projectile Entity
        var projectile = (GameObject)Instantiate(projectileEntity, target.transform.position, target.transform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = target.transform.TransformDirection(Vector3.forward * initialForce);
        NetworkServer.Spawn(projectile);
    }

}
 

