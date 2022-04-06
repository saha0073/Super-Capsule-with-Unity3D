using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //setting the position of player to platform
            collision.gameObject.transform.SetParent(transform);
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {//unparenting from moving platform through null
            collision.gameObject.transform.SetParent(null); 
        }
    }
}
