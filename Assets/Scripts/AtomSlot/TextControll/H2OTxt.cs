using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class H2OTxt : MonoBehaviour
{
    public TextMeshProUGUI Correcttxt;
    public GameObject CorrectUI;

    private void Update()
    {
        if (CorrectUI.activeSelf)
        {
            Correcttxt.text = "���� ���� ������\r\n\r\n���� ���￡ �Ʒ� ���� ������ �÷�������\r\nH<sub>2</sub>  ,  O<sub>2</sub>\r\n������ ���￡ �Ʒ� ������ ������ �÷�������\r\nH<sub>2</sub>O\r\nȭ�� �������� �ϼ��ϼ���\r\n2H<sub>2</sub> +  O<sub>2</sub> �� 2H<sub>2</sub>O";
        }
       /* else
        {
            Correcttxt.text = "���� ���� ������\r\n\r\n���� ���￡ �Ʒ� ���� ������ �÷�������\r\nH<sub>2</sub>  ,  O<sub>2</sub>\r\n������ ���￡ �Ʒ� ������ ������ �÷�������\r\nH<sub>2</sub>O\r\nȭ�� �������� �ϼ��ϼ���\r\nH<sub>2</sub> +  O<sub>2</sub> �� H<sub>2</sub>O";
        }*/
    }



}
