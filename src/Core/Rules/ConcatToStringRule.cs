﻿using System;
using System.Text;

namespace OpenRasta.Sina.Rules
{
    public class ConcatToStringRule<TLeft, TRight> : 
        ConcatConvertRule<TLeft,TRight,string>
    {
        public ConcatToStringRule(Rule<TLeft> left, Rule<TRight> right)
            : base(left, right, AsString)
        {
        }
        
        static string AsString(TLeft matchLeft, TRight matchRight)
        {
            var sb = new StringBuilder(2);
            if (ReferenceEquals(matchLeft, null) == false)
                sb.Append(matchLeft);
            if (ReferenceEquals(matchRight, null) == false)
                sb.Append(matchRight);
            return sb.ToString();
        }
    }
}
