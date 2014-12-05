﻿using OpenRasta.Sina;
using OpenRasta.Sina.Rules;
using Tests.contexts;
using Xunit;

namespace Tests.cardinals.textual
{
    public class matches_once_or_more : parsing_text_to<string>
    {
        public matches_once_or_more()
        {
            given_rule(Grammar.Character('z').AtLeast(1));
            when_matching("a", "z", "zz");
        }

        [Fact]
        public void match_inside_range()
        {
            results[1].ShouldMatch("z");
            results[2].ShouldMatch("zz");
        }

        [Fact]
        public void no_match_outside_of_range()
        {
            results[0].ShouldNotMatch();
        }
    }
}
