using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyMainMenu : MonoBehaviour
{
    public GameObject loadindPanel;
    public Image fillBar;


    // Start is called before the first frame update
    private void Start()
    {
        if (GAManager.Instance) GAManager.Instance.LogDesignEvent("Scene:" + SceneManager.GetActiveScene().name + SceneManager.GetActiveScene().buildIndex);
    }
    public void Play(string str)
    {
        loadindPanel.SetActive(true);
        StartCoroutine(loadScene(str));
    }
    IEnumerator loadScene(string str)
    {
        fillBar.fillAmount = 0;
        while(fillBar.fillAmount < 1)
        {
            fillBar.fillAmount += Time.deltaTime/ 4;
            yield return null;
        }
        SceneManager.LoadScene(str);
    }
}
