
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update () {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            
            // If this is true: The player has moved across the portal
            if (portalToPlayer.y < 0f)
            {
                // Teleport him!
                Vector3 upperPos = new Vector3(reciever.position.x, reciever.position.y + 2, reciever.position.z);
                player.position = upperPos ;
                
                playerIsOverlapping = false;
                
            }
            else
            {
                Vector3 lowerPos = new Vector3(reciever.position.x, reciever.position.y - 2, reciever.position.z);
                player.position = lowerPos ;
                
                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
