using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour {



    public Text textCom;
    public string fileText;
    [Range(0.1f, 1)]
    public float speed;
    private void Start()
    {
        textCom.text = null;
        StartCoroutine("enumerator");
    }




    IEnumerator enumerator() {

        foreach (var st in fileText.ToCharArray())
        {
            textCom.text += st;
           
            yield return new WaitForSeconds(speed);
        }

        transform.parent.parent.Find("Button").gameObject.SetActive(true);
        yield break;

    }

}
