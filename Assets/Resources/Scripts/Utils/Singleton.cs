using UnityEngine;

/// <summary>
/// A static instance which overrides the current instance when updated.
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour{
    public static T Instance {get;private set;}
    protected virtual void Awake() => Instance = this as T;
    protected virtual void OnApplicationQuit() {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// Basic singleton, will destroy any new versions created
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour{
    protected override void Awake(){
        if(Instance) Destroy(gameObject);
        base.Awake();
    }
}

/// <summary>
/// A static instance which overrides the current instance when updated. Object is not destroyed between scenes
/// </summary>
public abstract class StaticPersistentSingleton<T> : StaticInstance<T> where T : MonoBehaviour{
    protected override void Awake(){
        if(Instance) Destroy(gameObject);
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}

/// <summary>
/// A singleton which is allowed to transition between scenes
/// </summary>
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
