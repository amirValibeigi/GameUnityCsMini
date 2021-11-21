using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Text txHealth;


    public void updateHealth(int health)
    {
        txHealth.text = health.ToString();
    }

}
