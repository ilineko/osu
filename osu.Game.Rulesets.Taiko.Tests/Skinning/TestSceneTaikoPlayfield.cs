// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Extensions.IEnumerableExtensions;
using osu.Framework.Graphics;
using osu.Framework.Testing;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Taiko.Skinning;
using osu.Game.Rulesets.Taiko.UI;
using osu.Game.Rulesets.UI.Scrolling;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Taiko.Tests.Skinning
{
    public class TestSceneTaikoPlayfield : TaikoSkinnableTestScene
    {
        public override IReadOnlyList<Type> RequiredTypes => base.RequiredTypes.Concat(new[]
        {
            typeof(TaikoHitTarget),
            typeof(TaikoLegacyHitTarget),
            typeof(PlayfieldBackgroundRight),
        }).ToList();

        [Cached(typeof(IScrollingInfo))]
        private ScrollingTestContainer.TestScrollingInfo info = new ScrollingTestContainer.TestScrollingInfo
        {
            Direction = { Value = ScrollingDirection.Left },
            TimeRange = { Value = 5000 },
        };

        public TestSceneTaikoPlayfield()
        {
            AddStep("Load playfield", () => SetContents(() => new TaikoPlayfield(new ControlPointInfo())
            {
                Anchor = Anchor.CentreLeft,
                Origin = Anchor.CentreLeft,
            }));

            AddRepeatStep("change height", () => this.ChildrenOfType<TaikoPlayfield>().ForEach(p => p.Height = Math.Max(0.2f, (p.Height + 0.2f) % 1f)), 50);
        }
    }
}
