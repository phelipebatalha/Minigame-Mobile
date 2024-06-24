using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSingleton : MonoBehaviour
{
    public static MenuSingleton Pivot;
    void Awake()
    {
        if(Pivot == null)
        Pivot = this;
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
