﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenRasta.Sina.Rules;

namespace Tests.abnf
{
    public static class Character
    {
        public static void ShouldMatch(this Rule<string> rule, params string[] values)
        {
            rule.ShouldMatch((IEnumerable<string>)values);
        }

        public static void ShouldMatch(this Rule<char> rule, params string[] values)
        {
            rule.ShouldMatch((IEnumerable<string>)values);
        }

        public static void ShouldMatch(this Rule<char> rule, IEnumerable<string> values)
        {
            rule.ShouldMatch(values, _ => _[0]);
        }

        public static void ShouldMatch(this Rule<string> rule, IEnumerable<string> values)
        {
            rule.ShouldMatch(values, _ => _);
        }

        public static void ShouldMatch<T>(this Rule<T> rule, IEnumerable<string> values, Func<string, T> expected)
        {
            foreach (var value in values)
                rule.Match(value).ShouldMatch(expected(value));
        }

        public static void ShouldMatch(this Rule<char> rule, char value)
        {
            rule.Match(value + string.Empty).ShouldMatch(value);
        }

        public static void ShouldMatch(this Rule<string> rule, string value)
        {
            rule.Match(value).ShouldMatch(value);
        }

        public static string[] To(this char start, char end)
        {
            return Enumerable.Range(start, end - start).Select(_ => (char)_ + string.Empty).ToArray();
        }
    }
}
