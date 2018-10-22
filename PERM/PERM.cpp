//http://rosalind.info/problems/perm/
//Sample Dataset
//3
//Sample Output
//6
//1 2 3
//1 3 2
//2 1 3
//2 3 1
//3 1 2
//3 2 1
#include <iostream>
#include <string>
using namespace std;

class perm_generator {
private: 
	string m_data, m_prefix;
	int m_current;
	int m_max;
public:
	perm_generator(string data, string prefix = "") : m_data(data), m_prefix(prefix), 
		m_current(0), m_max(m_data.length()) {}
	void operator()() {
		char temp = m_data[0];
		m_data[0] = m_data[m_current]; //swap the first element with one of the elements in the sequence
		m_data[m_current] = temp;
		perm_generator perms(m_data.substr(1), 
			(m_prefix.length() > 0 ? m_prefix + " " : "") + m_data.substr(0, 1));
		while (perms)
			perms(); //generate all the permutations for the rest of the sequence
		if (m_data.length() == 1)
			cout << m_prefix << " " + m_data << endl; 
		m_current++;
	}
	operator bool() const {	return m_current < m_max; }
};

unsigned int factorial(unsigned int n)
{
	return (n < 2) ? 1 : n * factorial(n - 1);
}

void perm(unsigned int n)
{
	cout << factorial(n) << endl;
	string nstr = "";
	for (unsigned int i = 1; i <= n; i++)
		nstr += char('0' + i);
	perm_generator perms(nstr);
	while (perms)
		perms();
}

int main()
{
	perm(3);
	getchar();
}
