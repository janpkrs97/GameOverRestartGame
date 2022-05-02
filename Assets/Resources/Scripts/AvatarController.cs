using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public int avatarID = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetAvatarID(int id)
    {
        avatarID = id;
        Debug.Log("selected avatar: " + avatarID);
    }
}
