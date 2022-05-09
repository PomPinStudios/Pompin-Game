using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MostrarInfoObjecto : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Tipo;
    public string Nombre;
    public string Descripcion;
    public Text TextTipo;
    public Text TextNombre;
    public Text TextDescripcion;
    public GameObject panel;

    private void Start() {
        TextTipo.text = Tipo;
        TextNombre.text = Nombre;
        TextDescripcion.text = Descripcion;
    }

    public void OnPointerEnter (PointerEventData eventData) 
	{
		Debug.Log ("The cursor entered the selectable UI element.");
        panel.SetActive(true);
	}

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element.");
        panel.SetActive(false);
    }
    
}
