using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarController : MonoBehaviour
{
    public int locomotionID = 0;
    public int avatarID = 0;


    public GameObject[] teachersTel;
    public GameObject[] teachersRDW;

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
        //spawnLocMenu.position = new Vector3(0f, 0f, 0);

        // Standard
        //spawnLocStandard.position = new Vector3(1.75f, 0f, 0.75f);
        //spawnLocStandard.Rotate(0f, 270f, 0f);

        // Groups
        //spawnLocGroups.position = new Vector3(1.5f, 0f, 0.75f);
        //spawnLocGroups.Rotate(0f, 270f, 0f);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Standard" && !spawnedAvatarNewScene)
        {
            if (locomotionID == 1)
            {
                Instantiate(teachersTel[avatarID - 1], spawnLocStandard.position, spawnLocStandard.rotation);
                Debug.Log("Spawned avatar " + avatarID + " into standard scene with locomotion " + locomotionID);
                spawnedAvatarNewScene = true;
            }
            else
            {
                Instantiate(teachersRDW[avatarID - 1], spawnLocStandard.position, spawnLocStandard.rotation);
                Debug.Log("Spawned avatar " + avatarID + " into standard scene with locomotion " + locomotionID);
                spawnedAvatarNewScene = true;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Groups" && !spawnedAvatarNewScene)
        {
            if (locomotionID == 1)
            {
                Instantiate(teachersTel[avatarID - 1], spawnLocGroups.position, spawnLocGroups.rotation);
                Debug.Log("Spawned avatar " + avatarID + " into groups scene with locomotion " + locomotionID);
                spawnedAvatarNewScene = true;
            }
            else
            {
                Instantiate(teachersRDW[avatarID - 1], spawnLocGroups.position, spawnLocGroups.rotation);
                Debug.Log("Spawned avatar " + avatarID + " into groups scene with locomotion " + locomotionID);
                spawnedAvatarNewScene = true;
            }
        }
    }

    public void SetAvatarID(int id)
    {
        avatarID = id;
        Debug.Log("selected avatar: " + avatarID);
        Instantiate(teachersTel[id -1], spawnLocMenu.position, spawnLocMenu.rotation);
    }

    public void SetLocomotionID(int id)
    {
        locomotionID = id;
        Debug.Log("selected locomotion system: " + locomotionID);
    }
}
