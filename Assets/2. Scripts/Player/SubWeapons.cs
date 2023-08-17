using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{

    public int HeartCost;
    public GameObject arrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
    {
        if (Input.GetButtonDown("Fire2") && HeartCost <= Hearts.instance.HeartsAmount)
        {
            Hearts.instance.SubItem(-HeartCost);
            AudioManager.instance.PlayAudio(AudioManager.instance.arrow);
            GameObject subItem = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, 0));

            if(transform.localScale.x < 0 )
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-700f, 0f), ForceMode2D.Force);
                subItem.transform.localScale = new Vector2((float)-0.3, (float)-0.3);
            }else
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(700f, 0f), ForceMode2D.Force);
            }
            
           
        }
    }
}
