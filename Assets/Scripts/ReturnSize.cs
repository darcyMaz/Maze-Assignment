using UnityEngine;

public class TempScript : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(GetComponent<MeshRenderer>().bounds.size);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
