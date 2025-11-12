using UnityEngine;

public class MazeBuilder : MonoBehaviour
{
    // This class is for actually building the maze.

    // Accept the wall specifications from MazeGenerator.
    // Translate those specs from wall arrays to a dictionary where coords corresponds to an integer representing the tile type.
    // Generate in unity the tile based on the tile type in the dictionary and place it at its coordinates.
    // And create spacing for the size of the tile.


    private MazeGenerator MazeGenerator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MazeGenerator = new MazeGenerator();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildMaze()
    {

    }

    private 



}
