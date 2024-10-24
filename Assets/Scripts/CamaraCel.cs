using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraCel : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rotFix;

    void Start()
    {
        // Verificar si el dispositivo tiene giroscopio
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            // Habilitar el giroscopio
            gyro = Input.gyro;
            gyro.enabled = true;

            // Ajuste de rotación para convertir las coordenadas del giroscopio al sistema de coordenadas de Unity
            rotFix = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    void Update()
    {
        if (gyroEnabled)
        {
            // Obtener la rotación del giroscopio y aplicarla a la cámara
            transform.localRotation = gyro.attitude * rotFix;
        }
    }
    /*
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rotFix;
    private Quaternion initialRotation;

    void Start()
    {
        // Verificar si el dispositivo tiene giroscopio y habilitarlo
        gyroEnabled = EnableGyro();

        // Ajustar la rotación inicial para que coincida con la orientación inicial del celular
        if (gyroEnabled)
        {
            initialRotation = Input.gyro.attitude;
        }
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            // Ajuste de rotación para convertir las coordenadas del giroscopio al sistema de coordenadas de Unity
            rotFix = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    void Update()
    {
        if (gyroEnabled)
        {
            // Calcular la diferencia desde la orientación inicial para ajustar la cámara
            Quaternion gyroRotation = Input.gyro.attitude;
            gyroRotation = new Quaternion(gyroRotation.x, gyroRotation.y, -gyroRotation.z, -gyroRotation.w);

            // Aplicar la calibración inicial
            transform.localRotation = Quaternion.Inverse(initialRotation) * gyroRotation * rotFix;
        }
    }*/
}
