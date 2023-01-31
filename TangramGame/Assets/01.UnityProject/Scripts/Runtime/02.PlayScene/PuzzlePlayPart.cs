using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public PuzzleType puzzleType = PuzzleType.NONE;
    public Canvas canvas = default;
    private Image puzzleImage = default;

    private bool isClicked = false;
    private RectTransform rectTransform = default;
    private PuzzleInitZone puzzleInitZone = default;
    private PlayLevel playLevel = default;


    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        rectTransform = gameObject.GetRect();
        puzzleInitZone = transform.parent.
            gameObject.GetComponent<PuzzleInitZone>();


        puzzleImage = gameObject.
           FindChildObj("PuzzleImage").GetComponentMust<Image>();

        playLevel = GameManager.Instance.
            gameObjs[GioleData.OBJ_NAME_CURRENT_LEVEL].
            GetComponentMust<PlayLevel>();


        // 퍼즐 이미지 이름에 따라서 퍼즐의 타입이 정해진다.
        switch (puzzleImage.sprite.name)
        {
            case "Puzzle_BigTriangle1":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            case "Puzzle_BigTriangle2":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            default:
                puzzleType = PuzzleType.NONE;
                break;
        }       // switch

        //if (LV_PUZZLE_LIMIT < minDistance)
        //{

        //}

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

        PuzzleLvPart closeLvPuzzle =
        playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);

        if(closeLvPuzzle == null || closeLvPuzzle == default)
        {
            return;
        }


        transform.position = closeLvPuzzle.transform.position;
        GioleFunc.Log($"{closeLvPuzzle.name}이 가장 가까이에 있습니다.");

        // 여기서 레벨이 가지고 있는 퍼즐 리스트를 순회해서
        // 가장 가까운 퍼즐을 찾아온다.
        //여기서 레벨이 가지고 있는 퍼즐 리스트를 순회해서 제자리를 찾는다


    }       // OnPointerUp()



    //! 마우스를 드래그 중일 때 동작하는 함수
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {

            gameObject.AddAnchoredPos(
                eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);
        }
    }

}

