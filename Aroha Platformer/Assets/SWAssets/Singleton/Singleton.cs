﻿using UnityEngine;

namespace SWAssets
{
    [RequireComponent(typeof(Initialization))]
    public abstract class Singleton<T> : MonoBehaviour
    {
        //Public Properties:
        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static T I
        {
            get
            {
                if (m_instance == null)
                {
                    Debug.LogWarning("Singleton not registered! Make sure the GameObject running your singleton is active in your scene and has an Initialization component attached.");
                    return default(T);
                }
                return m_instance;
            }
        }

        //Private Variables:
        [SerializeField] bool _dontDestroyOnLoad = false;
        static T m_instance;

        //Virtual Methods:
        /// <summary>
        /// Override this method to have code run when this singleton is initialized which is guaranteed to run before Awake and Start.
        /// </summary>
        protected virtual void OnRegistration()
        {
        }

        //Public Methods:
        /// <summary>
        /// Generic method that registers the singleton instance.
        /// </summary>
        public void RegisterSingleton(T instance)
        {
            m_instance = instance;
        }

        //Private Methods:
        protected void Initialize(T instance)
        {
            if (_dontDestroyOnLoad && m_instance != null)
            {
                //there is already an instance:
                Destroy(gameObject);
                return;
            }

            if (_dontDestroyOnLoad)
            {
                //don't destroy on load only works on root objects so let's force this transform to be a root object:
                transform.parent = null;
                DontDestroyOnLoad(gameObject);
            }

            m_instance = instance;
            OnRegistration();
        }
    }
}