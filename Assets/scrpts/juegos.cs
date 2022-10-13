using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class juegos : MonoBehaviour
{

    public Text nombredisplay;
    public Text puntosdisplay;
    public int record;
    public Text recordDisplay;
    public int puntajeactual;

    private void Awake()
    {
        if(DBManager.usuario == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        nombredisplay.text = "Player: " + DBManager.usuario;
        puntosdisplay.text = "Score: 0";
        recordDisplay.text = "Record: " + DBManager.resultado;
        record = DBManager.resultado;
    }

    public void CallSaveData()
    {
        if(puntajeactual > record)
        {
            DBManager.resultado = puntajeactual;
        }
        
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", DBManager.usuario);
        form.AddField("resultado", DBManager.resultado);

        WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("game saved");
        }
        else
        {
            Debug.Log("save failed. error #" + www.text);
        }

        DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        puntajeactual++;
        puntosdisplay.text = "Score: " + puntajeactual;
    }

}
