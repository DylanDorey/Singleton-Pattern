using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/01/2024]
 * [Demonstration of Singletons as a generic]
 */

public class Singleton<T> : MonoBehaviour where T :Component
{
    //private static intance of class as T
    private static T _instance;

    //public property for the instance of the class
    public static T Instance
    {
        get
        {
            //if the private instance is empty/null
            if (_instance == null)
            {
                //find any object that is of the same type as passed in T class
                _instance = FindObjectOfType<T>();

                //if the instance is still empty/null (couldn't be found)
                if(_instance == null)
                {
                    //create a new object of that time and store it as the instance
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }

            //return the instance found or created
            return _instance;
        }
    }

    public virtual void Awake()
    {
        //if the private instance is empty/null (only instance of class)
        if (_instance == null)
        {
            //set this as the component in private instance
            _instance = this as T;

            //dont destroy this game object on load
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //otherwise if there is already an instance in the scene, destroy this duplicate instance
            Destroy(gameObject);
        }
    }
}
