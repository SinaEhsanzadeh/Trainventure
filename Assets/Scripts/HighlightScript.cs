using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Color color;
    public Color originalColor;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = Color.red;
        color = Color.cyan;
    }
    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            sprite.color = color;
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            sprite.color = originalColor;
        }
    }
}
