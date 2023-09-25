using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    [SerializeField] Toggle[] m_toggles = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    string[] m_fruits = { "���", "��", "������" };

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(Onclicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        for (int i = 0; i < m_toggles.Length; i++)
        {
            m_toggles[i].onValueChanged.AddListener(OnValueChanged_Fruit);
        }
    }

    void Onclicked_Ok()
    {
        if(CheckToggle())
        {
            m_txtResult.text = "�ƹ��͵� ���õ��� �ʾҽ��ϴ�.";
            return;
        }

        string str = $"����� ������ ������ {GetFruits()}�Դϴ�.";

        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "�ʱ�ȭ";

        for (int i = 0; i < m_toggles.Length; i++)
        {
            m_toggles[i].isOn = false;
        }
    }

    void OnValueChanged_Fruit(bool isOn)
    {
        m_txtResult.text = GetFruits();
    }

    string GetFruits()
    {
        string str = "";

        for (int i = 0; i < m_toggles.Length; i++)
        {
            if (m_toggles[i].isOn)
                str += $"{m_fruits[i]} ";
        }

        return str;
    }

    bool CheckToggle()
    {
        for (int i = 0; i < m_toggles.Length; i++)
        {
            if (m_toggles[i].isOn)
                return false;
        }

        return true;
    }
}
