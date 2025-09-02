using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class Player_Ctrl : MonoBehaviour
{
    private Transform tr;
    float moveSpeed = 5.0f;             // 이동 속도 변수
    float rotSpeed = 100.0f;            // 회전 속도 변수
    float h;
    float v;

    PlayerState playerState = PlayerState.idle;
    Animator panimator;

    private Vector3 moveDir = Vector3.zero;

    void Start()
    {
        tr = GetComponent<Transform>();
        panimator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        Shoot();
        reload();
    }

    void Move()
    {
        // 키보드의 수평/수직 입력값을 받아옴
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // 이동 방향을 벡터의 덧셈 연산을 이용해 미리 계산
        moveDir = (transform.forward * v) + (transform.right * h);

        //Translate(이동방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);

        //Vector3.up축을 기준으로 rotSpeed 만큼 속도로 회전
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X") * 3.0f);

        //키보드 입력값을 기준으로 동작할 애니메이션 수행
        if (v >= 0.1f)
        {
            //전진 애니메이션
            panimator.SetBool("isWalk", true);
            panimator.SetFloat("v", v);
            Debug.Log(v);
        }
        else if (v <= -0.1f)
        {
            //후진 애니메이션 
            panimator.SetBool("isWalk", true);
            panimator.SetFloat("v", v);
        }
        else if (h >= 0.1f)
        {
            //오른쪽 이동 애니메이션 
            panimator.SetBool("isWalk", true);
            panimator.SetFloat("h", h);
        }
        else if (h <= -0.1f)
        {
            //왼쪽 이동 애니메이션 
            panimator.SetBool("isWalk", true);
            panimator.SetFloat("h", h);
        }
        else
        {
            //정지시 idle 애니메이션 
            panimator.SetBool("isWalk", false);
        }

    }

    void Shoot()
    {
        //마우스 버튼
        if (Input.GetMouseButtonDown(0) == true)
        {
            panimator.SetTrigger("ShootS");
        }
    }

    void reload()
    {
        if (Input.GetKey(KeyCode.R) == true)
        {
            panimator.SetTrigger("Reload");
        }
        //장전시에는 못움직이게 하는게 좋을 것같음
        //왜 장전을 두번하는가
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {

        }
    }
}
