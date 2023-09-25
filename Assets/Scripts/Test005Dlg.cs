using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    [SerializeField] Slider[] m_sliders = null;
    [SerializeField] Text[] m_txtColors = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        for (int i = 0; i < m_sliders.Length; i++)
        {
            m_sliders[i].onValueChanged.AddListener(OnValueChanged_Colors);
        }
    }

    void OnClicked_Ok()
    {
        string str = $"당신의 고른 색깔입니다 => R : {m_sliders[0].value}, G : {m_sliders[1].value}, B : {m_sliders[2].value}";
        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        for (int i = 0; i < m_sliders.Length; i++)
        {
            m_sliders[i].value = 0;
        }

        m_txtResult.text = "초기화";
    }

    void OnValueChanged_Colors(float value)
    {
        float red = m_sliders[0].value / 255;
        float green = m_sliders[1].value / 255;
        float blue = m_sliders[2].value / 255;
        Color color = new Color(red, green, blue);

        m_txtResult.color = color;
        m_txtResult.text = "현재 색상 값 입니다.";

        m_txtColors[0].text = m_sliders[0].value.ToString();
        m_txtColors[1].text = m_sliders[1].value.ToString();
        m_txtColors[2].text = m_sliders[2].value.ToString();
    }

}
