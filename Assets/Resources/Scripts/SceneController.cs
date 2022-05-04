using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeScene(int classID)
    {
        if (classID == 1)
        {
            SceneManager.LoadScene("Standard");
        }
        else if (classID == 2)
        {
            SceneManager.LoadScene("Round");
        }
        else
        {
            SceneManager.LoadScene("Standard");
        }
    }
}
