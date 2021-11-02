using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;

    private void Start() 
    {
        sceneLoader.LoadFirstLevel();    
    }
}
