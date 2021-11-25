using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    public Image HP;
    public int score;
    public Text scoreCom;
    [Range(0,100)]
    public int blood;
    public GameObject overCanvas;
    private void Start()
    {
        blood = 100;
    }


    private void Update()
    {
       

        scoreCom.text = "Score:" + score.ToString("00");
        HP.fillAmount = (float)blood / 100;



        if (score>=30)
        {
            

            overCanvas.SetActive(true);
            overCanvas.GetComponentInChildren<TypingText>().fileText = score + "/30 恭喜你，完成了挑战，你真厉害！";
        }

        if (blood <= 0) {

           

            overCanvas.SetActive(true);
            overCanvas.GetComponentInChildren<TypingText>().fileText = score + "/30 很遗憾，你没能完成挑战！";
        }


    }

}
