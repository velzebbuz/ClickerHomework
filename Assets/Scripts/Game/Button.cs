using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ArrowsType arrowType;

    private float fcountHit;
    private float fcountArrow;
    private int scoreAdd;
    private void Awake()
    {
        scoreAdd = 0;
    }
    private void CheckZone()
    {
        if (CheckRing.Instance.checker && arrowType == CheckRing.Instance.triggerIcon.arrT)
        {
            CheckRing.Instance.ColorRing();
            Destroy(CheckRing.Instance.triggerIcon.gameObject);
            GameManager.Instance.countHit += 1;
            GameManager.Instance.countCombo++;
            scoreAdd = 10 * GameManager.Instance.countCombo;
            GameManager.Instance.AddScore(scoreAdd);
            BackgroundColor.Instance.BackgroundColorSwitch();
            CountHitRate();
            LifePlus();
        }
        else
        {
            GameManager.Instance.countCombo = 0;
        }
    }

    private void Update()
    {
        if (CheckRing.Instance.checker && arrowType == CheckRing.Instance.triggerIcon.arrT)
            GameManager.Instance.miss = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {        
        CheckZone();
        GameUI.Instance.textCombo.text = "Combo: " + GameManager.Instance.countCombo.ToString() + "x";
        Vibration.Vibrate(30);
    }
    
    private void CountHitRate()
    {
        fcountArrow = GameManager.Instance.countArrow;
        fcountHit = GameManager.Instance.countHit;
        GameManager.Instance.hitCountRate = (fcountHit / fcountArrow) * 100;
        GameUI.Instance.hitRate.text = "Hit rate : " + GameManager.Instance.hitCountRate.ToString("#0.00") + " %";
        
    }

    private void LifePlus()
    {
        if (GameManager.Instance.countCombo % 2 == 0 && GameManager.Instance.lifeCount < GameManager.Instance.maxCountLife)
            GameManager.Instance.lifeCount++;
        GameManager.Instance.SetTxt(GameManager.Instance.lifeCount, GameUI.Instance.textLife, "Lifes: ");
    }

}
