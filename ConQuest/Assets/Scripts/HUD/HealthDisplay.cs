using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text health;

    void Update()
    {
        GameObject playerHC = GameObject.FindGameObjectWithTag("Player");
        Player_HealthController pHC = playerHC.GetComponent<Player_HealthController>();

        health.text = pHC.hp.ToString();

        if(pHC.hp < 0)
        {
            health.text = "0";
        }
    }
}
