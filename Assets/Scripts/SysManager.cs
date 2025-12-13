using System.Data.Common;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public struct Usuario {

  public int puntuacion;
}

public class SysManager : MonoBehaviour
{
    public static SysManager Instance;
    public Usuario usuario;
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
