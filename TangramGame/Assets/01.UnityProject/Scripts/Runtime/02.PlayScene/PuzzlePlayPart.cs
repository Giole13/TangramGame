using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    private bool isClicked = false;
    RectTransform rectTransform = default;
    public Canvas canvas = default;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //! 마우스 버튼을 눌렀을 때 동작하는 함수
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;

        // DEBUG:
        //GioleFunc.Log($"{gameObject.name}을 선택했다.");
    }       // OnPointerDown()

    //! 마우스 버튼에서 손을 땠을 때 동작하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;

        // DEBUG:
        //GioleFunc.Log($"{gameObject.name}을 선택 해제했다.");
    }       // OnPointerUp()

    //! 마우스를 드래그 중일 때 동작하는 함수
    public void OnPointerMove(PointerEventData eventData)
    {
        //if(isClicked == true)
        //{
        //    gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f);


        //    GioleFunc.Log($"마우스의 포지션을 눈으로 확인 : ({eventData.position.x}, {eventData.position.y})");
        //}       //if: 현재 오브젝트를 선택한 경우
    }       // OnPointerMove()




    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

            //gameObject.SetLocalPos(Input.mousePosition.x, Input.mousePosition.y, 0f);
            

            //GioleFunc.Log($"마우스의 포지션을 눈으로 확인 : ({Input.mousePosition.x}, {Input.mousePosition.y})");
        }
    }

}

