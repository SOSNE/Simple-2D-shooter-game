using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarr : MonoBehaviour
{
    public GameObject playerPosition;
    void Update()
    {
        Vector2 HelthBarPosition =  new Vector2((playerPosition.transform.position.x - gameObject.transform.position.x)*25 ,
                (playerPosition.transform.position.y - gameObject.transform.position.y + 1.3f)*40 );
        
        gameObject.GetComponent<Rigidbody2D>().velocity = HelthBarPosition;
    }
}
