using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_obj : MonoBehaviour
{
    public GameObject obj_01;
    void OnMouseUp() //������� ����� �����
    {
        obj_01 = GameObject.Find("Cube");  //����� ���� ������� � �������� ���� ������ ����. ������ ������ ���� �������� ����� ����� (��� ������ ��� ���� �� ����(:)
        var cubeRenderer = obj_01.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
    }

}