using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStats : MonoBehaviour
{
    float attack;
    float totalAttack;
    public float weaponAttack;

    public GameObject damageText;
    void Start()
    {
        attack = PlayerStats.instance.attack;
    }

    public float DamageInput(float enemyDefense, Transform hit)
    {
        totalAttack = attack + weaponAttack + (100 / (100 + enemyDefense));
        float finalAttackPower = Mathf.Round(Random.Range(totalAttack - 10, totalAttack + 5));

        if(finalAttackPower > totalAttack +4)
        {
            finalAttackPower *= 2;
            print("Critico");
        }

        if( finalAttackPower < 0)
        {
            finalAttackPower = 0;
            print("attack blocked");
        }

        GameObject textGO = Instantiate(damageText, hit.transform.position, Quaternion.identity);
        textGO.GetComponent<TextMeshPro>().SetText(finalAttackPower.ToString());

        print("final attack power");
        return finalAttackPower;
    }
}
