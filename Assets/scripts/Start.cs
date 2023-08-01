using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Start : MonoBehaviour
{
    public Animator fadeOutAnimator;
    public int scene;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            fadeOutAnimator.SetTrigger("Fade");
            StartCoroutine(GameManager.gameManager.ChangeScene(scene, 5));
        }
    }
}
