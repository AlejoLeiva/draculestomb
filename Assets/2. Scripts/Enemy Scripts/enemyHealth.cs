using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyHealth : MonoBehaviour
{

    Enemy enemy;
    public bool isDamaged;
    public float originalHealth;
    public GameObject deathEffect;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        material = GetComponent<Blink>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        originalHealth = enemy.healthPoints;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon") && !isDamaged)
        {
            //enemy.healthPoints -= 2f;
            enemy.healthPoints -= collision.GetComponent<WeaponStats>().DamageInput(enemy.defense, this.transform);
            AudioManager.instance.PlayAudio(AudioManager.instance.hit);
            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            } else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }

            StartCoroutine(Damager());

            if(enemy.healthPoints <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                ExperienceScript.instance.expModifier(GetComponent<Enemy>().experienceToGive);
                AudioManager.instance.PlayAudio(AudioManager.instance.enemyDead);

                //Respawn
                if(enemy.shouldRespawn)
                {
                    transform.GetComponentInParent<RespwanScript>().StartCoroutine(GetComponentInParent<RespwanScript>().RespawnEnemy());
                }else
                {
                    Destroy(gameObject);
                }

                
            }
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blinking;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.original;
    }
}
