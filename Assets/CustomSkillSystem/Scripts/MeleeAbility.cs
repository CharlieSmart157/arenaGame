using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MeleeAbility : Ability
{
    //Base class for Melee abilites.
    //Will cause user to perform Animation and create hitbox object
    //Object will cause status effects, damage etc. to enemies.


    public override void castAbility()
    {
        base.castAbility();
        CmdSpawnMissile();
    }


    [Command]
    void CmdSpawnMissile()
    {

    }

}
