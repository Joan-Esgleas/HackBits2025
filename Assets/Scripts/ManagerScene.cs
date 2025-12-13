using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{    
    [Header("Scene Settings")]

    private GameObject sysmanagerPrefab;
    private SysManager sysmanager;
    
    private void Start()
    {
       sysmanager = FindAnyObjectByType<SysManager>();
        if(managerGame == null) {
            GameObject.Instantiate(sysmanagerPrefab);
            managerGame = sysmanagerPrefab.GetComponent<SysManager>();
        }
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    
    public void checkDiaCumpleanos(int d) {
      if(d == sysmanager.usuario.dia_nacimiento)
        sysmanager.puntuacion++;
    }

    public void checkMesCumpleanos(int m) {
      if(m == sysmanager.usuario.mes_nacimiento)
        sysmanager.puntuacion++;
    }

    public void checkAnoCumpleanos(int a) {
      if(a == sysmanager.usuario.ano_naciemiento)
        sysmanager.puntuacion++;
    }

    public void checkNombre(string n) {
      if(n == sysmanager.usuario.nombre)
        sysmanager.puntuacion++;
    }

    public void checkNombreCiudad(string c) {
      if(n == sysmanager.usuario.ciudad_nacimeinto)
        sysmanager.puntuacion++;
    }

    private void Update()
    {
    }
    
}
