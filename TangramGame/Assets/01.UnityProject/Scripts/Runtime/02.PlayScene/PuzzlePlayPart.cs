using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public Canvas canvas = default;

    private bool isClicked = false;
    private RectTransform rectTransform = default;
    private PuzzleInitZone puzzleInitZone = default;



    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        rectTransform = gameObject.GetRect();
        puzzleInitZone = transform.parent.
            gameObject.GetComponent<PuzzleInitZone>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //! ���콺 ��ư�� ������ �� �����ϴ� �Լ�
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;

        // DEBUG:
        //GioleFunc.Log($"{gameObject.name}�� �����ߴ�.");
    }       // OnPointerDown()

    //! ���콺 ��ư���� ���� ���� �� �����ϴ� �Լ�
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;

        // DEBUG:
        //GioleFunc.Log($"{gameObject.name}�� ���� �����ߴ�.");
    }       // OnPointerUp()

    //! ���콺�� �巡�� ���� �� �����ϴ� �Լ�
    //public void OnPointerMove(PointerEventData eventData)
    //{
    //    //if(isClicked == true)
    //    //{
    //    //    gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f);


    //    //    GioleFunc.Log($"���콺�� �������� ������ Ȯ�� : ({eventData.position.x}, {eventData.position.y})");
    //    //}       //if: ���� ������Ʈ�� ������ ���
    //}       // OnPointerMove()


    //! ���콺�� �巡�� ���� �� �����ϴ� �Լ�
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {

            gameObject.AddAnchoredPos(
                eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);
            //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

            //gameObject.SetLocalPos(Input.mousePosition.x, Input.mousePosition.y, 0f);
            

            //GioleFunc.Log($"���콺�� �������� ������ Ȯ�� : ({Input.mousePosition.x}, {Input.mousePosition.y})");
        }
    }

}

