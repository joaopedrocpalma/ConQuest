using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public int score = 0;
    public Text scoreBoard;
    
    void Update()
    {
        GameObject enemyHC = GameObject.FindGameObjectWithTag("Enemy");
        Zombie_HealthController zHC = enemyHC.GetComponent<Zombie_HealthController>();

        if (zHC.hp <= 0)
        {
            score += zHC.points;
            scoreBoard.text = score.ToString();
        }        
    }
}
