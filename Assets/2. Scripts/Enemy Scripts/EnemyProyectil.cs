using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectil : MonoBehaviour

{
    public GameObject proyectil;
    public float timeToShoot;
    public float shootCooldown;
    Animator anim;
    public bool freqShooter;
    public bool watcher;
    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if(freqShooter)
        {
            shootCooldown -= Time.deltaTime;
        }

        if(shootCooldown < 0)
        {
            Shoot();
        }

        if(watcher)
        {
            anim.SetBool("Fire", false);
        } else
        {
            anim.SetBool("Fire", true);
        }

        
    }

    public void Shoot()
    {

            GameObject cruz = Instantiate(proyectil, transform.position, Quaternion.identity);

            if (transform.localScale.x < 0)
            {
                cruz.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f), ForceMode2D.Force);
            }
            else
            {
                cruz.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f), ForceMode2D.Force);
            }

            shootCooldown = timeToShoot;

        }
}
