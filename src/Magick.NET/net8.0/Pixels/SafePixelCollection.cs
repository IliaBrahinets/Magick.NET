﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if !NETSTANDARD2_0

using System;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick;

internal sealed partial class SafePixelCollection
{
    public override ReadOnlySpan<QuantumType> GetReadOnlyArea(int x, int y, uint width, uint height)
    {
        CheckArea(x, y, width, height);

        return base.GetReadOnlyArea(x, y, width, height);
    }

    public override ReadOnlySpan<QuantumType> GetReadOnlyArea(IMagickGeometry geometry)
    {
        Throw.IfNull(geometry);

        return base.GetReadOnlyArea(geometry);
    }

    public override void SetArea(int x, int y, uint width, uint height, ReadOnlySpan<QuantumType> values)
    {
        CheckValues(x, y, width, height, values);

        base.SetArea(x, y, width, height, values);
    }

    public override void SetArea(IMagickGeometry geometry, ReadOnlySpan<QuantumType> values)
    {
        Throw.IfNull(geometry);

        base.SetArea(geometry, values);
    }

    public override void SetPixels(ReadOnlySpan<QuantumType> values)
    {
        CheckValues(values);

        base.SetPixels(values);
    }

    private void CheckValues<T>(ReadOnlySpan<T> values)
        => CheckValues(0, 0, values);

    private void CheckValues<T>(int x, int y, ReadOnlySpan<T> values)
        => CheckValues(x, y, Image.Width, Image.Height, values);

    private void CheckValues<T>(int x, int y, uint width, uint height, ReadOnlySpan<T> values)
    {
        CheckIndex(x, y);
        Throw.IfEmpty(values);
        Throw.IfFalse(values.Length % Channels == 0, nameof(values), "Values should have {0} channels.", Channels);

        var length = values.Length;
        var max = width * height * Channels;
        Throw.IfTrue(length > max, nameof(values), "Too many values specified.");

        length = (x * y * (int)Channels) + length;
        max = Image.Width * Image.Height * Channels;
        Throw.IfTrue(length > max, nameof(values), "Too many values specified.");
    }
}

#endif
