using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarController : MonoBehaviour
{
    public int avatarID = 0;

    public GameObject[] teachers;

    public bool spawnedAvatarNewScene;

    public Transform spawnLoc1;

    void Awake()
    {
        DontDestroyOnLoad(this);
        spawnedAvatarNewScene = false;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu" && !spawnedAvatarNewScene)
        {
            Instantiate(teachers[avatarID - 1], new Vector3(2f, 0f, 1.5f), Quaternion.identity);
            Debug.Log("Spawned avatar " + avatarID + "into new scene");
            spawnedAvatarNewScene = true;
        }
    }

    public void SetAvatarID(int id)
    {
        avatarID = id;
        Debug.Log("selected avatar: " + avatarID);
        Instantiate(teachers[id -1], new Vector3(0f, 0f, 0f), spawnLoc1.rotation);
    }
}
