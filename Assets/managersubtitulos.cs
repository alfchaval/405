using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managersubtitulos : MonoBehaviour {

    public Text textoSubtitulo;

    public void escribirDurante(int retraso,string mensaje)
    {
        CancelInvoke();
        textoSubtitulo.fontStyle = FontStyle.Normal;
        textoSubtitulo.text = mensaje;
        Invoke("BorrarSubtitulo", retraso);
    }

    public void escribirDurante(int retraso, string mensaje, bool cursiva)
    {
        CancelInvoke();
        textoSubtitulo.fontStyle = FontStyle.Normal;
        if (cursiva)
        {
            textoSubtitulo.fontStyle = FontStyle.Italic;
            textoSubtitulo.text = mensaje;
            Invoke("BorrarSubtitulo", retraso);
        }
        else
        {
            textoSubtitulo.GetComponent<Text>().text = mensaje;
            Invoke("BorrarSubtitulo", retraso);
        }
       
    }
    public void escribirDurante(string mensaje, bool cursiva)//para mensajes que van seguidos de un invoke que lleva a otro mensaje
    {
        if (cursiva)
        {
            textoSubtitulo.fontStyle = FontStyle.Italic;
            textoSubtitulo.text = mensaje;
        }
        else
        {
            textoSubtitulo.text = mensaje;
        }
    }

    public void BorrarSubtitulo()
    {
        textoSubtitulo.text = " ";
        textoSubtitulo.fontStyle = FontStyle.Normal;
    }
}
