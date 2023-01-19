using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Animator animator;

    public int damage = 30;

    public Camera playerCamera; //This is required because the "shot" is fired from the center of the camera

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isFiring", true);

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit)) //If the ray hits something
            {
                Zombie_HealthController target = hit.transform.GetComponent<Zombie_HealthController>();

                if(target != null) //If the target has the Zombie_HealthController script it gets damaged
                {
                    target.hp -= damage;
                }
            }
        }
        else
        {
            animator.SetBool("isFiring", false);
        }
    }
}
