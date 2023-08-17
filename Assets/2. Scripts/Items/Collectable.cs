using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public int swordsToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Hearts.instance.SubItem(swordsToGive);
            AudioManager.instance.PlayAudio(AudioManager.instance.hearts);
            Destroy(gameObject);
        }
    }
}
