// <copyright file="ExceptionRaiserTests.cs" company="Heleonix - Hennadii Lutsyshyn">
// Copyright (c) 2017-present Heleonix - Hennadii Lutsyshyn. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the repository root for full license information.
// </copyright>

namespace Heleonix.Guard.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Heleonix.Guard;
    using Heleonix.Testing.NUnit.Aaa;
    using NUnit.Framework;
    using static Heleonix.Testing.NUnit.Aaa.AaaSpec;

    /// <summary>
    /// Tests the <see cref="ExceptionRaiser"/>.
    /// </summary>
    [ComponentTest(Type = typeof(ExceptionRaiser))]
    public static class ExceptionRaiserTests
    {
        /// <summary>
        /// Tests all the exceptions having constructors <see cref="Exception.Exception(string, Exception)"/>.
        /// </summary>
        [MemberTest(Name = nameof(Exception) + "(string, Exception)")]
        public static void Exception()
        {
            var when = false;
            string message = null;
            Exception innerException = null;
            IEnumerable<MethodInfo> exceptionRaisers = null;
            var thrownExceptions = new List<Exception>();

            Arrange(() =>
            {
                exceptionRaisers = from methodInfo in typeof(ExceptionRaiser).GetMethods()
                                   let parameters = methodInfo.GetParameters()
                                   where parameters.Count() == 3
                                       && parameters[0].ParameterType == typeof(bool)
                                       && parameters[1].ParameterType == typeof(string)
                                       && parameters[2].ParameterType == typeof(Exception)
                                   select methodInfo;

                thrownExceptions.Clear();
            });

            When("exception raisers are executed", () =>
            {
                Act(() =>
                {
                    foreach (var exceptionRaiser in exceptionRaisers)
                    {
                        try
                        {
                            exceptionRaiser.Invoke(Host.Throw, new object[] { when, message, innerException });
                        }
                        catch (TargetInvocationException e)
                        {
                            thrownExceptions.Add(e.InnerException);
                        }
                    }
                });

                And("a 'when' parameter is false", () =>
                {
                    when = false;

                    Should("not throw any exception", () =>
                    {
                        Assert.That(thrownExceptions, Is.Empty);
                    });
                });

                And("a 'when' parameter is true", () =>
                {
                    when = true;

                    And("a message is provided", () =>
                    {
                        message = "exception message";

                        Should("throw all exceptions with the provided message", () =>
                        {
                            foreach (var thrownException in thrownExceptions)
                            {
                                Assert.That(thrownException.Message, Is.EqualTo(message));
                                Assert.That(thrownException.InnerException, Is.EqualTo(innerException));
                            }
                        });

                        And("an inner exception is provided", () =>
                        {
                            innerException = new Exception();

                            Should("throw all exceptions with the provided message and inner exception", () =>
                            {
                                foreach (var thrownException in thrownExceptions)
                                {
                                    Assert.That(thrownException.Message, Is.EqualTo(message));
                                    Assert.That(thrownException.InnerException, Is.EqualTo(innerException));
                                }
                            });
                        });
                    });
                });
            });
        }

        /// <summary>
        /// Tests all the exceptions having constructors <see cref="MissingFieldException.MissingFieldException(string, string)"/>.
        /// </summary>
        [MemberTest(Name = nameof(Exception) + "(string, string)")]
        public static void Exception2()
        {
            var when = false;
            string string1 = null;
            string string2 = null;
            IEnumerable<MethodInfo> exceptionRaisers = null;
            var thrownExceptions = new List<Exception>();

            Arrange(() =>
            {
                exceptionRaisers = from methodInfo in typeof(ExceptionRaiser).GetMethods()
                                   let parameters = methodInfo.GetParameters()
                                   where parameters.Count() == 3
                                       && parameters[0].ParameterType == typeof(bool)
                                       && parameters[1].ParameterType == typeof(string)
                                       && parameters[2].ParameterType == typeof(string)
                                   select methodInfo;

                thrownExceptions.Clear();
            });

            When("exception raisers are executed", () =>
            {
                Act(() =>
                {
                    foreach (var exceptionRaiser in exceptionRaisers)
                    {
                        try
                        {
                            exceptionRaiser.Invoke(Host.Throw, new object[] { when, string1, string2 });
                        }
                        catch (TargetInvocationException e)
                        {
                            thrownExceptions.Add(e.InnerException);
                        }
                    }
                });

                And("a 'when' parameter is false", () =>
                {
                    when = false;

                    Should("not throw any exception", () =>
                    {
                        Assert.That(thrownExceptions, Is.Empty);
                    });
                });

                And("a 'when' parameter is true", () =>
                {
                    when = true;

                    And("a first string is provided", () =>
                    {
                        string1 = "string 1";

                        Should("throw all exceptions with the provided first string", () =>
                        {
                            foreach (var thrownException in thrownExceptions)
                            {
                                AssertExceptionParameters(
                                    thrownException,
                                    new[] { typeof(string), typeof(string) },
                                    new[] { string1, string2 });
                            }
                        });

                        And("a second string is provided", () =>
                        {
                            string2 = "string 2";

                            Should("throw all exceptions with the provided first and second strings", () =>
                            {
                                foreach (var thrownException in thrownExceptions)
                                {
                                    AssertExceptionParameters(
                                        thrownException,
                                        new[] { typeof(string), typeof(string) },
                                        new[] { string1, string2 });
                                }
                            });
                        });
                    });
                });
            });
        }

        /// <summary>
        /// Tests all the exceptions having constructors <see cref="FileLoadException.FileLoadException(string, string, Exception)"/>.
        /// </summary>
        [MemberTest(Name = nameof(Exception) + "(string, string, Exception)")]
        public static void Exception3()
        {
            var when = false;
            string string1 = null;
            string string2 = null;
            Exception innerException = null;
            IEnumerable<MethodInfo> exceptionRaisers = null;
            var thrownExceptions = new List<Exception>();

            Arrange(() =>
            {
                exceptionRaisers = from methodInfo in typeof(ExceptionRaiser).GetMethods()
                                   let parameters = methodInfo.GetParameters()
                                   where parameters.Count() == 4
                                       && parameters[0].ParameterType == typeof(bool)
                                       && parameters[1].ParameterType == typeof(string)
                                       && parameters[2].ParameterType == typeof(string)
                                       && parameters[3].ParameterType == typeof(Exception)
                                   select methodInfo;

                thrownExceptions.Clear();
            });

            When("exception raisers are executed", () =>
            {
                Act(() =>
                {
                    foreach (var exceptionRaiser in exceptionRaisers)
                    {
                        try
                        {
                            exceptionRaiser.Invoke(Host.Throw, new object[] { when, string1, string2, innerException });
                        }
                        catch (TargetInvocationException e)
                        {
                            thrownExceptions.Add(e.InnerException);
                        }
                    }
                });

                And("a 'when' parameter is false", () =>
                {
                    when = false;

                    Should("not throw any exception", () =>
                    {
                        Assert.That(thrownExceptions, Is.Empty);
                    });
                });

                And("a 'when' parameter is true", () =>
                {
                    when = true;

                    And("a first string is provided", () =>
                    {
                        string1 = "string 1";

                        Should("throw all exceptions with the provided first string", () =>
                        {
                            foreach (var thrownException in thrownExceptions)
                            {
                                AssertExceptionParameters(
                                    thrownException,
                                    new[] { typeof(string), typeof(string), typeof(Exception) },
                                    new object[] { string1, string2, innerException });
                            }
                        });

                        And("a second string is provided", () =>
                        {
                            string2 = "string 2";

                            Should("throw all exceptions with the provided first and second strings", () =>
                            {
                                foreach (var thrownException in thrownExceptions)
                                {
                                    AssertExceptionParameters(
                                        thrownException,
                                        new[] { typeof(string), typeof(string), typeof(Exception) },
                                        new object[] { string1, string2, innerException });
                                }
                            });

                            And("an inner exception is provided", () =>
                            {
                                innerException = new Exception();

                                Should("throw all exceptions with the provided first string, second string and inner exception", () =>
                                {
                                    foreach (var thrownException in thrownExceptions)
                                    {
                                        AssertExceptionParameters(
                                            thrownException,
                                            new[] { typeof(string), typeof(string), typeof(Exception) },
                                            new object[] { string1, string2, innerException });
                                    }
                                });
                            });
                        });
                    });
                });
            });
        }

        /// <summary>
        /// Tests the <see cref="ExceptionRaiser.TaskCanceledException(bool, Task)"/>.
        /// </summary>
        [MemberTest(Name = nameof(ExceptionRaiser.TaskCanceledException) + "(bool, Task)")]
        public static void TaskCanceledException()
        {
            var when = false;
            TaskCanceledException thrownException = null;

            When("exception raiser is executed", () =>
            {
                Act(() =>
                {
                    try
                    {
                        using (var task = new Task(() => { }))
                        {
                            task.Start();
                            task.Wait();

                            Host.Throw.TaskCanceledException(when, task);
                        }
                    }
                    catch (TaskCanceledException e)
                    {
                        thrownException = e;
                    }
                });

                And("a 'when' parameter is false", () =>
                {
                    when = false;

                    Should("not throw any exception", () =>
                    {
                        Assert.That(thrownException, Is.Null);
                    });
                });

                And("a 'when' parameter is true", () =>
                {
                    when = true;

                    Should("throw the tested exception", () =>
                    {
                        Assert.That(thrownException, Is.InstanceOf<TaskCanceledException>());
                    });
                });
            });
        }

        /// <summary>
        /// Tests the <see cref="ExceptionRaiser.InvalidCastException(bool, string, int)"/>.
        /// </summary>
        [MemberTest(Name = nameof(ExceptionRaiser.InvalidCastException) + "(bool, string, int)")]
        public static void InvalidCastException()
        {
            var when = false;
            InvalidCastException thrownException = null;

            When("exception raiser is executed", () =>
            {
                Act(() =>
                {
                    try
                    {
                        Host.Throw.InvalidCastException(when, "message", 1);
                    }
                    catch (InvalidCastException e)
                    {
                        thrownException = e;
                    }
                });

                And("a 'when' parameter is false", () =>
                {
                    when = false;

                    Should("not throw any exception", () =>
                    {
                        Assert.That(thrownException, Is.Null);
                    });
                });

                And("a 'when' parameter is true", () =>
                {
                    when = true;

                    Should("throw the tested exception", () =>
                    {
                        Assert.That(thrownException, Is.InstanceOf<InvalidCastException>());
                    });
                });
            });
        }

        /// <summary>
        /// Tests the <see cref="ExceptionRaiser.ArgumentOutOfRangeException(bool, string, object, string)"/>.
        /// </summary>
        [MemberTest(Name = nameof(ExceptionRaiser.ArgumentOutOfRangeException) + "(bool, string, object, string)")]
        public static void ArgumentOutOfRangeException()
        {
            var when = false;
            ArgumentOutOfRangeException thrownException = null;

            When("exception raiser is executed", () =>
            {
                Act(() =>
                {
                    try
                    {
                        Host.Throw.ArgumentOutOfRangeException(when, "param1", 123, "message");
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        thrownException = e;
                    }
                });

                And("a 'when' parameter is false", () =>
                {
                    when = false;

                    Should("not throw any exception", () =>
                    {
                        Assert.That(thrownException, Is.Null);
                    });
                });

                And("a 'when' parameter is true", () =>
                {
                    when = true;

                    Should("throw the tested exception", () =>
                    {
                        Assert.That(thrownException, Is.InstanceOf<ArgumentOutOfRangeException>());
                    });
                });
            });
        }

        /// <summary>
        /// Tests the <see cref="ExceptionRaiser.AggregateException(bool, string, Exception[])"/>.
        /// </summary>
        [MemberTest(Name = nameof(ExceptionRaiser.AggregateException) + "(bool, string, Exception[])")]
        public static void AggregateException()
        {
            var when = false;
            AggregateException thrownException = null;

            When("exception raiser is executed", () =>
            {
                Act(() =>
                {
                    try
                    {
                        Host.Throw.AggregateException(when, "param1", new Exception[] { new Exception() });
                    }
                    catch (AggregateException e)
                    {
                        thrownException = e;
                    }
                });

                And("a 'when' parameter is false", () =>
                {
                    when = false;

                    Should("not throw any exception", () =>
                    {
                        Assert.That(thrownException, Is.Null);
                    });
                });

                And("a 'when' parameter is true", () =>
                {
                    when = true;

                    Should("throw the tested exception", () =>
                    {
                        Assert.That(thrownException, Is.InstanceOf<AggregateException>());
                    });
                });
            });
        }

        /// <summary>
        /// Tests the <see cref="ExceptionRaiser.OperationCanceledException(bool, string, Exception, CancellationToken?)"/>.
        /// </summary>
        [MemberTest(Name = nameof(ExceptionRaiser.OperationCanceledException) + "(bool, string, Exception, CancellationToken?)")]
        public static void OperationCanceledException()
        {
            var when = false;
            OperationCanceledException thrownException = null;
            CancellationToken? cancellationToken = null;

            When("exception raiser is executed", () =>
            {
                Act(() =>
                {
                    try
                    {
                        Host.Throw.OperationCanceledException(when, "message", new Exception(), cancellationToken);
                    }
                    catch (OperationCanceledException e)
                    {
                        thrownException = e;
                    }
                });

                And("a 'when' parameter is false", () =>
                {
                    when = false;

                    Should("not throw any exception", () =>
                    {
                        Assert.That(thrownException, Is.Null);
                    });
                });

                And("a 'when' parameter is true", () =>
                {
                    when = true;

                    And("a cancellation token is not provided", () =>
                    {
                        cancellationToken = null;

                        Should("throw the tested exception with CancellationToken.None", () =>
                        {
                            Assert.That(thrownException, Is.InstanceOf<OperationCanceledException>());
                            Assert.That(thrownException.CancellationToken, Is.EqualTo(CancellationToken.None));
                        });
                    });

                    And("a cancellation token is provided", () =>
                    {
                        cancellationToken = new CancellationToken(true);

                        Should("throw the tested exception with the provided cancellation token", () =>
                        {
                            Assert.That(thrownException, Is.InstanceOf<OperationCanceledException>());
                            Assert.That(thrownException.CancellationToken, Is.EqualTo(cancellationToken));
                        });
                    });
                });
            });
        }

        private static void AssertExceptionParameters(Exception e, Type[] ctorParamTypes, object[] expectedParams)
        {
            var ctorParams = e.GetType().GetConstructor(ctorParamTypes).GetParameters();

            for (int i = 0; i < ctorParams.Length; i++)
            {
                var ctorParamName = ctorParams[i].Name;
                var propName = char.ToUpper(ctorParamName[0], CultureInfo.CurrentCulture) + ctorParamName.Substring(1);

                if (propName != "Message")
                {
                    var propInfo = e.GetType().GetProperty(propName);

                    if (propInfo != null)
                    {
                        Assert.That(propInfo.GetValue(e), Is.EqualTo(expectedParams[i]));
                    }
                    else if (expectedParams[i] is string)
                    {
                        Assert.That(e.Message, Contains.Substring(expectedParams[i].ToString()));
                    }
                }
                else if (expectedParams[i] != null)
                {
                    Assert.That(e.Message, Contains.Substring(expectedParams[i].ToString()));
                }
            }
        }
    }
}
