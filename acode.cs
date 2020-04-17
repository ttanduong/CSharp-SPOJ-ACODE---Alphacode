using System;

public class Test
{
	public static void Main()
	{
		string line;
		
		while ((line = Console.ReadLine()) != null)
		{
			if (line == "0") return;
			Console.WriteLine("{0}", DecodeTabu(line));
		}
	}
	
  //Tabulation
	static int DecodeTabu(string s)
	{
		//Check string is valid:
		if (s[0] == '0')	return 0;
		if (s.Length < 2)	return 1;
		
		//Calculate:
		int[] dp = new int[s.Length];				
		dp[0] = 1;
		dp[1] = (((s[0]-'0') > 2) || (s[1] == '0')) ? 1 : 2;
		
		for (int i = 2; i < s.Length; i++)
		{	
			if (s[i] == '0')
			{
        //Check string is valid:
				if ((s[i-1] == '0') || (s[i-1] - '0' > 2))	
					return 0;
				dp[i-1] = dp[i-2];
				dp[i] = dp[i-1];
			}
			else if ((s[i-1] == '0') || (s[i-1]-'0' > 2))	
				dp[i] = dp[i-1];
			else dp[i] = dp[i-1] + dp[i-2];					
		}	
		return dp[s.Length - 1];
	}
}
