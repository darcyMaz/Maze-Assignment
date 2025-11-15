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
    // int init_health;
    public Vector3 start_pos;

    Vector3 direction = Vector3.zero;
    float gravity = -9.8f;

    Boolean reset_pos_lock;
    private Vector3 TeleportPosition;

    void Start()
    {
        // Init the character controller.
        cc = GetComponent<CharacterController>();

        // Arbitrary move speed.
        move_speed = 20f;

        // Arbitrary rotation speed.
        rotation_speed = 0.6f;

        /*
        // Set health
        init_health = 5;
        health = init_health;
        */

        reset_pos_lock = false;
        TeleportPosition = start_pos;
    }

    
    void Update()
    {
        // ROTATION TRANSFORMATION
        // For now, rotation will be based on K and L buttons instead of the mouse.
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 1, 0), -rotation_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0), rotation_speed);
        }

        // POSITION TRANSFORMATION
        direction = transform.TransformDirection(new Vector3(Input.GetAxis("Vertical") * move_speed, gravity, /*Input.GetAxis("Horizontal")*/0));
        cc.Move(direction * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (reset_pos_lock) 
        { 
            transform.position = TeleportPosition; 
            transform.rotation = Quaternion.identity;
            reset_pos_lock = false; 
        }
    }

    /*
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public int GetHealth()
    {
        return health;
    }
    */

    public void SetPosition(Vector3 next_pos)
    {
        TeleportPosition = next_pos;
        reset_pos_lock = true;
    }

    public void ResetPlayer()
    {
        // health = init_health;
        SetPosition(start_pos);
    }

}
