using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerPosition;
    
    void Update()
    {
        transform.position = new Vector3( playerPosition.position.x, playerPosition.position.y,-10);
    }
}
