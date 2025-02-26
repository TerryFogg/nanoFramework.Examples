//// C# program to check if a given instance of N*N-1 puzzle is solvable or not

//// Copied from https://www.geeksforgeeks.org/check-instance-15-puzzle-solvable/

//using System;

//namespace Puzzle
//{
//    class Program
//    {

//        const int N = 4;
//        // A utility function to count inversions in a given array 'arr[]'.
//        // Note that this function can be optimized to work in O(n Log n) time.
//        // The idea here is to keep code small and simple.
//        static int getInvCount(int[] arr)
//        {
//            int inv_count = 0;
//            for (int i = 0; i < N * N - 1; i++)
//            {
//                for (int j = i + 1; j < N * N; j++)
//                {
//                    // count pairs(arr[i], arr[j]) such that  i < j but arr[i] > arr[j]
//                    if (arr[j] != 0 && arr[i] != 0
//                        && arr[i] > arr[j])
//                        inv_count++;
//                }
//            }
//            return inv_count;
//        }

//        // find Position of blank from bottom
//        static int findXPosition(int[,] puzzle)
//        {
//            for (int i = N - 1; i >= 0; i--)
//            {
//                for (int j = N - 1; j >= 0; j--)
//                {
//                    if (puzzle[i, j] == 0)
//                        return N - i;
//                }
//            }
//            return -1;
//        }

//        // This function returns true if given instance of N*N - 1 puzzle is solvable
//        static bool isSolvable(int[,] puzzle)
//        {
//            int[] arr = new int[N * N];
//            int k = 0;
//            for (int i = 0; i < N; i++)
//            {
//                for (int j = 0; j < N; j++)
//                {
//                    arr[k++] = puzzle[i, j];
//                }
//            }

//            // Count inversions in given puzzle
//            int invCount = getInvCount(arr);

//            // If grid is odd, return true if inversion count is even.
//            if (N % 2 == 1)
//            {
//                return (invCount % 2 == 0);
//            }
//            else // grid is even
//            {
//                int pos = findXPosition(puzzle);
//                if (pos % 2 == 1)
//                    return invCount % 2 == 0;
//                else
//                    return invCount % 2 == 1;
//            }
//        }
//        /* Driver program to test above functions */
//    }
//}
