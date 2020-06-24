using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    int score = 0;
    public Text scoreText;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(player != null)
		{
            if (collision.CompareTag("Enemy"))
            {
                score += 1;

                scoreText.text = score.ToString();
            }
        }       
    }
}
