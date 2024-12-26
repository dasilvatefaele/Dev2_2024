#### LeetCode Problems

# Top K Frequent Elements:
`Medium`

Given an integer array nums and an integer k, return the k most frequent elements within the array.

The test cases are generated such that the answer is always unique.

You may return the output in any order.

> Example 1:
```
Input: nums = [1,2,2,3,3,3], k = 2

Output: [2,3]
```
> Example 2:

```
Input: nums = [7,7], k = 1

Output: [7]
```
> Soluzione personale:
```csharp
int[] nums=[1,1,1,2,2,3];
int k = 2;

var hashMap = new Dictionary<int, int>();

Array.Sort(nums);

for (int i = 0; i < nums.Length ; i ++)
{
        if (!hashMap.ContainsKey(nums[i]))
            hashMap[nums[i]] = 0;
        hashMap[nums[i]]++;
}

var orderByValue = hashMap.OrderBy(pair => pair.Value);
var provaLista = orderByValue.ToList();
provaLista.Reverse();

Console.WriteLine(string.Join(", ", provaLista));
int[] result = new int[k];
for (int i = 0; i < k ; i++)
{
    result[i] = provaLista[i].Value;
}

Console.WriteLine(string.Join(", ", result));

```