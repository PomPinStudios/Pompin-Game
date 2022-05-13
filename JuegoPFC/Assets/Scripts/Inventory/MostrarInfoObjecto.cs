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
    private Text TextTipo;
    private Text TextNombre;
    private Text TextDescripcion;
    private GameObject panel;

    private void Start() {
        panel = GameObject.Find("PanelInfoObject");
        TextNombre = panel.transform.GetChild(0).GetComponent<Text>();
        TextTipo = panel.transform.GetChild(1).GetComponent<Text>();
        TextDescripcion = panel.transform.GetChild(2).GetComponent<Text>();
        // TextTipo.text = Tipo;
        // TextNombre.text = Nombre;
        // TextDescripcion.text = Descripcion;
    }

    public void OnPointerEnter (PointerEventData eventData) 
	{
		Debug.Log ("The cursor entered the selectable UI element.");
        // panel.SetActive(true);
        TextTipo.text = Tipo;
        TextNombre.text = Nombre;
        TextDescripcion.text = Descripcion;
        TextTipo.enabled = true;
        TextNombre.enabled = true;
        TextDescripcion.enabled = true;
        panel.GetComponent<Image>().enabled = true;
	}

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element.");
        // panel.SetActive(false);
        panel.GetComponent<Image>().enabled = false;
        TextTipo.enabled = false;
        TextNombre.enabled = false;
        TextDescripcion.enabled = false;
    }
    
}
