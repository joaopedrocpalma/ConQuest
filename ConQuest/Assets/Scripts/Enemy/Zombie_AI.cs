using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI : MonoBehaviour
{
    Transform player; //This is to know what target to chase
    Animator animator;    

    public float distanceToPlayer;    
    public float movementSpeed = 3;
    public float rotationSpeed = 3;

    public float attackRange = 3;
    public float chaseRange = 2;
    public int damage = 15;
    public int hp = 100;    

    private void Start()
    {
        animator = GetComponent<Animator>(); //This is used to get the animation group for the enemy
        player = GameObject.FindGameObjectWithTag("Player").transform; //Searches for the game object that has the tag "player"

        
    }

    private void Update()
    {
        distanceToPlayer = (player.position - this.transform.position).magnitude; //Gets the distance from the zombie to the player

        if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange) //If player is in range the enemy chases him
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Attacking", false);
            animator.SetBool("Idle", false);

            Vector3 direction = player.position - this.transform.position; //Gets the difference in position from both entities in order to be used in rotation
            direction.y = 0; //To prevent rotation along the Y axis when chasing

            //Gets Player position and makes the enemy move towards it
            transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed*Time.deltaTime); 
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }

        else //This sets the enemy to an Idle state if the player is out of range
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walking", false);
            animator.SetBool("Attacking", false);
        }

        if (distanceToPlayer <= attackRange) //Distance to attack the player and plays the "Attacking" animation
        {
            Vector3 direction = player.position - this.transform.position; 
            transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            direction.y = 0;

            animator.SetBool("Walking", false);
            animator.SetBool("Attacking", true);
            animator.SetBool("Idle", false);
        }
    }    

    void OnDrawGizmosSelected() //This allows for the programmer to see the attacking and the chase range of the enemy, when changing the values
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
