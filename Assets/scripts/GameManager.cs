using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this; 
            DontDestroyOnLoad(this);
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator ChangeScene(int scene, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
