//http://rosalind.info/problems/revc/
//Sample Dataset
//AAAACCCGGT
//Sample Output
//ACCGGGTTTT
#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
#include <unordered_map>
using namespace std;

string revc(string str)
{
	stringstream result;
	unordered_map<char, char> transform;
	transform['A'] = 'T';
	transform['T'] = 'A';
	transform['C'] = 'G';
	transform['G'] = 'C';
	for (auto ch = str.rbegin(); ch != str.rend(); ch++)
	{
		auto found = transform.find(*ch);
		if (found != transform.end())
			result << found->second;
	}
	return result.str();
}
int main()
{
//	string input = "AAAACCCGGT";
	ifstream fin("rosalind_revc.txt", ios::in);
	if (fin.is_open()) 
	{
		stringstream input;
		input << fin.rdbuf();
		ofstream fout("rosalind_revc_res.txt", ios::out);
		fout << revc(input.str()) << endl;
	}
	getchar();
}