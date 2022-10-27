using Newtonsoft.Json;

namespace BLISCORE.Test
{
    class Solution
    {
        private const string Equal = "EQUAL";
        private const string Impossible = "IMPOSSIBLE";
        private const string Swap = "SWAP";
        private const string Insert = "INSERT";
        private const string ReplaceResult = "REPLACE";
        
        public string solution(string S, string T)
        {
            // Strings are equal
            if (S == T) return Equal;
            
            // Find difference in string lengths
            var delta = S.Length - T.Length;
            
            // Explode strings into arrays
            var arrS = S.ToCharArray();
            var arrT = T.ToCharArray();
            
            
            if (delta == 0) 
            {
                for (var i = 0; i < S.Length; i++) 
                {
                    if (arrS[i] != arrT[i])
                    {
                        //swap
                        var switched = SwitchTwo(arrS, i, i+1);
                        if (string.Join("", switched) == T)
                        {
                            return Swap + " " + arrS[i] + " " + arrS[i+1];
                        }
                        
                        //replace
                        var replaced = Replace(arrS, i, arrT[i]);
                        
                        if (string.Join("", replaced) == T)
                        {
                            return ReplaceResult + " " + arrS[i] + " " + arrT[i];
                        }

                        break;
                    }
                }
            }

            // Try inserting
            else if (delta == -1) 
            {
                for (var i = 0; i < T.Length; i++)
                {
                    var getter = TryGet(arrS, i);
                    if (getter == ' ') continue;
                    
                    if (TryGet(arrS, i) != arrT[i])
                    {
                        var added = AddOne(arrS, i, arrT[i]);
                        var joined = string.Join("", added);
                        
                        if (joined == T)
                        {
                            return Insert + " " + arrT[i];
                        }
                    }
                }
            }
            
            return Impossible;
        }

        private char[] AddOne(char[] origin, int startIndex, char added)
        {
            var arr = new char[origin.Length + 1];

            for (int i = 0; i < startIndex; i++)
            {
                arr[i] = origin[i];
            }

            arr[startIndex] = added;
            
            for (int i = startIndex + 1 ; i < origin.Length + 1; i++)
            {
                arr[i] = origin[i-1];
            }

            return arr;
        }

        private char[] SwitchTwo(char[] origin, int index1, int index2)
        {
            var switched = GetCopy(origin);
            (switched[index1], switched[index2]) = (origin[index2], origin[index1]);

            return switched;
        }

        private char[] Replace(char[] origin, int index, char replace)
        {
            var replaced = GetCopy(origin);
            replaced[index] = replace;

            return replaced;
        }

        private char[] GetCopy(char[] input)
        {
            return JsonConvert.DeserializeObject<char[]>(JsonConvert.SerializeObject(input));
        }

        private char TryGet(char[] arr, int index)
        {
            try
            {
                return arr[index];
            }
            catch (Exception)
            {
                return ' ';
            }
        }
    }
}