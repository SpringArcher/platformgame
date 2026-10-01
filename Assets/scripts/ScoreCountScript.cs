using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCountScript : MonoBehaviour
{
    public GameObject ScoreCountText;
    public GameObject Collectible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreCountText.GetComponent<TextMeshProUGUI>().text = ("Coins: ");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCountText.GetComponent<TextMeshProUGUI>().text = ("Coins: ");
    }
}
