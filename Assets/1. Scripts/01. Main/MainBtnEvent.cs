using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainBtnEvent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Text m_RhombusTxt = null;    //마름모 텍스트
    public Text m_ContentTxt = null;    //콘텐츠 텍스트

    RectTransform m_RhombusTr = null;   //마름모 텍스트 위치
    RectTransform m_ContentTr = null;   //콘텐츠 텍스트 위치

    Vector2 m_OriginPos;                //기존 위치
    Vector2 m_MovePos;                  //이동 위치

    Coroutine AnimateCoroutine;         //코루틴 참조 저장

    //텍스트 내용 저장
    string m_RhomSt = "";
    string m_ConSt = "";

    string hexColor = "";               //현재 콘텐츠 텍스트의 컬러코드 저장(ex.#FFFFFF)

    int minSize = 25;                   //마름모 폰트 최소 사이즈
    int maxSize = 35;                   //마름모 폰트 최대 사이즈

    float aniDuration = 0.1f;           //텍스트 애니메이션 지속시간


    

    private void Start()
    {
        if (m_RhombusTxt == null)
            return;

        if (m_ContentTxt == null)
            return;

        //텍스트 내용 저장
        m_RhomSt = m_RhombusTxt.text;
        m_ConSt = m_ContentTxt.text;

        //마름모, 콘텐츠 컴포넌트 받아오기
        m_RhombusTr = m_RhombusTxt.GetComponent<RectTransform>();
        m_ContentTr = m_ContentTxt.GetComponent<RectTransform>();

        //콘텐츠 이동 좌표 받아오기
        m_OriginPos = m_ContentTr.anchoredPosition;
        m_MovePos = new Vector2(m_OriginPos.x + 10, m_OriginPos.y);

        //콘텐츠 텍스트 컬러 코드 받아오기
        hexColor = "#" + ColorUtility.ToHtmlStringRGB(m_ContentTxt.color);
    }

    private void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //글자 컬러 변경
        m_RhombusTxt.text = "<color=#41F2C0>" + m_RhomSt + "</color>";
        m_ContentTxt.text = "<color=#41F2C0>" + m_ConSt + "</color>";

        //코루틴 중지 및 실행 관리
        if (AnimateCoroutine != null)
            StopCoroutine(AnimateCoroutine);

        AnimateCoroutine = StartCoroutine(AnimateText(aniDuration, 1.0f, minSize, maxSize, m_OriginPos, m_MovePos));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //글자 컬러 변경
        m_RhombusTxt.text = "<color=#FFFFFF>" + m_RhomSt + "</color>";
        m_ContentTxt.text = "<color=" + hexColor + ">" + m_ConSt + "</color>";

        //코루틴 중지 및 실행 관리
        if (AnimateCoroutine != null)
            StopCoroutine(AnimateCoroutine);

        AnimateCoroutine = StartCoroutine(AnimateText(aniDuration, -1.0f, maxSize, minSize, m_MovePos, m_OriginPos));
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {

    }

    public IEnumerator AnimateText(float duration, float direction, float startSize, float endSize, Vector2 startPos, Vector2 endPos)
    {
        //흐른 시간
        float elapsedTime = 0.0f;

        // 마름모 시계 또는 반시계 방향 회전
        float startRotation = m_RhombusTr.eulerAngles.z;
        float endRotation = startRotation + (360f * direction);

        //####
        if (direction < 0 && endRotation < 0) endRotation = -360f;
        if (direction > 0 && endRotation >= 360f) endRotation = 360f;
        
        // 픞레이 위치 10 옮기기 
        float startPosition = m_ContentTr.anchoredPosition.x;
        float endRoatation = startRotation + 10;

            
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            
            // 마름모 회전
            float currentRotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / duration);    //선형보간(시작,끝,보간비율 0~1)
            m_RhombusTr.rotation = Quaternion.Euler(0, 0, currentRotation);                             //마름모 회전값 변경

            // 폰트 사이즈 변경
            m_RhombusTxt.fontSize = Mathf.RoundToInt(Mathf.Lerp(startSize, endSize, elapsedTime / duration));   //반올림

            // 콘텐트 오른쪽 이동
            m_ContentTr.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / duration);

            yield return null;
        }

        //최종 상태 설정
        m_RhombusTr.rotation = Quaternion.Euler(0, 0, endRotation);
        m_RhombusTxt.fontSize = Mathf.RoundToInt(endSize);
        m_ContentTr.anchoredPosition = endPos;
    }
}
