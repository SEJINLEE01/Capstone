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
            Correcttxt.text = "물의 생성 반응식\r\n\r\n왼쪽 저울에 아래 반응 물질을 올려보세요\r\nH<sub>2</sub>  ,  O<sub>2</sub>\r\n오른쪽 저울에 아래 생성된 물질을 올려보세요\r\nH<sub>2</sub>O\r\n화학 반응식을 완성하세요\r\n2H<sub>2</sub> +  O<sub>2</sub> → 2H<sub>2</sub>O";
        }
       /* else
        {
            Correcttxt.text = "물의 생성 반응식\r\n\r\n왼쪽 저울에 아래 반응 물질을 올려보세요\r\nH<sub>2</sub>  ,  O<sub>2</sub>\r\n오른쪽 저울에 아래 생성된 물질을 올려보세요\r\nH<sub>2</sub>O\r\n화학 반응식을 완성하세요\r\nH<sub>2</sub> +  O<sub>2</sub> → H<sub>2</sub>O";
        }*/
    }



}
