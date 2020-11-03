using UnityEngine;

namespace SharedLibrary.Unity.Singleton
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T singleton;

        protected virtual void Awake()
        {
            if (singleton == null)
                singleton = (T)FindObjectOfType(typeof(T));
            else
                Destroy(gameObject);
        }

    }

    public class SingletonDontDestroy<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T singleton;

        protected virtual void Awake()
        {
            if (singleton == null)
            {
                singleton = (T)FindObjectOfType(typeof(T));
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

    }

}
