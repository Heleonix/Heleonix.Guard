// <copyright file="HostTests.cs" company="Heleonix - Hennadii Lutsyshyn">
// Copyright (c) Heleonix - Hennadii Lutsyshyn. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the repository root for full license information.
// </copyright>

namespace Heleonix.Guard.Tests
{
    using Heleonix.Guard;
    using Heleonix.Testing.NUnit.Aaa;
    using NUnit.Framework;
    using static Heleonix.Testing.NUnit.Aaa.AaaSpec;

    /// <summary>
    /// Tests the <see cref="Host"/>.
    /// </summary>
    [ComponentTest(Type = typeof(Host))]
    public static class HostTests
    {
        /// <summary>
        /// Tests the <see cref="Host.Throw"/>.
        /// </summary>
        [MemberTest(Name = nameof(Host.Throw))]
        public static void Throw()
        {
            ExceptionRaiser exceptionBuilder1 = null;
            ExceptionRaiser exceptionBuilder2 = null;

            AaaSpec.When("the property is called two times", () =>
            {
                Act(() =>
                {
                    exceptionBuilder1 = Host.Throw;
                    exceptionBuilder2 = Host.Throw;
                });

                Should($"return the single instance of the {nameof(ExceptionRaiser)}", () =>
                {
                    Assert.That(exceptionBuilder1, Is.EqualTo(exceptionBuilder2));
                });
            });
        }

        /// <summary>
        /// Tests the <see cref="Host.When(bool)"/>.
        /// </summary>
        [MemberTest(Name = nameof(Host.When))]
        public static void When()
        {
            var result = false;

            AaaSpec.When("the method is called", () =>
            {
                Act(() =>
                {
                    result = Host.When(true);
                });

                Should("return the passed condition", () =>
                {
                    Assert.That(result, Is.True);
                });
            });
        }
    }
}