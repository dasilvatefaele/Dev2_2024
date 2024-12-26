# 3133. Minimum Array End

> Difficoltà: Medium

You are given two integers `n` and `x`. You have to construct an array of positive integers nums of size `n` where for every `0 <= i < n - 1`, `nums[i + 1]` is greater than `nums[i]`, and the result of the bitwise `AND` operation between all elements of `nums` is `x`.

Return the minimum possible value of `nums[n - 1]`.



---
> Example 1:

Input: n = 3, x = 4

Output: 6

>> Explanation:

nums can be `[4,5,6]` and its last element is 6.

> Example 2:

Input: n = 2, x = 7

Output: 15

>> Explanation:

nums can be [7,15] and its last element is 15.



Constraints:

`1 <= n, x <= 10^8`

[LeedCode Source](https://leetcode.com/problems/minimum-array-end/description/?envType=daily-question&envId=2024-11-09)


---
### Nota sull'AND bit to bit
Un'operazione AND bit a bit tra due numeri interi confronta ogni coppia di bit alla stessa posizione nei due numeri. Il risultato ha un bit impostato a 1 solo se entrambi i bit nella posizione corrispondente sono 1; altrimenti, il bit nel risultato è 0.

Ad esempio, per fare un'operazione AND bit a bit tra i numeri interi 
a=6 e b=3:

Rappresentiamo i numeri in binario:

| binario | decimale |
|--|--|
|1 1 0|  6 |
|0 1 1 | 3 |

Operazione AND bit to bit

|1|1|0|= 6|
|-|-|-|-|
|0|1|1|= 3|

Risultato:

|0|1|0|= 2|
|-|-|-|-|

| binario | decimale |
|-|-|
|0 1 0| 2|

```csharp
int a = 6;
int b = 3;
int result = a & b;  // Risultato: 2
```










