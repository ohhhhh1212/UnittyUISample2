using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
{
    [SerializeField] Dropdown m_dropdown = null;
    [SerializeField] Text m_result = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    string[] m_city = { "화성", "충주", "장수", "천안", "원주" };
    int m_curCityIdx = -1;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_dropdown.onValueChanged.AddListener(OnValueChanged_Drop);

        for (int i = 0; i < m_city.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(m_city[i]);
            m_dropdown.options.Add(option);
        }
    }

    void OnClicked_Ok()
    {
        if(m_curCityIdx == -1)
        {
            m_result.text = "값을 입력해주세요.";
            return;
        }

        string str = $"당신이 이동할 도시는 {m_city[m_curCityIdx]}입니다.";
        m_result.text = str;
    }

    void OnClicked_Clear()
    {
        m_curCityIdx = -1;
        m_result.text = "초기화";
    }

    void OnValueChanged_Drop(int value)
    {
        m_curCityIdx = value;
        m_result.text = m_city[value];
    }
}
