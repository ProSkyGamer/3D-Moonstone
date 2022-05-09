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
    private float timer=1;
    private bool load;
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadlevel);
        asyncLoad.allowSceneActivation = false;
        while(!asyncLoad.isDone)
        {
            progress_bar.value = asyncLoad.progress;

            if(asyncLoad.progress>=.9f)
            {
                if(!text_after.activeSelf)
                {
                    text_before.SetActive(false);
                    text_after.SetActive(true);
                }
                if (!asyncLoad.allowSceneActivation)
                {
                    if (!load && Input.anyKey)
                        load = true;
                    if(timer>=0)
                        timer -= Time.deltaTime;
                    else
                    {
                        if (load || Input.anyKeyDown)
                        {
                            asyncLoad.allowSceneActivation = true;
                            load = false;
                        }
                    }
                }
            }
            yield return null;
        }
    }
}
