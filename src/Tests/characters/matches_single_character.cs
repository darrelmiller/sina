﻿using OpenRasta.Sina;
using Should;
using Tests.contexts;
using Xunit;

namespace Tests.characters
{
    public class matches_single_character : parsing_text_to<char>
    {
        public matches_single_character()
        {
            given_rule(Grammar.Character('a'));
            when_matching("a");
        }

        [Fact]
        public void is_successful()
        {
            result.ShouldMatch('a');
        }

        [Fact]
        public void position_in_in_put_is_set()
        {
            input.Position.ShouldEqual(1);
        }
    }
}
