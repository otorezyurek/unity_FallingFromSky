using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text healthText;

    public float speed;
    public int health;

    float input;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthText.text = health.ToString();
    }

	void Update()
	{
		if(input < 0)
		{
            transform.eulerAngles = new Vector3(0, 0, 0);
		}
        if(input > 0)
		{
            transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}

	void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damage)
	{
        health -= damage;

        healthText.text = health.ToString();

        if (health <= 0)
		{
            Destroy(gameObject);
            healthText.text = "YOU DEAD";

        }
	}
}
