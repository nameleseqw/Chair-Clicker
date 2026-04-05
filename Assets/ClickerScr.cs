using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class clicker : MonoBehaviour
{
    public int num; // количество сделанных стульев 
    public int now; // количество кликов
    public Text textNum; // текст, отображающий количество сделанных стульев

    public int click_power; // сила клика(наврятли будем юзать)
    public int chair_power; // сила стула(то, сколько кликов надо сделать, чтобы сделать один стул)
    public int chair_real_power; // переменная, которая обозначает силу стула без учета прокачки навыка "ремесло"

    public int passive_power; // пассивная сила - то, сколько стульев будет получать игрок в секнуду
    public int chair_multiply; // количество стульев, которое игрок получит при создании одного(например табурет - 1, а трон - 100000)

    public Text passive_chairs_text; // текст, отображающий пассивный доход 

    void Start()
    {
        StartCoroutine(DoSomethingEverySecond());
    }
    // функция, вызываемая при клике
    public void addNum()
    {
        now = now + click_power;     
    }
    void Update()
    {   
        passive_chairs_text.text = passive_power.ToString() + "/s";
        // при наборе определенного количества кликов chair_power получаем количество стульев chair_multiply
        if(chair_power <= now)
        {
            now = 0;
            num += chair_multiply;
        }
        textNum.text = num.ToString();
    }
    // корутин, который раз в секунду вносит на счет стулья за все пассивные доходы 
    IEnumerator DoSomethingEverySecond()
    {
        while (true)
        {
            num += passive_power;
            yield return new WaitForSeconds(1f);
        }
    }
}