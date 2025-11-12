using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class Player : MonoBehaviour
{
    CharacterController cc;
    float move_speed;
    float rotation_speed;
    int health;
    int init_health;
    public Vector3 start_pos;

    Vector3 direction = Vector3.zero;
    float gravity = -9.8f;

    Boolean reset_pos_lock;

    void Start()
    {
        // Init the character controller.
        cc = GetComponent<CharacterController>();

        // Arbitrary move speed.
        move_speed = 20f;

        // Arbitrary rotation speed.
        rotation_speed = 0.6f;

        // Set health
        init_health = 5;
        health = init_health;

        reset_pos_lock = false;
    }

    
    void Update()
    {
        //reset_pos_lock = true;

        // ROTATION TRANSFORMATION
        // For now, rotation will be based on K and L buttons instead of the mouse.
        if (Input.GetKey(KeyCode.K))
        {
            transform.Rotate(new Vector3(0, 1, 0), -rotation_speed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(new Vector3(0, 1, 0), rotation_speed);
        }

        // POSITION TRANSFORMATION
        direction = transform.TransformDirection(new Vector3(Input.GetAxis("Vertical") * move_speed, gravity, Input.GetAxis("Horizontal")));
        cc.Move(direction * Time.deltaTime);

    }

    void FixedUpdate()
    {
        if (reset_pos_lock) 
        { 
            transform.position = start_pos; 
            transform.rotation = Quaternion.identity;
            reset_pos_lock = false; 
        }
    }

    /*
    void LateUpdate()
    {
        if (reset_pos_lock)
        {
            transform.position = start_pos;
            reset_pos_lock = false;
            // Debug.Log("transform.pos: " + transform.position);
        }
    }
    */

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public int GetHealth()
    {
        return health;
    }

    public void ResetPosition()
    {
        // while (reset_pos_lock) ;
        reset_pos_lock = true;

        // cc.velocity = Vector3.zero;
        // transform.position = start_pos;



        // Debug.Log("Inside reset position in player");

        
    }

    public void ResetPlayer()
    {
        health = init_health;
        ResetPosition();
    }

}
