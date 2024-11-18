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