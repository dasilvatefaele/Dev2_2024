int [] nums = [3,4,5,6];
int target = 7;
int [] result = [2];

for (int i = 0; i < nums.Length ; i++)
{
    for  (int j = 0; j < nums.Length ; j++)
    {
        if (nums[i] + nums[j] == target && i != j)
        {
            result = [j,i];
        }
    }
}

Console.WriteLine($"[{result[0]}, {result[1]}]");

//! int[] result - contiene il risultato