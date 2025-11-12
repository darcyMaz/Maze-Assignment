using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    CharacterController cc;
    float speed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
        speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        Vector3 mp = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        Vector3 center = new Vector3(Screen.width/2, 0, Screen.height/2);
        Vector3 newForward = mp - center;
        
        //Vector3 newForward = mp - new Vector3(transform.position.x, 0, transform.position.y);

        transform.forward = newForward;
        // Debug.DrawRay(new Vector3(0, 2, 0), newForward, Color.blue);

        if (Input.GetKey("w"))
        {
            dir += new Vector3(0,0,1);
        }
        if (Input.GetKey("s"))
        {
            dir += new Vector3(0, 0, -1);
        }
        if (Input.GetKey("a"))
        {
            dir += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            dir += new Vector3(1, 0, 0);
        }
        cc.SimpleMove(transform.rotation * dir * speed);
    }
}
