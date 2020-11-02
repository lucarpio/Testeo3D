using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;

public class RegisterScript : MonoBehaviour
{

    Conexion c = new Conexion();

    // Variables que obtendrán los datos de la GUI
    
    [SerializeField] private GameObject m_interfazloginUI = null;
    [SerializeField] private GameObject m_interfazregistrarUI = null;
    public InputField nombre;
    public InputField apellidopaterno;
    public InputField apellidomaterno;
    public InputField fechanacimiento;
    public InputField pais;
    public InputField correo;
    public InputField contraseña;
    public InputField confcontraseña;

    // Botones

    public Button btnCrearCuenta;
    public Button btnIniciarSesion;

    // Variables Privadas

    private string Nombre;
    private string Apellidopaterno;
    private string Apellidomaterno;
    private string Fechanacimiento;
    private string Pais;
    private string Correo;
    private string Contraseña;
    private string Confcontraseña;
    private string Usuario;
    private bool ConfCorreo = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener datos de la GUI

        TomarDatos();

        // Escuchar clic de botones

        btnCrearCuenta.onClick.AddListener(CrearCuenta);
        btnIniciarSesion.onClick.AddListener(irIniciarSesion);

    }

    public void CrearCuenta()
    {
        
        

        // Validación



        if(Nombre!=""&&Apellidopaterno!=""&&Apellidomaterno!=""&&Fechanacimiento!=""&&Pais!=""&&Correo!=""&&Contraseña!=""&&Confcontraseña!="")
        {
            // Pasa id? Duda
            c.CrearCuenta(Nombre,Apellidopaterno,Apellidomaterno,Fechanacimiento,Pais,Correo,Contraseña);
            //print("Creación de cuenta exitosa");
            LimpiarCampos();
        }else{
            print("Error en la creación de cuenta");
        }        
    }

    private void irIniciarSesion()
    {
        //  No Mostrar vista Registrar y Mostrar vista Login 
        
        m_interfazregistrarUI.SetActive(false);
        m_interfazloginUI.SetActive(true);
        LimpiarCampos();

    }

    public void LimpiarCampos()
    {
        nombre.GetComponent<InputField>().text = "";
        apellidopaterno.GetComponent<InputField>().text = "";
        apellidomaterno.GetComponent<InputField>().text = "";
        fechanacimiento.GetComponent<InputField>().text = "";
        pais.GetComponent<InputField>().text = "";
        correo.GetComponent<InputField>().text = "";
        contraseña.GetComponent<InputField>().text = "";
        confcontraseña.GetComponent<InputField>().text = "";
    }

    public void TomarDatos()
    {
        Nombre = nombre.GetComponent<InputField>().text;
        Apellidopaterno = apellidopaterno.GetComponent<InputField>().text;
        Apellidomaterno = apellidomaterno.GetComponent<InputField>().text;
        Fechanacimiento = fechanacimiento.GetComponent<InputField>().text;
        Pais = pais.GetComponent<InputField>().text;
        Correo = correo.GetComponent<InputField>().text;
        Contraseña = contraseña.GetComponent<InputField>().text;
        Confcontraseña = confcontraseña.GetComponent<InputField>().text;
    }
    
}
