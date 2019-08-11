using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace xam.native.core.Helpers
{
    public static class Validations
    {
        public async static Task<bool> NotNull(object Item)
        {
            return await Task.Run(() => Item != null ? true : false);
        }

        //Regex
        //Must have at least one letter and one number
        //abc123, dr41112dsfde, 12345gbvd pass
        //abc, 987432123 fail
        public static async Task<bool> InclusionAndExclusionRulesCheck(string input)
        {
            return await Task.Run(() => Regex.IsMatch(input, @"^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$"));
        }

        public static async Task<bool> CheckLength(string text)
        {
            return await Task.Run(() => (text.Length > 4 && text.Length < 13) ? true : false);
        }

        //Regex
        //No Repeating Sequence of 3 of any char or substring 
        //Allowing aa but not aaa due to the common possiblity of a single char repeated in some cases ie password Cliff12s
        //pass aa, abcabc
        //fail aaa, abcabcabc, aabbaaa
        public static async Task<bool> CheckRepeatedSequence(string input)
        { 
            return await Task.Run(() =>
            {
                if (input == null || input.Length == 1)
                {
                    return false;
                }
                else
                {
                    return Regex.IsMatch(input, @".*(.+).*\1.*\1.*");
                }
            });
        }
    }


}

