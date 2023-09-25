using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    [SerializeField] Toggle[] m_toggles = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    string[] m_fruits = { "���", "��", "������" };
    int m_curIdx = 0;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        for (int i = 0; i < m_toggles.Length; i++)
        {
            int idx = i;
            m_toggles[i].onValueChanged.AddListener((bool isOn) => OnValueChanged_Fruit(isOn, idx));
        }
    }

    void OnClicked_Ok()
    {
        string str = $"����� ������ ������ {m_fruits[m_curIdx]} �Դϴ�.";
        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        for (int i = 0; i < m_toggles.Length; i++)
        {
            m_toggles[i].isOn = false;
        }
        m_txtResult.text = "�ʱ�ȭ";
    }

    void OnValueChanged_Fruit(bool isOn, int idx)
    {
        if (isOn)
        {
            m_curIdx = idx;
            m_txtResult.text = $"{m_fruits[idx]}";
        }
    }
}
