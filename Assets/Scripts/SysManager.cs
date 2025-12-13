using System.Data.Common;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public struct Usuario {
  string nombre;
  int dia_nacimiento;
  int mes_nacimiento;
  int ano_naciemiento;
  string ciudad_nacimeinto;
  int puntuacion;
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
        usuario.nombre = "";
        usuario.dia_nacimiento = -1;
        usuario.mes_nacimiento = -1;
        usuario.ano_naciemiento = -1;
        usuario.ciudad_nacimeinto ="";
        usuario.puntuacion = 0;
    }
}
