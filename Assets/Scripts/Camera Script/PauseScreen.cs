using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public Transform pausePanel;

    private Vector3 idleState;
    private Vector3 activeState;

    private bool isPaused;
    private bool buttonPressed;

    void Start()
    {
        idleState = pausePanel.localPosition;
        activeState = idleState + new Vector3(0, 10, 0);
        isPaused = false;
        buttonPressed = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buttonPressed = true;
        }
        if (buttonPressed)
        {
            StartCoroutine(Pause());
        }
    }

    IEnumerator Pause()
    {

        if (!isPaused)
        {
            Time.timeScale = 0;
            pausePanel.localPosition = Vector3.Lerp(pausePanel.localPosition, activeState, 0.2f);
            yield return new WaitForSecondsRealtime(0.3f);
            if (pausePanel.localPosition != activeState)
                pausePanel.localPosition = activeState;
            isPaused = true;
            buttonPressed = false;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.localPosition = Vector3.Lerp(pausePanel.localPosition, idleState, 0.5f);
            yield return new WaitForSecondsRealtime(0.3f);
            if (pausePanel.localPosition != idleState)
                pausePanel.localPosition = idleState;
            isPaused = false;
            buttonPressed = false;
        }
        
    }
}