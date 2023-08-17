using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public Text HeartsText;
    public int HeartsAmount;
    public int maxHearts;

    public static Hearts instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        HeartsText.text = "x " + HeartsAmount.ToString();
    }

    public void SubItem(int subItemsAmount)
    {
        HeartsAmount += subItemsAmount;

        if(HeartsAmount > maxHearts)
        {
            HeartsAmount = maxHearts;
        }

        HeartsText.text = "x " + HeartsAmount.ToString();
    }

}

