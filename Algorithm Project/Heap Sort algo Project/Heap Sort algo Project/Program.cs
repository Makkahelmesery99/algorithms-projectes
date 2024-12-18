using System;

class Program
{
    // Function to maintain the heap property
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;  // Initialize largest as root
        int left = 2 * i + 1;  // Left child
        int right = 2 * i + 2;  // Right child

        // Check if left child exists and is greater than root
        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }

        // Check if right child exists and is greater than largest so far
        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }

        // If largest is not root
        if (largest != i)
        {
            // Swap arr[i] and arr[largest]
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            // Recursively heapify the affected subtree
            Heapify(arr, n, largest);
        }
    }

    // Function to build a max-heap
    static void BuildMaxHeap(int[] arr)
    {
        int n = arr.Length;
        // Build a max-heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
    }

    // Function to perform heap sort
    static void HeapSort(int[] arr)
    {
        int n = arr.Length;
        BuildMaxHeap(arr);  // Step 1: Build a max heap

        // Step 2: Extract elements one by one
        for (int i = n - 1; i > 0; i--)
        {
            // Swap the root (largest element) with the last element
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Call heapify on the reduced heap
            Heapify(arr, i, 0);
        }
    }

    static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };

        Console.WriteLine("Original array: ");
        PrintArray(arr);

        HeapSort(arr);  // Perform HeapSort

        Console.WriteLine("Sorted array: ");
        PrintArray(arr);
    }

    // Utility function to print an array
    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}