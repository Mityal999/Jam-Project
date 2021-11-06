using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_obj : MonoBehaviour
{
    public GameObject obj_01;
    void OnMouseUp() //функция клика мышью
    {
        obj_01 = GameObject.Find("Cube");  //выбор того объекта у которого надо сменит цвет. дальше должен идти алгоритм смены цвета (как менять сам цвет не знаю(:)
        var cubeRenderer = obj_01.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
    }

}