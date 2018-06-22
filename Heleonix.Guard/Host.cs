// <copyright file="Host.cs" company="Heleonix - Hennadii Lutsyshyn">
// Copyright (c) 2017-present Heleonix - Hennadii Lutsyshyn. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the repository root for full license information.
// </copyright>

namespace Heleonix.Guard
{
    /// <summary>
    /// Represents the entry point to code guards.
    /// </summary>
    public static class Host
    {
        /// <summary>
        /// Gets the <see cref="ExceptionRaiser"/>.
        /// </summary>
        /// <value>
        /// The <see cref="ExceptionRaiser"/>.
        /// </value>
        public static ExceptionRaiser Throw { get; } = new ExceptionRaiser();

        /// <summary>
        /// Provides a condition to throw an exception.
        /// Use <c>when: [your condition]</c> to throw an exception in C# 7.2 or later.
        /// </summary>
        /// <param name="when">A condition to throw an exception.</param>
        /// <returns>The passed <paramref name="when"/> value.</returns>
        public static bool When(bool when) => when;
    }
}