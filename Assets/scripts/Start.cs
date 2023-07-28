using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    public Animator fadeOutAnimator;
    public int scene;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            fadeOutAnimator.SetTrigger("Fade");
            StartCoroutine(ChangeScene());
        }
    }
    IEnumerator ChangeScene() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(scene);
    }
}
