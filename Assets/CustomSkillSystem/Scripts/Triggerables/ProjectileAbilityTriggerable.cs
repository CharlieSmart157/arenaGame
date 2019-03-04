using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ProjectileAbilityTriggerable : NetworkBehaviour {

    [HideInInspector]public GameObject projectileEntity;
    [HideInInspector]public int initialForce;
    [HideInInspector]public GameObject target;


    public void castAbility() {
        //Expend Cooldown
        CmdSpawnMissile();
    }

    [Command]
    void CmdSpawnMissile()
    {
        //Create Projectile Entity
        var projectile = (GameObject)Instantiate(projectileEntity, target.transform.position, target.transform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = target.transform.TransformDirection(Vector3.forward * initialForce);
        NetworkServer.Spawn(projectile);
    }


}
