using System;
using System.Collections.ObjectModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Objects that GM connects to.
    public GameObject player_go;
    Player player;
    CharacterController player_cc;
    
    // Keys to collect
    public Key key1;
    public Key key2;
    public Key key3;
    Collection<Key> keys;
    
    // EndZone which ends the game.
    public Endzone endzone;
    
    // Animations
    public Door finalDoor;
    public EndGate eg1;
    public EndGate eg2;
    public EndGate eg3;
    Collection<EndGate> endgates;


    void Start()
    {
        player = player_go.GetComponent<Player>();
        player_cc = player_go.GetComponent<CharacterController>();
        keys = new Collection<Key>();
        keys.Add(key1);
        keys.Add(key2);
        keys.Add(key3);
    }

    // Update is called once per frame
    void Update()
    {

        // Check if keys are collected or not and tell the endzone, so it knows the game could end.
        // Fourth term is so that this statement is not constantly true when the keys are all collected which would constantly call this function.
        //      This statement will only be true once, when the keys are finally all collected.
        if (key1.IsCollected() && key2.IsCollected() && key3.IsCollected() && !endzone.AreKeysCollected())
        {
            endzone.AllKeysCollected();
        }

        // It would be more efficient to have an Animation Manager I think.
        // Check if the final door can be opened.
        FinalDoorCheck();

        // If you reach the EndZone having collected all of the keys, you win!
        if (endzone.IsGameOver())
        {
            Debug.Log("You collected all the keys and returned to the EndZone. You won this game!");
            ResetGame();
        }
        // If the player's health goes below zero, the whole game is reset. You lose :(
        else if ( player.GetHealth() <= 0 )
        {
            Debug.Log("The player's health has reached zero, that means you died :(");
            Debug.Log("The game will now be reset from the start.");
            ResetGame();
        }
    }

    void FinalDoorCheck()
    {
        if (finalDoor.IsUnlocked() && endzone.AreKeysCollected())
        {
            finalDoor.OpenDoor();
        }
    }

    public void ResetGame()
    {
        // call reset function for key collection, player, and animations.
        endzone.ResetEndzone();
        foreach (Key key in keys) key.ResetKey();
        player.ResetPlayer();
        finalDoor.CloseDoor();
        foreach (EndGate eg in endgates) eg.CloseAnimation();
    }

}
