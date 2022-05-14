using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarController : MonoBehaviour
{
    public int avatarID = 0;

    public GameObject[] teachers;

    public bool spawnedAvatarNewScene;

    public Transform spawnLocMenu;
    public Transform spawnLocStandard;
    public Transform spawnLocGroups;


    void Awake()
    {
        DontDestroyOnLoad(this);
        spawnedAvatarNewScene = false;
        SetupSpawnLocations();
    }

    void SetupSpawnLocations()
    {
        // Menu
        spawnLocMenu.position = new Vector3(0f, 0f, 0);
        spawnLocMenu.Rotate(0f, 90f, 0f);

        // Standard
        spawnLocStandard.position = new Vector3(1.75f, 0f, 0.75f);
        spawnLocStandard.Rotate(0f, 270f, 0f);

        // Groups
        spawnLocGroups.position = new Vector3(1.5f, 0f, 0.75f);
        spawnLocGroups.Rotate(0f, 270f, 0f);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Standard" && !spawnedAvatarNewScene)
        {
            Instantiate(teachers[avatarID - 1], spawnLocStandard.position, spawnLocStandard.rotation);
            Debug.Log("Spawned avatar " + avatarID + " into standard scene");
            spawnedAvatarNewScene = true;
        }
        else if (SceneManager.GetActiveScene().name == "Groups" && !spawnedAvatarNewScene)
        {
            Instantiate(teachers[avatarID - 1], spawnLocGroups.position, spawnLocGroups.rotation);
            Debug.Log("Spawned avatar " + avatarID + " into groups scene");
            spawnedAvatarNewScene = true;
        }
    }

    public void SetAvatarID(int id)
    {
        avatarID = id;
        Debug.Log("selected avatar: " + avatarID);
        Instantiate(teachers[id -1], spawnLocMenu.position, spawnLocMenu.rotation);
    }
}
