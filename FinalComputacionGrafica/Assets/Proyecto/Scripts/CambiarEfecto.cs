using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CambiarEfecto : MonoBehaviour
{
    [SerializeField] public GameObject[] Efectos;

    [SerializeField] public GameObject director;    
    public int currenteffect;


    private void Awake()
    {
        foreach(GameObject obj in Efectos)
        {
            obj.SetActive(false);
        }
    }
    public void SeleccionarEfecto(int efecto)
    {
        currenteffect = efecto;
    }
    public void CambioDeEfecto()
    {
        if (currenteffect < 0 || currenteffect > Efectos.Length - 1) return;

        for (int i = 0; i < Efectos.Length; i++)
        {
           
            if(i == currenteffect)
            {
                Efectos[i].gameObject.SetActive(true); 
            }
            else
            {
                Efectos[i].SetActive(false);
            }
        }
        
    }

    public void Play()
    {
        director.GetComponent<PlayableDirector>().Play();
    }

    public void Pause()
    {
        director.GetComponent<PlayableDirector>().Pause();
    }

    public void ResetearTiempo()
    {
        director.GetComponent<PlayableDirector>().Stop();
    }
   

}
