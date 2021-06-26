// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if NETSTANDARD

using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageMagick
{
    /// <content/>
    public partial interface IMagickImage<TQuantumType> : IMagickImage, IEquatable<IMagickImage<TQuantumType>>, IComparable<IMagickImage<TQuantumType>>
        where TQuantumType : struct
    {
        /// <summary>
        /// Read single image frame.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task ReadAsync(Stream stream, IMagickReadSettings<TQuantumType>? readSettings);

        /// <summary>
        /// Read single image frame from pixel data.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <param name="settings">The pixel settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task ReadPixelsAsync(Stream stream, IPixelReadSettings<TQuantumType>? settings);
    }
}

#endif