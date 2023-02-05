using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject gameObjectA;
    public Text LoadingText;
    float percentage;

    /* Change the panels*/
    public GameObject gpanel;
    public GameObject[] _myPanel;


    void Start()
    {
        _myPanel = new GameObject[3];
        gpanel = GameObject.Find("Canvas");
        for(int i = 0; i < 3; i++)
        {
            _myPanel[i] = gpanel.transform.GetChild(i).gameObject;
        }

        ActivatePanel(0);
        DeactivatePanel(1);
        DeactivatePanel(2);
    }

   public void LoadScene(int num)
   {
        StartCoroutine(LoadAsync(num));
   }
   public void QuitGame()
   {
        Application.Quit();
   }

   IEnumerator LoadAsync(int num)
   {
        gameObjectA.SetActive(true);
        AsyncOperation aOp = SceneManager.LoadSceneAsync(num);
        while(aOp.isDone == false)
        {
            LoadingText.text = "Loading... " + percentage + "%";
            yield return null;
        }
   }

   public void LoadPanel(int num)
   {
        for(int i = 0; i < 3; i++)
        {
            if(i != num)
            {
                DeactivatePanel(i);
            }
            else
            {
                ActivatePanel(i);
            }
        }
   }

   public void ActivatePanel(int num)
   {

        _myPanel[num].GetComponent<CanvasGroup>().alpha = 1f;
        _myPanel[num].GetComponent<CanvasGroup>().interactable = true;
        _myPanel[num].GetComponent<CanvasGroup>().blocksRaycasts = true;
        

   }

   public void DeactivatePanel(int num)
   {
        _myPanel[num].GetComponent<CanvasGroup>().alpha = 0;
        _myPanel[num].GetComponent<CanvasGroup>().interactable = false;
        _myPanel[num].GetComponent<CanvasGroup>().blocksRaycasts = false;

   }
}
