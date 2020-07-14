# median-of-median

This program takes 2 input
1 - size of array
2 - array list

In a data structure such as an array, the pivot is the element that is selected by an algorithm to perform certain operations around. For example, 
Quicksort and Selection algorithms use a pivot to partition the array into two parts.
 For these algorithms, a good pivot choice will give a balanced partitioning of the array, which is close to the 50/50 split. That means that the best pivot is the median.

This leads to circular logic, however. For example, to sort the array with Quicksort we need a median,
 and to find the median we need to sort the array. To break that circular logic we can use a good approximation of the median instead of the real value. 
One possible approach is to use a randomly selected element as a pivot, which is what Randomized Quicksort does. 
Another approach is to find an approximate median deterministically. The Median of Medians algorithm can be used for that:

Divide the list into sublists with kk elements. The last sublist may contain fewer than kk elements.
Sort each sublist, get its median and append it to another list containing medians of sublists.
If the medians list has a length more than kk, compute its median recursively, proceeding with step 1.
If the medians list has kk elements or fewer, sort it and determine its median. Return it as a pivot.
If an array is of odd length, the median is the middle element after the array has been sorted. If an array is of even length, 
there are two middle elements after it has been sorted. In this case, we will define the median as the left (first) of these two middle elements.

Input:
An integer number kk on the first line which is the length to use for sublists in the algorithm. The second line contains space-separated integers of the array. For example:

3
1 2 5 4 6 3 7 8
Output:
The integer number selected as the pivot by Median of Medians algorithm. For example:

4
