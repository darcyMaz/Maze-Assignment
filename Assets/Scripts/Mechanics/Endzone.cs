using System;
using UnityEngine;

public class Endzone : MonoBehaviour
{
    Boolean areAllKeysCollected;
    Boolean isGameOver;
    // not done colour
    // done colour

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        areAllKeysCollected = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called by GM in resetGame()
    public void ResetEndzone()
    {
        areAllKeysCollected = false;
        isGameOver = false;
    }   
    
    // Called by GM when all keys are collected.
    public void AllKeysCollected()
    {
        areAllKeysCollected = true;
        // Maybe change the colour.
    }

    public Boolean AreKeysCollected()
    {
        return areAllKeysCollected;
    }

    public Boolean IsGameOver()
    {
        return isGameOver;
    }

    private void OnTriggerEnter(Collider other)
    {
        string msg = "Message from the Endzone: ";

        if (areAllKeysCollected)
        {
            msg += "Game has ended!";
            isGameOver = true;
        }
        else
        {
            msg += "You have entered the Endzone without collecting all the keys.";
        }

        Debug.Log(msg);
    }
}
