using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotState : CharacterStats
{
    public override void die()
    {
        base.die();
        Destroy(gameObject);
    }
}
