using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item3 : MonoBehaviour
{
    public Image m_img = null;
    public Button m_btn = null;

    public Text m_Id = null;
    public Text m_txtName = null;
    public Text m_Kor = null;
    public Text m_Eng = null;
    public Text m_Math = null;
    public Text m_Tot = null;
    public Text m_Aver = null;

    public StudentInfo m_stu = null;

    public void Init(StudentInfo stu)
    {
        m_stu = stu;

        m_Id.text = m_stu.m_id;
        m_txtName.text = m_stu.m_name;
        m_Kor.text = m_stu.m_kor.ToString();
        m_Eng.text = m_stu.m_eng.ToString();
        m_Math.text = m_stu.m_math.ToString();
        m_Tot.text = m_stu.Total.ToString();
        m_Aver.text = string.Format("{0:0.00}", m_stu.Average);
    }
}
