using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_ : MonoBehaviour
{

    CanvasGroup alphaCom;
    [Range(0.1f, 2)]
    public float speed;




    private void Start()
    {
        alphaCom = transform.GetChild(0).GetComponent<CanvasGroup>();
        alphaCom.alpha = 0;

        StartCoroutine("FadeOut");
    }




    private void Update()
    {
        transform.LookAt(FindObjectOfType<Pvr_UnitySDKManager>().transform);
    }



    IEnumerator FadeOut()
    {
        while (alphaCom.alpha != 1)
        {
            alphaCom.alpha += Time.deltaTime / speed;
            yield return null;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)  alphaCom.transform.GetChild(0).gameObject.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex == 1) alphaCom.transform.GetChild(0).gameObject.SetActive(true);
        yield break;

    }


    public void StartFadeIn() { StartCoroutine("FadeIn"); }
    private IEnumerator FadeIn()
    {
        while (alphaCom.alpha != 0)
        {
            alphaCom.alpha -= Time.deltaTime / speed;
            yield return null;
        }

      
        if (SceneManager.GetActiveScene().buildIndex == 1)//开始spawnMonster
        {
            FindObjectOfType<AudioListener>().transform.Find("PlayerCanvas").gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
            
        yield break;

    }


    public void NewGame() {

        SceneManager.LoadSceneAsync(0);
    }

}
