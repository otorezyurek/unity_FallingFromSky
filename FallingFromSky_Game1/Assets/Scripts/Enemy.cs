using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;
    float speed;
    public int damage;

    Player playerScript;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            playerScript.TakeDamage(damage);

            Destroy(this.gameObject);
		}

		if (collision.CompareTag("Finish"))
		{
            Destroy(this.gameObject);
		}
	}
}
