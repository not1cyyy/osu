// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace osu.Game.Skinning
{
    /// <summary>
    /// A lookup type which can be used with <see cref="ISkin.GetDrawableComponent"/>.
    /// </summary>
    /// <remarks>
    /// Implementations of <see cref="ISkin.GetDrawableComponent"/> should match on types implementing this interface
    /// to scope particular lookup variations. Using this, a ruleset or skin implementation could make its own lookup
    /// type to scope away from more global contexts.
    ///
    /// More commonly, a ruleset could make use of <see cref="GameplaySkinComponentLookup{T}"/> to do a simple lookup based on
    /// a provided enum.
    /// </remarks>
    public interface ISkinComponentLookup
    {
    }
}
