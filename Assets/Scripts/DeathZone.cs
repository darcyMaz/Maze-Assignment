using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        

        if (other.tag == "Player")
        {
            

            // deduct one health
            // if less than or equal to zero then game over, call restart
            // put player back at the start either way
            Player player = other.GetComponent<Player>();

            if (player == null) { Debug.Log("A DeathZone tried to kill a player but grabbed a null component instead of a Player component."); return; }

            player.TakeDamage(1);
            if (player.GetHealth() > 0) player.ResetPosition();
            // Otherwise, GameManager will see that the player has health below zero and end the game.

        }
    }

}
