using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_HealthController : MonoBehaviour
{
    public int hp = 100;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        if (hp <= 0) //If the plaeyr is killed the scene is reloaded
        {
            SceneManager.LoadScene("Main Scene");
        }
    }

    private void OnTriggerEnter(Collider other) //When enemy collides with the player, player takes damage
    {
        Zombie_AI enemy = other.GetComponent<Zombie_AI>();
        if (other.tag == "Enemy")
        {
            hp -= enemy.damage;
        }
    }

    /*private void OnCollisionEnter(Collision _collision) //When enemy enters the collising range
    {
        if (_collision.gameObject.tag == "Enemy")
        {
            hp -= damageTaken;
        }
    }*/
}
