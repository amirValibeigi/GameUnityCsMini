using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : CharacterStats
{

    private PlayerHUD hud;

    private void Start()
    {
        getReferences();
        initVariable();
        initVariableLocal();
    }
    private void getReferences()
    {
        hud = GetComponent<PlayerHUD>();

    }

    public override void checkHealth()
    {
        base.checkHealth();

        hud.updateHealth(health);
    }

    private void initVariableLocal()
    {
        setPlayerName(PlayerPrefs.GetString("namePlayer", "AmIr"));
    }
}
