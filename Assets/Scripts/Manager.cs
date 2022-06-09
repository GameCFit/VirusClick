using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int rnd;
    public int covidp;
    public int coin;
    public Animator butvacanim;
    public Text covidpt;
    public Text coint;
    public GameObject shop;
    public GameObject startPanel;
    public Animator maskanim;
    public Text daysText;
    public float days = 0;
    private bool quarantine = false;
    private int minusPeoplevact;
    public Animator quaratineAnimator;
    public GameObject quratinePanel;
    public GameObject ourtineButton;
    private void Awake()
    {
        startPanel.SetActive(true);
        covidp = 20000;
        StartCoroutine(day());
        StartCoroutine(covidPeoplePlus());
        minusPeoplevact = 1000;
        quratinePanel.SetActive(false);
        ourtineButton.SetActive(false);
    }
    public void clouseStartPanel()
    {
        startPanel.SetActive(false);
    }
    private void Update()
    {
        daysText.text = days + " дней ";
        covidpt.text = covidp + "";
        coint.text = coin + "";
        if(days > 3)
        {
            ourtineButton.SetActive(true);
        }
    }
    IEnumerator day()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            ++days;
        }
    }
    IEnumerator covidPeoplePlus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.3f);
            if (quarantine == false && days <= 3)
            {
                covidp += 1000;
            }
            else if (quarantine == false && days > 3 && days <= 7)
            {
                covidp += 2000;
            }
            else if (quarantine == false && days > 7 && days <= 15)
            {
                covidp += 4000;
            }
            else if(quarantine == true)
            {
                covidp += 500;
                coin -= 10;
            }
        }
    }
    public void maskclick()
    {
        coin += 3;
        covidp -= 100;
    }
    public void upVactina()
    {
        if(coin >= 100)
        {
            coin -= 100;
            minusPeoplevact += 200;
        }
    }
    public void quartioneButton()
    {
        if(quarantine == false)
        {
            quratinePanel.SetActive(true);
            quaratineAnimator.SetTrigger("IsVatc");
            quarantine = true;
        }
        else
        {
            quratinePanel.SetActive(false);
            quarantine = false;
        }
    }
    public void Exshop()
    {
        shop.SetActive(false);
        butvacanim.SetTrigger("IsVatc");
    }
    public void PanelShop()
    {
        shop.SetActive(true);
    }
    public void Vacina()
    {
        if (coin >= 10)
        {
            butvacanim.SetTrigger("IsVatc");
            coin -= 10;
            covidp -= minusPeoplevact;
        }
    }
}
