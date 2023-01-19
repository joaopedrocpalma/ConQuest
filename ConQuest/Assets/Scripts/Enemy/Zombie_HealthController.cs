using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_HealthController : MonoBehaviour
{
    Animator animator;
    public int hp = 100;
    public int points = 2;
    

    Zombie_AI enemyVar;

    private void Start()
    {
        animator = GetComponent<Animator>(); //This is used to get the animation group for the enemy
        enemyVar = gameObject.GetComponent<Zombie_AI>();
    }


    private void Update()
    {
        if (hp <= 0) //Plays the death animation if the enemy health drops to 0 or below
        {         
            animator.SetBool("Dying", true);
            animator.SetBool("Attacking", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Walking", false);
            enemyVar.rotationSpeed = 0;
            enemyVar.movementSpeed = 0;
            StartCoroutine(Timer());            
        }        
    }

    IEnumerator Timer() //This is a timer to destroy the enemy after 2 seconds
    {
        yield return new WaitForSeconds(2);        
        Destroy(this.gameObject);        
    }
}
