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
    [HideInInspector]
    public Text TextTipo;
    [HideInInspector]
    public Text TextNombre;
    [HideInInspector]
    public Text TextDescripcion;
    [HideInInspector]
    public GameObject panel;

    private void Start() {
        panel = GameObject.Find("PanelInfoObject");
        TextNombre = panel.transform.GetChild(0).GetComponent<Text>();
        TextTipo = panel.transform.GetChild(1).GetComponent<Text>();
        TextDescripcion = panel.transform.GetChild(2).GetComponent<Text>();
    }

    public void OnPointerEnter (PointerEventData eventData) 
	{
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
        panel.GetComponent<Image>().enabled = false;
        TextTipo.enabled = false;
        TextNombre.enabled = false;
        TextDescripcion.enabled = false;
    }
    
}
