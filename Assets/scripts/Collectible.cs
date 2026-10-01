using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            score += 1;
            Destroy(gameObject);
        }
    }
}

