namespace RBytesNetUtil;


// <summary>
/// Funções de ordenação.
/// </summary>
public static class RBytesSortUtil
{
    /// <summary>
    /// Ordena um array de inteiros usando Bubble Sort.
    /// </summary>
    public static void BubbleSort(int[] array)
    {
        if (array == null) return;
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    /// <summary>
    /// Ordena um array de inteiros usando Insertion Sort.
    /// </summary>
    public static void InsertionSort(int[] array)
    {
        if (array == null) return;
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }

    /// <summary>
    /// Ordena um array de inteiros usando Merge Sort.
    /// </summary>
    public static void MergeSort(int[] array)
    {
        if (array == null || array.Length <= 1) return;
        MergeSortInternal(array, 0, array.Length - 1);
    }

    private static void MergeSortInternal(int[] array, int left, int right)
    {
        if (left >= right) return;
        int middle = (left + right) / 2;
        MergeSortInternal(array, left, middle);
        MergeSortInternal(array, middle + 1, right);
        Merge(array, left, middle, right);
    }

    private static void Merge(int[] array, int left, int middle, int right)
    {
        int[] leftArray = array[left..(middle + 1)];
        int[] rightArray = array[(middle + 1)..(right + 1)];
        int i = 0, j = 0, k = left;

        while (i < leftArray.Length && j < rightArray.Length)
        {
            array[k++] = leftArray[i] <= rightArray[j] ? leftArray[i++] : rightArray[j++];
        }

        while (i < leftArray.Length) array[k++] = leftArray[i++];
        while (j < rightArray.Length) array[k++] = rightArray[j++];
    }
}
