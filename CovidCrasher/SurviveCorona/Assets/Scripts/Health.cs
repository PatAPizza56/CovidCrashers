using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject heartSprites;
    public ParticleSystem deathParticles;
    public SFXScript sfx;

    private float collisionTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Covid")
        {
            collisionTime = 0f;
            TakeDamage(1);
            sfx.PlayerDamagePlay();
            deathParticles.Play();
        }
        if (collision.collider.tag == "FinalCovid")
        {
            collisionTime = 0f;
            TakeDamage(1);
            sfx.PlayerDamagePlay();
            deathParticles.Play();
        }
        if(collision.collider.tag == "Spikes")
        {
            TakeDamage(1);
            sfx.PlayerDamagePlay();
            deathParticles.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Covid" || collision.gameObject.tag == "FinalCovid")
        {
            // If the time is below the threshold, add the delta time
            if (collisionTime < .8f)
            {
                collisionTime += Time.deltaTime;
            }
            else
            {
                // Time is over theshold, player takes damage
                TakeDamage(1);
                // Reset timer
                collisionTime = 0f;
            }
        }
    }

    void TakeDamage(int damageTaken)
    {
        health = health - damageTaken;
        if (health <= 0)
        {
            this.GetComponent<CharacterController2D>().enabled = false;
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = emptyHeart;
            }
            Invoke("PlayerDead", 0);
        }
    }


    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(transform.position.y <= -15)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = emptyHeart;
            }
            Invoke("PlayerDead", 0);
        }
    }

    void PlayerDead()
    {
        deathParticles.Play();
        heartSprites.SetActive(false);
        this.gameObject.SetActive(false);
        FindObjectOfType<GameManager>().EndGame();
    }
}
