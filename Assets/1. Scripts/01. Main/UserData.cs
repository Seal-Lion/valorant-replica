/// <summary>
/// 유저 데이터
/// </summary>
public class UserData
{
    public int m_No;                // 유저번호
    public string m_Id;             // 유저아이디
    public string m_UserName;       // 캐릭터닉네임
    public string m_UserCode;       // #코드

    public int m_Level;             // 캐릭터 레벨
    public int m_KingdomCredit;     // 게임재화
    public int m_RedianitePoint;    // 업그레이드 코인
    public int m_ValorantPoint;     // 캐시 vp

    public UserData()               //초기값 할당
    {
        m_No = 0;
        m_Id = "";
        m_UserCode = "";
        m_UserName = "";

        m_Level = 0;
        m_KingdomCredit = 0;
        m_RedianitePoint = 0;
        m_ValorantPoint = 0;
    }
}