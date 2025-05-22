using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;
public class H2OTxt : MonoBehaviour
{
    public TextMeshProUGUI[] Correcttxt;
    public GameObject[] CorrectUI;
    public CheckButton checkButton;

    public void UpdateText()
    {
        int i = checkButton.currentProblemIndex;

        if (i == 0)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\n2H<sub>2</sub> +  O<sub>2</sub> → 2H<sub>2</sub>O";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 1)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "\r\n화학 반응식을 완성했습니다!\r\nC +  O<sub>2</sub> →CO<sub>2</sub>";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 2)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\n2Na + Cl<sub>2</sub> → 2NaCl";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 3)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\n2Mg + O<sub>2</sub> → 2MgO\r\n";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 4)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\nSi + O<sub>2</sub> → SiO<sub>2</sub>";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 5)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\nCH<sub>4</sub> + 2O<sub>2</sub> → CO<sub>2</sub> + 2H<sub>2</sub>O";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 6)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "\"화학 반응식을 완성했습니다!\\r\\n2Al + 3Cl<sub>2</sub> → 2AlCl<sub>3</sub>\"";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 7)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\nH<sub>2</sub> + Cl<sub>2</sub> → 2HCl\r\n";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 8)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\n2Li + Cl<sub>2</sub> → 2LiCl\r\n";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 9)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\n2Na + F<sub>2</sub> → 2NaF";
                Correcttxt[i].color = Color.green;
            }
        }
        else if (i == 10)
        {
            if (CorrectUI[i].activeSelf)
            {
                Correcttxt[i].text = "화학 반응식을 완성했습니다!\r\nCa + F<sub>2</sub> → CaF<sub>2</sub>\r\n";
                Correcttxt[i].color = Color.green; ;
            }
        }
    }
  
}
