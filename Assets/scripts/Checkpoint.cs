using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject ChePointText;
    bool firstCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (firstCheck == false)
            {
                print("Checkpoint reached!");
                ChePointText.GetComponent<TextMeshProUGUI>().text = "Checkpoint \n reached! \n ^";
                firstCheck = true;
            }
            else
            {
                ChePointText.GetComponent<TextMeshProUGUI>().text = "Checkpoint \n already hit! \n ^";
            }
            Invoke("removeText", 5);
        }
    }
    void removeText()
    {
        ChePointText.GetComponent<TextMeshProUGUI>().text = " ";
    }
}
