using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AynseLoading : MonoBehaviour {
    UISlider slider;
    AsyncOperation asyncOperation;
	// Use this for initialization
	void Start () {
        slider = GetComponent<UISlider>();
        StartCoroutine(LoadRound(GameLevel.roundName));
	}
	
    IEnumerator LoadRound(string scenceName)
    {
        asyncOperation = SceneManager.LoadSceneAsync(scenceName);
        asyncOperation.allowSceneActivation = false;
        yield return asyncOperation;
    }


    // Update is called once per frame
    void Update () {
        print(slider.value+"--"+asyncOperation.progress);
        if (slider.value <= 0.9f)
        {
            slider.value +=Time.deltaTime;
        }
        if (asyncOperation.progress==0.9f)
        {
            slider.value += Time.deltaTime*0.8f;
            if (slider.value == 1)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}
