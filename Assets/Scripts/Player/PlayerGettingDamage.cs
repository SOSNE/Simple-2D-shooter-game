using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGettingDamage : MonoBehaviour
{
    private bool Contact = true;

    private float timeOpacity, timeColider;
    

    void OnTriggerEnter2D(Collider2D CoTo)
    {
        if (CoTo.tag == "Enemy" && Contact)
        {
            StartCoroutine(ResetTransparencyAfterDelay(0.4f));
            HealthBarFill.Helthvaluecurent -= CoTo.GetComponent<EnemyStats>().DmPower;
            StartCoroutine(ResetContactAfterDelay(2));
            gameObject.GetComponent<Rigidbody2D>().velocity = CoTo.GetComponent<EemyMovment>().directionToPlayer.normalized*10;
            Contact = false;
            
        }
    } 
    IEnumerator ResetContactAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait the specified number of seconds
        Contact = true;
    }

    IEnumerator ResetTransparencyAfterDelay(float delay)
    {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Color currentColor1 = gameObject.GetComponent<Renderer>().material.color;
            currentColor1.a = 114f / 255f;
            gameObject.GetComponent<Renderer>().material.color = currentColor1;

            yield return new WaitForSeconds(delay);

            Color currentColor2 = gameObject.GetComponent<Renderer>().material.color;
            currentColor2.a = 1;
            
            gameObject.GetComponent<Renderer>().material.color = currentColor2;
            yield return new WaitForSeconds(delay);
            gameObject.GetComponent<Renderer>().material.color = currentColor1;
            yield return new WaitForSeconds(delay);
            gameObject.GetComponent<Renderer>().material.color = currentColor2;
            yield return new WaitForSeconds(delay);
            gameObject.GetComponent<Renderer>().material.color = currentColor1;
            yield return new WaitForSeconds(delay);
            gameObject.GetComponent<Renderer>().material.color = currentColor2;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
