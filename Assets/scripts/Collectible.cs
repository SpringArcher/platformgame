using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    public GameObject ScoreCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score = 0;
    void Start()
    {
        ScoreCountText.GetComponent<TextMeshProUGUI>().text = "Coins: " + score;
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
            ScoreCountText.GetComponent<TextMeshProUGUI>().text = "Coins: " +score;
            Destroy(gameObject);
        }
    }
}


