﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using System;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Game.Graphics;
using osu.Game.Graphics.UserInterface;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Overlays.Volume
{
    public partial class MuteButton : OsuButton, IHasCurrentValue<bool>
    {
        private readonly Bindable<bool> current = new Bindable<bool>();

        public Bindable<bool> Current
        {
            get => current;
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                current.UnbindBindings();
                current.BindTo(value);
            }
        }

        private Color4 hoveredColour, unhoveredColour;

        private const float width = 100;
        public const float HEIGHT = 35;

        public MuteButton()
        {
            Content.BorderThickness = 3;
            Content.CornerRadius = HEIGHT / 2;
            Content.CornerExponent = 2;

            Size = new Vector2(width, HEIGHT);

            Action = () => Current.Value = !Current.Value;
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            hoveredColour = colours.YellowDark;

            Content.BorderColour = unhoveredColour = colours.Gray1;
            BackgroundColour = colours.Gray1;

            SpriteIcon icon;

            AddRange(new Drawable[]
            {
                icon = new SpriteIcon
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                }
            });

            Current.BindValueChanged(muted =>
            {
                icon.Icon = muted.NewValue ? FontAwesome.Solid.VolumeMute : FontAwesome.Solid.VolumeUp;
                icon.Size = new Vector2(muted.NewValue ? 18 : 20);
                icon.Margin = new MarginPadding { Right = muted.NewValue ? 2 : 0 };
            }, true);
        }

        protected override bool OnHover(HoverEvent e)
        {
            Content.TransformTo<Container<Drawable>, ColourInfo>("BorderColour", hoveredColour, 500, Easing.OutQuint);
            return false;
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            Content.TransformTo<Container<Drawable>, ColourInfo>("BorderColour", unhoveredColour, 500, Easing.OutQuint);
        }
    }
}
