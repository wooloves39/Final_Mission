
using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    Vector2 slideStartPosition;
    Vector2 prevPosition;
    Vector2 delta = Vector2.zero;
    bool moved = false;
    private GameObject copy;
    private GameObject AreaPoint;
    int cnt = 0;
    private Vector2[,] Area = new Vector2[100, 100];
    private Vector2 startArea;
    void Start()
    {
        copy = Resources.Load("sphere") as GameObject;
        AreaPoint = Resources.Load("AreaPoint") as GameObject;
    }
    void Update()
    {

        // 슬라이드 시작 지점.
        if (Input.GetButtonDown("Fire1"))
        {
            slideStartPosition = GetCursorPosition();
            startArea.x = slideStartPosition.x - 200;
            startArea.y = slideStartPosition.y - 200;

            for (int i = 0; i < 100; ++i)
            {
                for (int j = 0; j < 100; ++j)
                {
                    Area[i,j].x = startArea.x + i*4;
                    Area[i, j].y = startArea.y + j*4;
                    Vector3 pos;
                    pos.x= Area[i, j].x;
                    pos.y= Area[i, j].y;
                    pos.z = 0;
                    AreaPoint.transform.position = Area[i, j];
                    Instantiate(AreaPoint, pos, Quaternion.identity);
                }
            }
        }

        // 화면 너비의 2% 이상 커서를 이동시키면 슬라이드 시작으로 판단한다.
        if (Input.GetButton("Fire1"))
        {
            if (Vector2.Distance(slideStartPosition, GetCursorPosition()) >= (Screen.width * 0.02f))
            {
                print("is Click Ture");
                copy.transform.position = GetCursorPosition();
                cnt++;
                if (cnt % 5 == 0)
                {
                
                }
                moved = true;
            }
        }
        //잘못된 영역에 닿았는지 판별한다!


        // 슬라이드가 끝났는가.
        if (!Input.GetButtonUp("Fire1") && !Input.GetButton("Fire1"))
        {
        }
        //해당 스킬 발동!!
       
        prevPosition = GetCursorPosition();
    }

    // 클릭되었는가.
    public bool Clicked()
    {
        if (!moved && Input.GetButtonUp("Fire1"))
        {
            return true;
        }
        else
            return false;
    }

    // 슬라이드할 때 커서 이동량.
    public Vector2 GetDeltaPosition()
    {
        return delta;
    }

    // 슬라이드 중인가.
    public bool Moved()
    {
        return moved;
    }

    public Vector2 GetCursorPosition()
    {
        return Input.mousePosition;
    }
}