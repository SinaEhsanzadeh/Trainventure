using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{ 
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            transform.lossyScale.Scale(new Vector3(0.5f, 0.5f, 0.5f));
        }
    }
}
