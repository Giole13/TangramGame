using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public int level = default;
    public List<PuzzleLvPart> puzzleLvParts = default;


    private const float LV_PUZZLE_LIMIT = 1f;

        


    public void Awake()
    {
        GameManager.Instance.Create();
        GameManager.Instance.gameObjs.Add(gameObject.name, gameObject);
    }           

    // Start is called before the first frame update
    void Start()
    {
        puzzleLvParts = new List<PuzzleLvPart>();
        for (int i = 0; i < transform.childCount; ++i)
        {
            puzzleLvParts.Add(
            transform.GetChild(i).gameObject.GetComponentMust<PuzzleLvPart>());

        }       // loop: ���� �������� ���� ������ ��� ĳ���ϴ� ����

    }

    // Update is called once per frame
    void Update()
    {

    }

    //! ���� Ÿ���� �޾Ƽ� �ش� Ÿ�԰� ���� Ÿ���� ������ �����ϴ� �Լ�
    public List<PuzzleLvPart>GetSameTypePuzzle(PuzzleType puzzleType)
    {
        List<PuzzleLvPart> sameTypes = new List<PuzzleLvPart>();
        foreach(var puzzleLvPart in puzzleLvParts)
        {
            if (puzzleLvPart.puzzleType.Equals(puzzleType))
            {
                sameTypes.Add(puzzleLvPart);
            }
            else { continue; }
        }       // loop: ���� Ÿ���� ã���ִ� ����
        return sameTypes;
    }       // GetSameTypePuzzle()
    


    //! ���� ����� ������ ã���ִ� �Լ�
    public PuzzleLvPart GetCloseSameTypePuzzle(PuzzleType puzzleType, Vector3 puzzleWorldPos)
    {
        List<PuzzleLvPart> sameTypes = GetSameTypePuzzle(puzzleType);

        float minDistance = float.MaxValue;
        float distance = float.MaxValue;
        int index = 0;
        PuzzleLvPart result = default;
        foreach(var puzzleLvPart in sameTypes)
        {
            distance = Mathf.Abs((puzzleLvPart.transform.position - 
                puzzleWorldPos).magnitude);
            if(distance <= minDistance)
            {
                minDistance = distance;
                result = puzzleLvPart;
                //break;
            }       // if : ���� ����� ������ ĳ���Ѵ�.
            ++index;
        }       // loop

        if(LV_PUZZLE_LIMIT < minDistance)
        {
            result = default;
        }

        return result;
    }       // GetCloseSameTypePuzzle()
}
