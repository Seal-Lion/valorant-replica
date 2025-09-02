using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [Header("Setting")]
    public Button m_SettingBtn = null;
    public GameObject m_SettingPanel = null;
    
    [Space]
    public Button m_GameCloseBtn = null;
    public Button m_SettingCloseBtn = null;
    public Button m_InfomationBtn = null;
    public Button m_CustomerSptBtn = null;
    public Button m_SetBtn = null;

    [Header("Setting-GameClosePn")]
    public GameObject m_GameClosePanel = null;
    public Button m_GameClosePBtn = null;
    public Button m_GameLogOutBtn = null;
    public Button m_GameEndBtn = null;

    bool SettingPnOnOff = false;
    bool GameClosePnOnOff = false;


    [Header("Valorant_Point")]
    public Button m_ValorantPointBtn = null;
    public Button m_ValorantIcBtn = null;

    //레디어나이트 포인트
    //public Button m_RedianitePointBtn = null;
    //public Button m_RedianiteIcBtn = null;

    [Header("Kingdom_Credit")]
    public Button m_KingdomCreditBtn = null;
    public Button m_KingdomIcBtn = null;
    public GameObject m_KingdomPanel = null;

    [Space]   
    public Button m_KdDecoBtn = null;
    public Button m_KdAgentBtn = null;
    public Button m_KdCloseBtn = null;

    bool KingdomPnOnOff = false;


    void Start()
    {
        if (m_SettingBtn != null)
            m_SettingBtn.onClick.AddListener(Btn_Setting);

        #region 설정창
        //설정 창 닫기 버튼
        if(m_SettingCloseBtn != null)
            m_SettingCloseBtn.onClick.AddListener(()=> {
                if (m_SettingPanel == null)
                    return;

                SettingPnOnOff = false;
                m_SettingPanel.gameObject.SetActive(SettingPnOnOff);
        });

        //설정 버튼
        if (m_SetBtn != null)
            m_SetBtn.onClick.AddListener(Menu_Setting);

        //고객지원 버튼
        //정보버튼

        //게임종료 버튼
        if (m_GameCloseBtn != null)
            m_GameCloseBtn.onClick.AddListener(() => 
            {
                if (m_GameClosePanel == null)
                    return;

                SettingPnOnOff = false;
                m_SettingPanel.gameObject.SetActive(SettingPnOnOff);

                GameClosePnOnOff = true;
                m_GameClosePanel.gameObject.SetActive(GameClosePnOnOff);
            });

        #endregion

        //발로란트 포인트 버튼
        if (m_ValorantPointBtn != null)
            m_ValorantPointBtn.onClick.AddListener(Btn_ValorantPoint);
        
        //킹덤 크레딧 버튼
        if(m_KingdomIcBtn != null)
            m_KingdomIcBtn.onClick.AddListener(Btn_KingdomCredit);

        #region 킹덤 크레딧창

        //킹덤 크레딧 창 닫기 버튼
        if (m_KdCloseBtn != null)
            m_KdCloseBtn.onClick.AddListener(() =>
            {
                if (m_KingdomPanel == null)
                    return;

                KingdomPnOnOff = false;
                m_KingdomPanel.gameObject.SetActive(KingdomPnOnOff);
            });

        //장식 버튼
        if (m_KdDecoBtn != null)
            m_KdDecoBtn.onClick.AddListener(() =>
            {
                if (m_KingdomPanel == null)
                    return;

                KingdomPnOnOff = false;
                m_KingdomPanel.gameObject.SetActive(KingdomPnOnOff);

                // #TODO - 상점 장식 창 열기
            });

        //요원 버튼
        if (m_KdAgentBtn != null)
            m_KdAgentBtn.onClick.AddListener(() =>
            {
                if (m_KingdomPanel == null)
                    return;

                KingdomPnOnOff = false;
                m_KingdomPanel.gameObject.SetActive(KingdomPnOnOff);

                // #TODO - 상점 요원 창 열기
            });

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Menu_Setting()
    {

    }

    void Btn_Setting()
    {
        if (m_SettingPanel == null)
            return;

        SettingPnOnOff = true;
        m_SettingPanel.gameObject.SetActive(SettingPnOnOff);
    }

    void Btn_ValorantPoint()
    {
        //발로란트 vp 결제창 URL 열기 (발로란트 사이트로 대체)
        Application.OpenURL("https://playvalorant.com/ko-kr/");
    }
    
    void Btn_KingdomCredit()
    {
        if (m_KingdomPanel == null)
            return;

        KingdomPnOnOff = true;
        m_KingdomPanel.gameObject.SetActive(KingdomPnOnOff);
    }
}
