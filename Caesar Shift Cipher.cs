// Second Programming Assignment
// by Gabriella Di Gregorio DIG15624188

using System;
using System.IO;

class Assessment02
{
	//Setting up Caesar cipher with shift
	static string Caesar(string value, int shift)
    {
		//creating an array for the letters
		char[] alphabet = value.ToCharArray();
        for (int i = 0; i < alphabet.Length; i++)
		{
			char letter = alphabet[i];
			//Adding the shift (subtract 26 on overflow, add 26 on underflow)
			if(letter >='a' && letter <='z')
			{
				letter = (char)(letter + shift);	
				if (letter > 'z')
				{
				letter = (char)(letter - 26);
				}
				if (letter < 'a')
				{
				letter = (char)(letter + 26);
				}
			}	
			//storing the values
			alphabet[i] = letter;
        }
        return new string(alphabet);
    }
	static void Main()
    {
		//encoding (shift 7)
		string a = "we attack at dawn";
		foreach(char character in a)
		{
			Caesar(a, 7);
		}
		string b = Caesar(a, 7);
		
		Console.WriteLine("\nx = 7");
		Console.WriteLine("Plain text: " + a);
		Console.WriteLine("Encoded text: " + b);
		
		//decoding (shift 9)
		string c = "fn jan anjmh oxa hxda xamnab";
		foreach(char character in c)
		{
			Caesar(c, -9);
		}
		string d = Caesar(c,-9);
		
		Console.WriteLine("\nx = 9");
		Console.WriteLine("Encoded text: " + c);
		Console.WriteLine("Plain text: " + d);
		
		//*****************EXTENSION******************
		//please keep the .txt with the .cs
		
		//reading the code from the text file
		string code = File.ReadAllText("text.txt").ToLower();
		Console.WriteLine("---------------------------------------------\n\n" + code);
		
		//array for counting letter frequencies
		int[] freq = new int [255];
		int n = 0, max,l;
		l = code.Length;
		int ascii;
		
		//setting the frequency of all characters to zero, and count up
		for(n=0; n<255; n++)
		{
			freq[n] = 0;
		}
		n=0;
		while(n<l)
		{
			ascii = (int)code[n];
			freq[ascii] += 1;
			n++;
		}
		//finding the most frequently occuring letter and how many times it occurs
		max = 0;
		for(n=0; n<255; n++)
		{
			if(n!=32)
			{
				if(freq[n] > freq[max])
				max = n;
			}
		}
		Console.WriteLine("The most commonly occuring character in this text is {0}, occuring {1} times", (char)max, freq[max]);
		
		//finding the shift: subtracting the ASCII number of 'e' from the ASCII number of the most common letter in the code
		int difference = (char)max - 101;
		
		Console.WriteLine("The most commonly occuring letter is usually e, so if {0} = e then the shift is {1}...", (char)max, difference);
		
		//writing the decoded text after applying the shift
		foreach(char character in code)
		{
			Caesar(code, -difference);
		}
		string strech = Caesar(code, -difference);
		Console.Write("\n" + strech);
				
		Console.ReadLine();
		}
}
