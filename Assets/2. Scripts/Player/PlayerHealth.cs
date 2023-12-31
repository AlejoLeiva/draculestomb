using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image HealthImg;
    bool isInmune;
    public float inmunityTime;
    Blink material;
    SpriteRenderer sprite;
    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rb;

    public GameObject gameOverImg;

    /// <summary>
    /// lic GameObject gameOverImg;
    /// </summary>

    void Start()
    {
        ///eOverImg.SetActive(false);
        gameOverImg.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }


    public static PlayerHealth instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HealthImg.fillAmount = health / 100;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") &&!isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());
            if (collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }else
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            
            if (health <= 0)
            {
                Time.timeScale = 0;
                // aparecer pantalla gameover
                gameOverImg.SetActive(true);
                AudioManager.instance.backgroundMusic.Stop();
                AudioManager.instance.PlayAudio(AudioManager.instance.gameOver);
            }
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.blinking;
        yield return new WaitForSeconds(0.5f);
        isInmune = false;
        sprite.material = material.original;
    }
}
