using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{

    [SerializeField] private string loadlevel;

    public Slider progress_bar;

    public GameObject text_before;
    public GameObject text_after;
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadlevel);
        asyncLoad.allowSceneActivation = false;
        if(asyncLoad.progress >= .9f)
        {
            text_before.SetActive(false);
            text_after.SetActive(true);
        }
        while(!asyncLoad.isDone)
        {
            progress_bar.value = asyncLoad.progress;

            if(asyncLoad.progress>=.9f && !asyncLoad.allowSceneActivation)
            {
                if(Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
