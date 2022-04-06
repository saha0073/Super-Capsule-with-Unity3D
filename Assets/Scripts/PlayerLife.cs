using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    bool dead = false;
    private void Update()
    {
        if (transform.position.y < -1f && !dead) {  
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            //setting the position of player to platform
            //collision.gameObject.transform.SetParent(transform);
            //Debug.Log("death");
            //disable meshrenderer, kinematics
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }
    void Die()
    {
        
        Invoke(nameof(ReloadLevel), 2f);
        dead = true;
        deathSound.Play();
        //Debug.Log("dead");  

    }

    void ReloadLevel()
    {
        //starting the samplescene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
