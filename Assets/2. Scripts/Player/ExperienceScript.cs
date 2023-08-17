using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceScript : MonoBehaviour
{
    public Image expImg;
    public Text currLvlText;
    public int currentLvl;
    public float currentExperience, expTNL;
    public GameObject levelUpText;

    public static ExperienceScript instance;

    private void Awake()
    {
        if(instance == null )
        {
            instance = this;
        }
    }
    void Start()
    {
        currentLvl = 1;
        currLvlText.text = currentLvl.ToString();
        expImg.fillAmount = currentExperience / expTNL;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void expModifier(float experience)
    {
        currentExperience += experience;
        expImg.fillAmount = currentExperience / expTNL;
        if (currentExperience >= expTNL)
        {
            expTNL = expTNL * 2;
            currentExperience = 0;
            PlayerHealth.instance.maxHealth += 10f;
            Hearts.instance.maxHearts += 5;
            currentLvl ++;
            AudioManager.instance.PlayAudio(AudioManager.instance.lvlUp);
            ShowLevelUp();
            currLvlText.text = currentLvl.ToString();

        }
    }

    public void ShowLevelUp()
    {
        GameObject text = Instantiate(levelUpText, transform.position, Quaternion.Euler(0, 0, 0));
        text.GetComponent<TextMeshPro>();
    }

}