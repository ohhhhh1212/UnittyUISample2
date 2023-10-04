using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test013Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_scroll = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;

    [SerializeField] GameObject m_preItem = null;

    string[] m_city = { "고성", "속초", "원주", "강릉", "횡성", "평창", "인제", "양양"," 춘천", "태백" };

    Item2 m_curItem = null;

    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        SetItem();
    }
    
    void SetItem()
    {
        for (int i = 0; i < m_city.Length; i++)
        {
            GameObject go = Instantiate(m_preItem, m_scroll.content);
            Item2 item = go.GetComponent<Item2>();

            item.m_txt.text = m_city[i];
            item.m_btn.onClick.AddListener(() => SelctedItem(item));
        }
    }

    void SelctedItem(Item2 item)
    {
        if (m_curItem != null)
            m_curItem.m_img.color = Color.white;

        item.m_img.color = Color.magenta;

        m_curItem = item;

        m_txtResult.text = item.m_txt.text;
    }

    void OnClicked_Ok()
    {
        if(m_curItem == null)
        {
            m_txtResult.text = "도시를 선택해주세요.";
            return;
        }

        m_txtResult.text = $"당신이 선택한 도시는 {m_curItem.m_txt.text}입니다.";
    }

    void OnClicked_Clear()
    {
        if (m_curItem != null)
            m_curItem.m_img.color = Color.white;

        m_curItem = null;
        m_txtResult.text = "초기화";
    }

    void ClearItem()
    {
        for (int i = 0; i < m_scroll.content.childCount; i++)
        {
            GameObject go = m_scroll.content.GetChild(i).gameObject;
            Destroy(go);
        }
    }

    private void OnDestroy()
    {
        ClearItem();
    }
}
