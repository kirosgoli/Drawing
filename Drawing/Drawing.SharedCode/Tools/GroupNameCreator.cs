using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.SharedCode.Tools
{
    public static class GroupNameCreator
    {
        private static string DEFAULT_CHARACTERS = "abcdefghijklmnopqrstuvwxyz".ToUpper();
        public static string CreateGroupNameFromNumber(int groupNumber)
        {

            //Stack<string> stack = new Stack<string>()
            //int length =  DEFAULT_CHARACTERS.Length;
            //while (groupNumber> 0)
            //{
            //    int index;
            //    if (groupNumber % length == 0)
            //        index = length - 1;
            //    else
            //        index = groupNumber % length -1;
            //    stack.Push(DEFAULT_CHARACTERS[index]);
            //    groupNumber -= length;
            //}
            //return builder.ToString();
            groupNumber--;
            if (groupNumber == 0)
                return DEFAULT_CHARACTERS[groupNumber].ToString();
            int length = DEFAULT_CHARACTERS.Length;
            int places = (int)Math.Floor(Math.Log(groupNumber,length));
            StringBuilder sb = new StringBuilder();
            for (int i = places; i > 0; i--)
            {
                int iloczyn = (int)Math.Floor((groupNumber / Math.Pow(length, i)));
                sb.Append(DEFAULT_CHARACTERS[iloczyn-1]);
                groupNumber -= (int)(iloczyn*Math.Pow(length, i));
            }
                if (groupNumber == 0)
                    sb.Append(DEFAULT_CHARACTERS[groupNumber]);
                else
                    sb.Append(DEFAULT_CHARACTERS[groupNumber % length ]);
            return sb.ToString();
        }
    }
}
