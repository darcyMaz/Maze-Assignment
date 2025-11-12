using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class SetMazeParts : MonoBehaviour
{
    // Goal of this script is to get every child object in the maze group and fix their position so it actually makes sense.

    Dictionary<float[], Transform> mazeParts;
    public float squareSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mazeParts = new Dictionary<float[], Transform>();

        // Get each child of this maze group and put them in the collection.
        GetMazeChildren();

        // Set the objects based on the square size and their names which have their coords.
        SetMazeChilren();
    }

    private void GetMazeChildren()
    { 

        // Gets every child object of the group and their coords in the maze (from their name).
        foreach (Transform child_t in transform)
        {
            // Turns: "x:0-y:0 primordialPart:0 groupId:0" into ["x:0","y:0"]
            string[] child_coords_str = child_t.name.Split(" ")[0].Split("-");

            // Get their coords in the maze.
            float x = float.Parse(child_coords_str[0].Split(":")[1]);
            float y = float.Parse(child_coords_str[1].Split(":")[1]);
            float[] child_coords = {x,y};

            // Map between their coords and the transform.
            mazeParts.Add(child_coords, child_t);
        }

    }

    private void SetMazeChilren()
    {
        foreach (KeyValuePair<float[], Transform> keyValuePair in mazeParts)
        {
            Debug.Log(keyValuePair.Key[0] + ":" + keyValuePair.Key[1] + " " + keyValuePair.Value.position + " " + keyValuePair.Value.localPosition);

            keyValuePair.Value.Rotate(0, 180f, 0);
        }
    }

    
}
