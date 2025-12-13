using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Respuesta
{
    public string[] respuestasEsperadas;
    public TMP_InputField inputField;
}

public class ManagerScene : MonoBehaviour
{    
    [Header("Scene Settings")]
    [SerializeField]
    private GameObject sysmanagerPrefab;
    private SysManager sysmanager;

    [Space (10)]
    [Header("Input Field")]
    [SerializeField]
    TMP_InputField dia_inputField;
    [SerializeField]
    TMP_InputField mes_inputField;
    [SerializeField]
    TMP_InputField ano_inputField;


    [Space(10)]
    [Header("Respuesta Settings")]
    [SerializeField]
    List<Respuesta> respuestas;

    private void Start()
    {
       sysmanager = FindAnyObjectByType<SysManager>();
        if(sysmanager == null) {
            GameObject.Instantiate(sysmanagerPrefab);
            sysmanager = sysmanagerPrefab.GetComponent<SysManager>();
        }
        if (dia_inputField != null) dia_inputField.onSubmit.AddListener(delegate { GetDia(); });
        if (mes_inputField != null) mes_inputField.onSubmit.AddListener(delegate { GetMes(); });
        if (ano_inputField != null) ano_inputField.onSubmit.AddListener(delegate { GetAno(); });
        foreach (Respuesta r in respuestas) {
            r.inputField.onSubmit.AddListener(delegate { CheckRespuesta(r); });
        }
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    bool checkDay(string s)
    {
        DateTime dt = DateTime.Now;
        string day_eng = dt.DayOfWeek.ToString();
        if (s == "Lunes" && day_eng == "Monday") return true;
        if (s == "Martes" && day_eng == "Tuesday") return true;
        if (s == "Miércoles" && day_eng == "Wednesday") return true;
        if (s == "Jueves" && day_eng == "Thursday") return true;
        if (s == "Viernes" && day_eng == "Friday") return true;
        if (s == "Sábado" && day_eng == "Saturday") return true;
        if (s == "Domingo" && day_eng == "Sunday") return true;
        return false;

    }
    public void GetDia() {
        string s = dia_inputField.text;
        if (checkDay(s))
        {
            AddPuntuacion();
        }
    }

    public void GetMes() {
        string d_str = mes_inputField.text;
        int d = int.Parse(d_str);
        if(d.ToString() == DateTime.Now.Month.ToString()) AddPuntuacion();

    }

    public void GetAno() {
        string d_str = ano_inputField.text;
        int d = int.Parse(d_str);
        if (d.ToString() == DateTime.Now.Year.ToString()) AddPuntuacion();
    }

    public void CheckRespuesta(Respuesta r)
    {
        foreach(string respuestaE in r.respuestasEsperadas)
        {
            if (r.inputField.text == respuestaE)
            {
                AddPuntuacion();            }
        }
       
    }
    public void AddPuntuacion()
    {
        sysmanager.usuario.puntuacion++;
    }

    public void AddPuntuacion(int n)
    {
        sysmanager.usuario.puntuacion += n;
    }


    private void Update()
    {

    }
    
}
