//http://rosalind.info/problems/fib/
//Samples
//5 3 -> 19
//28 5 -> 662854323131
#include <iostream>
#include <unordered_map>
using namespace std;
unordered_map<int, __int64> fibs;

__int64 fib(int n, int k)
{
	auto found = fibs.find(n);
	if (found != fibs.end())
		return found->second;

	__int64 result = 0;
	if (n < 3) 
		result = 1;
	else
		result = fib(n - 2, k) * k + fib(n - 1, k);
	fibs[n] = result;
	return result;
}

int main()
{
//	cout << fib(5, 3) << endl;
	cout << fib(28, 5) << endl; //662854323131
	//for (auto it = fibs.begin(); it != fibs.end(); it++)
	//	cout << it->first << "=" << it->second << endl;
	getchar();
}
