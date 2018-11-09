using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour {

    [SerializeField] Text healthText;
    [SerializeField] Text defenceText;
    [SerializeField] Text attackText;
    [SerializeField] Text playerMoneytext;
    private string errorMessage = "You don't have enought money";

    public void Start()
    {
        updateAttackPrice();
        updateDefencePrice();
        updateHealthPrice();
        updatePlayerMoney();
    }

    public void buyHealth()
    {
        if(Player_Info.Money>= ShopInfo.HealthPrice)
        {
            Player_Info.BuyHealth();
            print(Player_Info.startingHealth);
            Player_Info.reduceMoney(ShopInfo.HealthPrice);
            ShopInfo.incrementHealth();
            updateHealthPrice();
            updatePlayerMoney();
        }
        else
        {
            errorHealthPrice();
            Invoke("updateHealthPrice", 3f);
        }
        
    }
    public void buyDefence()
    {
        if(Player_Info.Money >= ShopInfo.DefencePrice)
        {
            Player_Info.BuyDefence();
            print(Player_Info.defence);
            Player_Info.reduceMoney(ShopInfo.DefencePrice);
            ShopInfo.incrementDefence();
            updateDefencePrice();
            updatePlayerMoney();
        }
        else
        {
            errorDefencePrice();
            Invoke("updateDefencePrice", 3f);
        }

    }
    public void buyDegat()
    {
        if (Player_Info.Money >= ShopInfo.AttackPrice)
        {
            Player_Info.BuyDamage();
            print(Player_Info.degat);
            Player_Info.reduceMoney(ShopInfo.AttackPrice);
            ShopInfo.incrementAttack();
            updateAttackPrice();
            updatePlayerMoney();
        }
        else
        {
            errorAttackPrice();
            Invoke("updateAttackPrice", 3f);
        }
    }

    private void updateHealthPrice()
    {
        healthText.text = ShopInfo.HealthPrice.ToString();
    }

    private void updateDefencePrice()
    {
        defenceText.text = ShopInfo.DefencePrice.ToString();
    }

    private void updateAttackPrice()
    {
        attackText.text = ShopInfo.AttackPrice.ToString();
    }

    private void errorHealthPrice()
    {
        healthText.text = errorMessage;
    }

    private void errorDefencePrice()
    {
        defenceText.text = errorMessage;
    }

    private void errorAttackPrice()
    {
        attackText.text = errorMessage;
    }

    private void updatePlayerMoney()
    {
        playerMoneytext.text = Player_Info.Money.ToString();
    }
}
