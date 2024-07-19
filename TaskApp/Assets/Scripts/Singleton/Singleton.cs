
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
    where T : class
{
    private static T _instance;
    protected virtual void Awake()
    {
        if(_instance != null)
        {
            Debug.LogError($"{gameObject.name} singleton уже есть на сцене!");
            Destroy(gameObject);
        }
        else
        {
            _instance = (this as T);
        }
    }

    public static T Instance() => _instance;

}
