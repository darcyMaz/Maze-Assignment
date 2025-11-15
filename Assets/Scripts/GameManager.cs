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

    // Mazes
    public MazeBuilder mazeBuilder1;
    public MazeBuilder mazeBuilder2;
    public MazeBuilder mazeBuilder3;
    private MazeBuilder[] mazeList;
    private bool Maze1Done;
    private bool Maze2Done;
    private bool Maze3Done;


    void Start()
    {
        player = player_go.GetComponent<Player>();
        player_cc = player_go.GetComponent<CharacterController>();
        
        keys = new Collection<Key>();
        keys.Add(key1);
        keys.Add(key2);
        keys.Add(key3);

        mazeList = new MazeBuilder[3];
        mazeList[0] = mazeBuilder1;
        mazeList[1] = mazeBuilder2;
        mazeList[2] = mazeBuilder3;
        Maze1Done = false;
        Maze2Done = false;  
        Maze3Done = false;
        mazeBuilder1.BuildMaze();
        mazeBuilder2.BuildMaze();
        mazeBuilder3.BuildMaze();
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

        // This will only run once, upon the collection of Key1.
        if (key1.IsCollected() && !Maze1Done)
        {
            Maze1Done = true;
            player.ResetPlayer();
        }
        // Same for these two.
        if (key2.IsCollected() && !Maze2Done)
        {
            Maze2Done = true;
            player.ResetPlayer();
        }
        if (key3.IsCollected() && !Maze3Done)
        {
            Maze3Done = true;
            player.ResetPlayer();
        }

        /*
        // If the player's health goes below zero, the whole game is reset. You lose :(
        else if ( player.GetHealth() <= 0 )
        {
            Debug.Log("The player's health has reached zero, that means you died :(");
            Debug.Log("The game will now be reset from the start.");
            ResetGame();
        }
        */
    }

    void FinalDoorCheck()
    {
        if (finalDoor.IsUnlocked() && endzone.AreKeysCollected())
        {
            finalDoor.OpenDoor();
        }
    }

    public void TeleportPlayerToMaze(int MazeNumber)
    {
        // Access maze, get starting position
        Vector3 mazeStartPos = mazeList[MazeNumber - 1].GetStartingPoint();

        // player.SetPosition(that maze position);
        player.SetPosition(mazeStartPos);
    }

    public void ResetGame()
    {
        // call reset function for key collection, player, and animations.
        endzone.ResetEndzone();
        foreach (Key key in keys) key.ResetKey();
        player.ResetPlayer();
        finalDoor.CloseDoor();
        // Reset the mazes.

        Maze1Done = false;
        Maze2Done = false;
        Maze3Done = false;
    }

}
