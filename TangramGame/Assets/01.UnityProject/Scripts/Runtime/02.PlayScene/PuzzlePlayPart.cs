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


        // ���� �̹��� �̸��� ���� ������ Ÿ���� ��������.
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

        PuzzleLvPart closeLvPuzzle =
        playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);

        if(closeLvPuzzle == null || closeLvPuzzle == default)
        {
            return;
        }


        transform.position = closeLvPuzzle.transform.position;
        GioleFunc.Log($"{closeLvPuzzle.name}�� ���� �����̿� �ֽ��ϴ�.");

        // ���⼭ ������ ������ �ִ� ���� ����Ʈ�� ��ȸ�ؼ�
        // ���� ����� ������ ã�ƿ´�.
        //���⼭ ������ ������ �ִ� ���� ����Ʈ�� ��ȸ�ؼ� ���ڸ��� ã�´�


    }       // OnPointerUp()



    //! ���콺�� �巡�� ���� �� �����ϴ� �Լ�
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {

            gameObject.AddAnchoredPos(
                eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);
        }
    }

}

