using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    [Header("Main")]
    public float cost; // цена апгрейда на данный момент 
    public float multiply; // множитель цены после покупки товара(то, ансколько увеличится)
    public int max_upgrade; // максмимальное число апгрейдов(то, сколько раз можно купить этот апгрейд)
    private int now_upgrade;  // количество апгрейдов сейчас
    public clicker ClickerScrr; // ссылка на основной скрипт, считывающий клики для получения данных
    public Text cost_text; // ссылка на текст цены данного апгрейда
    public int decrease_multiply; // то, сколько мы вычтем из силы стула при покупке прокачки "ремесло"

    [Header("Passive")]
    public int passive_power; // параметр, определяющий то, сколько стульев в секунду будет добавлять данный апгрейд

    [Header("Increase Chair lvl")]
    public Buy buyscr; // ссылка на срипт, привязанный к кнопке "ремесло"(после апгрейда стула изменяются параметры этого апгрейда)

    private bool isfirst; // первая ли это покупка

    void Start()
    {
        cost_text.text = cost.ToString();
    }
    // покупка апгрейда "ремесло"
    public void Buyy()
    {
        if(ClickerScrr.num >= cost && now_upgrade < max_upgrade)
        {
            ClickerScrr.chair_power -= decrease_multiply;
            ChangeParametrs();
        }
    }
    // покупка любого апгрейда, который приносит пассивный доход
    public void BuyyPasive()
    {
        if(ClickerScrr.num >= cost && now_upgrade < max_upgrade)
        {
            ClickerScrr.passive_power += passive_power;
            ChangeParametrs();
        }
    }
    // повышение уровня стула
    public void BuyyChairLvl()
    {
        if(ClickerScrr.num >= cost && now_upgrade < max_upgrade)
        {
            ClickerScrr.chair_multiply *= 10;
            ClickerScrr.chair_real_power *= 2;
            ClickerScrr.chair_power = ClickerScrr.chair_real_power;

            buyscr.now_upgrade = 0;
            buyscr.decrease_multiply *= 2;

            ChangeParametrs();
            buyscr.cost_text.text = buyscr.cost.ToString();
        }
    }
    // изменение параметров после апгрейда
    void ChangeParametrs()
    {
        ClickerScrr.num -= (int)Mathf.Round(cost);
        cost = Mathf.Round(cost * multiply);
        cost_text.text = cost.ToString();
        ClickerScrr.textNum.text = ClickerScrr.num.ToString();
        now_upgrade++;
        if (now_upgrade >= max_upgrade)
        {
            cost_text.text = "Max";
        }
    }
}
