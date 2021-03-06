using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] int pointsForCoinPickup = 60;
    bool isCollected = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"&&!isCollected)
        {
            isCollected = true;
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            Destroy(gameObject);
        }
        FindObjectOfType<GameSession>().IncreaseScore(pointsForCoinPickup);
    }
}
