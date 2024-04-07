/* 

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0)
                    return 0;

                int k = 1; 
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[i - 1])
                    {
                        nums[k] = nums[i];
                        k++;
                    }
                }

                return k;
            }


            catch (Exception)
            {
                throw;
            }
        }
        /*
        The code acts like a filter, combing through a list of numbers to keep only the distinct ones, 
        akin to sorting through a mixed bag of marbles to find the unique ones. Starting with the assumption that the first number is a keeper,
        it then compares each subsequent number to its predecessor. If it's different, it's deemed unique and kept in the new lineup, 
        effectively moving unique marbles to the front of the bag. The result, k, tells us how many unique marbles we have, 
        and the process is done with minimal fuss, without losing the original order. 
        It's a straightforward yet smart way to declutter an array, ensuring each number’s uniqueness shines through.
        */

        /*
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {

               

                        if (nums == null || nums.Length == 0)
                            return new List<int>(); // Return an empty list if input empty

                        int nonZeroPointer = 0; // Pointer to track the position for non-zero elements

                        // Iterate through the array
                        for (int i = 0; i < nums.Length; i++)
                        {
                            // If the current element is non-zero,move it to the position pointed by nonZeroPointer
                            if (nums[i] != 0)
                            {
                                nums[nonZeroPointer] = nums[i];
                                nonZeroPointer++;
                            }
                        }
                        // Fill the remaining positions with zeros
                        while (nonZeroPointer < nums.Length)
                        {
                            nums[nonZeroPointer] = 0;
                            nonZeroPointer++;
                        }
                        // Convert the modified array to a list and return
                        return nums.ToList();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }



        /*
         This code quickly sorts through an array, pushing all zeros to the end while keeping non-zero elements in front,
        preserving their original order. It's like sorting a hand of cards, moving all jokers (zeros) to the back,
        ensuring the meaningful cards (non-zeros) stay up front and organized. It efficiently identifies and relocates non-zeros using a pointer, 
        then fills the remaining space with zeros, ensuring a clean separation.
        Essentially, it prioritizes relevance and order, making the array more accessible and orderly with minimal fuss.
        */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            
                try
                {

                    List<IList<int>> result = new List<IList<int>>();
                    Array.Sort(nums);
                    for (int i = 0; i < nums.Length - 2; i++)
                    {
                        if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                        {
                            int low = i + 1, high = nums.Length - 1, sum = 0 - nums[i];
                            while (low < high)
                            {
                                if (nums[low] + nums[high] == sum)
                                {
                                    result.Add(new List<int> { nums[i], nums[low], nums[high] });
                                    while (low < high && nums[low] == nums[low + 1]) low++;
                                    while (low < high && nums[high] == nums[high - 1]) high--;
                                    low++;
                                    high--;
                                }
                                else if (nums[low] + nums[high] < sum) low++;
                                else high--;
                            }
                        }
                    }
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
        }
        /*
        This code is like looking for teams of three numbers in a list that, when added together, give zero. 
        It sorts the list first to make searching easier. Then, it carefully picks one number and searches for two other numbers that make the total zero,
        making sure not to repeat the same combination.
        It’s like finding the right pieces that fit together perfectly in a puzzle, ensuring every set of three is unique and adds up to zero.
         */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {

                int maxCount = 0;
                int count = 0;
                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        count++;
                        maxCount = Math.Max(maxCount, count);
                    }
                    else
                    {
                        count = 0;
                    }
                }
                return maxCount;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         This code is like a game where you're counting how many consecutive times you can bounce a ball without it stopping. 
        Each "1" in the array is a successful bounce, and you're trying to find the longest streak of bounces. Every time you hit a "1",
        you add to your current streak. If you hit anything else (like a "0"), the ball stops, and you have to start your count over.
        The goal is to remember the longest streak you've achieved during the game.
        So, by the end, you'll know the most consecutive bounces (or "1s") you managed to get.
         */
        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
         
                        // Write your code here and you can modify the return value according to the requirements
                        int decimalNumber = 0;
                        int baseValue = 1;
                        while (binary > 0)
                        {
                            int lastDigit = binary % 10;
                            binary = binary / 10;
                            decimalNumber += lastDigit * baseValue;
                            baseValue *= 2;
                        }
                        return decimalNumber;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

        /*
         This code is like translating a secret code from the language of computers (binary) into a language humans find easier to understand (decimal). 
        It starts with the last digit of the binary number, much like deciphering a message letter by letter. Each binary digit (bit) is evaluated, 
        turning "on" its value in our human-readable number based on its position. The process is like climbing a ladder, where each rung doubles in 
        value as you go up (from 1 to 2, then 4, 8, and so on).
        By the end, I translated the entire binary code into a decimal number, revealing the message hidden in the binary sequence.
         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
               
                        if (nums.Length < 2) return 0;
                        Array.Sort(nums);
                        int maxGap = 0;
                        for (int i = 1; i < nums.Length; i++)
                        {
                            maxGap = Math.Max(maxGap, nums[i] - nums[i - 1]);
                        }
                        return maxGap;
                    }
                    catch (Exception)
            {
                throw;
            }
                }

        /*

         
        This code is like measuring the biggest step we have to take to cross a series of stones laid out in a row.First,
        it makes sure the stones are arranged from the nearest to the farthest.Then, 
        it goes from one stone to the next, measuring each step.The goal is to find the largest
        step that had to take between any two stones.If there's only one stone or none at all, 
         don't need to step, so the answer is zero.But if there are more, this code finds the longest stretch 
        it have to step over, like identifying the widest gap you need to cross on your path.
*/
        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                
                 
                        Array.Sort(nums);
                        for (int

         i = nums.Length - 1; i >= 2; i--)
                        {
                            if (nums[i] < nums[i - 1] + nums[i - 2])
                                return nums[i] + nums[i - 1] + nums[i - 2];
                        }
                        return 0;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
        /*
         This code is like trying to find the best sticks to build the biggest triangle possible. 
        You lay out all the sticks from shortest to longest and then start looking from the longest stick, 
        trying to pair it with two others that can actually form a triangle (where the sum of the two shorter sides is greater than the longest side).
        It's like picking the best combination of sticks so that when you lay them end to end, 
        they connect to form a triangle with the largest possible perimeter. If no three sticks meet the criteria,
        you conclude that you can't make a triangle at all. 
        It's a practical way to sift through options and find the best set to achieve the largest outline for a triangle.
         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.



        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */





        public static string RemoveOccurrences(string s, string part)
                {
                    try
                    {
                        
                        int index;
                        while ((index = s.IndexOf(part)) != -1)
                        {
                            s = s.Remove(index, part.Length);
                        }
                        return s;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                /* Inbuilt Functions - Don't Change the below functions */
                static string ConvertIListToNestedList(IList<IList<int>> input)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("["); // Add the opening square bracket for the outer list

                    for (int i = 0; i < input.Count; i++)
                    {
                        IList<int> innerList = input[i];
                        sb.Append("[" + string.Join(",", innerList) + "]");

                        // Add a comma unless it's the last inner list
                        if (i < input.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }

                    sb.Append("]"); // Add the closing square bracket for the outer list

                    return sb.ToString();
                }


                static string ConvertIListToArray(IList<int> input)
                {
                    // Create an array to hold the strings in input
                    string[] strArray = new string[input.Count];

                    for (int i = 0; i < input.Count; i++)
                    {
                        strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
                    }

                    // Join the strings in strArray with commas and enclose them in square brackets
                    string result = "[" + string.Join(",", strArray) + "]";

                    return result;
                }
            }
}

/*
 *The code repeatedly searches for a specific substring within a string and removes every occurrence of it.
 It does this until the substring can no longer be found, then returns the modified string without those occurrences.
*/