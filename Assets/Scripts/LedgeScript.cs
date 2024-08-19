using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LedgeScript : MonoBehaviour
{
    private bool climbed;

    private void Start()
    {
        climbed = false;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if(!climbed){
                target.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
                climbed = true;
                StartCoroutine(OnTriggerExit2D(target));
            }
        }
    }

    IEnumerator OnTriggerExit2D(Collider2D target)
    {
        yield return new WaitForSeconds(2f);
        if (target.gameObject.CompareTag("Player"))
        {
            climbed = false;
        }
    }
}
