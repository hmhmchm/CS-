using System;

delegate int Compare(int a, int b);

class Class1
{

    static int AscendCompare(int a, int b) // AscendCompare 라는 오름차순 함수  
    {
        if (a > b) return 1;
        else if (a == b) return 0;
        else return -1;
    }

    static int DescendCompare(int a, int b) // DescendCompare 라는 내림차순 함수
    {
        if (a < b) return 1;
        else if (a == b) return 0;
        else return -1;
    }

    static void BubbleSort(int[] DataSet, Compare comparer) // 버블소트 DataSet 배열과  Compare 이라는 델리게이트에 comparer라는 델리게이트 변수
    {
        int i = 0;
        int j = 0;
        int temp = 0;

        for (i = 0; i < DataSet.Length - 1; i++) // i 가 몇번째 도는지 나타낸다.  i = 0 일때 첫번째 돈다는 뜻. i= 1 일 때는 두번째로 돌겠지.
        {
            for (j = 0; j < DataSet.Length - (i + 1); j++) // i = 0 이라면 첫번째 돈다는 뜻 일때 서로 비교하는 횟 수를 1 씩 더해줘야 정확한 비교 횟수가 나온다.
            {
                if (comparer(DataSet[j], DataSet[j + 1]) > 0) // 비교  temp 에다가 넣어주고 서로 교환한다는 의미.
                {
                    temp = DataSet[j + 1];
                    DataSet[j + 1] = DataSet[j];
                    DataSet[j] = temp;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int[] array = { 1, 9, 15, 2, 4 }; // 출력용 데이터

        Console.WriteLine("버블소트 오름차순으로");
        BubbleSort(array, new Compare(AscendCompare));

        //foreach 구문
        foreach (var item in array) // item 이라는 변수에 array 를 
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("버블소트 내림차순으로");
        BubbleSort(array, new Compare(DescendCompare));

        //foreach 구문
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }

}}
}
