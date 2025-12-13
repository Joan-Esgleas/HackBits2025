using System.Data.Common;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

[System.Serializable]
public struct Usuario {
  public DateTime dt;
  public int puntuacion;
}

public class SysManager : MonoBehaviour
{
    public static SysManager Instance;
    public Usuario usuario;
    public List<Usuario> historial;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        usuario.puntuacion = 0;
    }
}
