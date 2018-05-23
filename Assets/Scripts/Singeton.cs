using UnityEngine;

public class Singleton<T>: MonoBehaviour where T:MonoBehaviour 
{
    private static T m_instance;
    private static readonly object sync = new object();
    protected Singleton() { }

    /// <summary>
    /// 用法：SingletonProvider<myclass>.Instance 获取该类的单例 
    /// </summary>
    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (sync)
                {
                    m_instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopening the scene might fix it.");
                        return m_instance;
                    }

                    if (m_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        m_instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);

                        Debug.Log("[Singleton] An instance of " + typeof(T) +
                            " is needed in the scene, so '" + singleton +
                            "' was created with DontDestroyOnLoad.");
                    }
                }
            }
            return m_instance;
        }
    }

    
}