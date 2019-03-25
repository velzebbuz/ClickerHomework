using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MissPointInit : MonoBehaviour
{
    private float fcountHit;
    private float fcountArrow;

    private void Start()
    {
        transform.position = Border.Instance.MissPoint();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.countMiss += 1;
        GameManager.Instance.lifeCount -= 1;
        GameManager.Instance.miss = true;
        GameManager.Instance.SetTxt(GameManager.Instance.lifeCount, GameUI.Instance.textLife, "Lifes: ");
        ComboExit();
        CountHitRate();
        GameUI.Instance.textCombo.text = "Combo: " + GameManager.Instance.countCombo.ToString() + "x";
        BackgroundColor.Instance.MissBackgroundColor();
    }

    private void ComboExit()
    {
        if (GameManager.Instance.miss && GameManager.Instance.countCombo != 0)
        {
            GameManager.Instance.countCombo = 0;
        }
    }
    private void CountHitRate()
    {
        fcountArrow = GameManager.Instance.countArrow;
        fcountHit = GameManager.Instance.countHit;
        GameManager.Instance.hitCountRate = (fcountHit / fcountArrow)*100;
        GameUI.Instance.hitRate.text = "Hit rate : " + GameManager.Instance.hitCountRate.ToString("#0.00") + " %";
         
    }
}
