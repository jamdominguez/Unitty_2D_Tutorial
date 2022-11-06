using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour    
{
    public static GameManager gameManager;

    private int totalEnemiesDefeat = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null) {
            gameManager = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }

        SceneManager.LoadScene("SceneName");
    }

    public void AddEnemiesDefeat(int newEnemiesDefeat) {
        totalEnemiesDefeat += newEnemiesDefeat;
        Debug.Log("newEnemiesDefeat:" + newEnemiesDefeat + " totalEnemiesDefeat:" + totalEnemiesDefeat);
    }
}
