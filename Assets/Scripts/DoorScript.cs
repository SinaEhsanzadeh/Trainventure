using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Color originalColor;
    private Color newColor;

    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = Color.yellow;
        sprite.color = originalColor;
        newColor = Color.clear;
    }
    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor());
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        sprite.color = Color.Lerp(sprite.color, newColor, 0.1f);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator CloseDoor()
    {
        sprite.color = Color.Lerp(sprite.color, originalColor, 0.75f);
        yield return new WaitForSeconds(0.5f);
        
    }
}
