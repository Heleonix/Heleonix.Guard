// <copyright file="ExceptionRaiser.cs" company="Heleonix - Hennadii Lutsyshyn">
// Copyright (c) Heleonix - Hennadii Lutsyshyn. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the repository root for full license information.
// </copyright>

namespace Heleonix.Guard
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Security.Authentication;
    using System.Threading;
    using System.Threading.Tasks;
#if !NETSTANDARD1_6
    using System.Runtime.Serialization;
#endif

    /// <summary>
    /// Provides raising of exceptions with building of conditions to throw them.
    /// </summary>
    public class ExceptionRaiser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionRaiser"/> class.
        /// </summary>
        internal ExceptionRaiser()
        {
        }

#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CC0091 // Use static method
        /// <summary>
        /// Raises the <see cref="System.ArgumentNullException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        public void ArgumentNullException(bool when, string paramName = null, string message = null)
        {
            if (when)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.ArgumentNullException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void ArgumentNullException(bool when, string message, Exception innerException)
        {
            if (when)
            {
                throw new ArgumentNullException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="innerException">The inner exception.</param>
        public void ArgumentException(
            bool when,
            string message = null,
            string paramName = null,
            Exception innerException = null)
        {
            if (when)
            {
                throw new ArgumentException(message, paramName, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="actualValue">The value of the argument that causes this exception. </param>
        /// <param name="message">The message.</param>
        public void ArgumentOutOfRangeException(
            bool when,
            string paramName = null,
            object actualValue = null,
            string message = null)
        {
            if (when)
            {
                throw new ArgumentOutOfRangeException(paramName, actualValue, message);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void ArgumentOutOfRangeException(bool when, string message, Exception innerException)
        {
            if (when)
            {
                throw new ArgumentOutOfRangeException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.InvalidCastException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void InvalidCastException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new InvalidCastException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.InvalidCastException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="errorCode">The error code (HRESULT).</param>
        public void InvalidCastException(bool when, string message, int errorCode)
        {
            if (when)
            {
                throw new InvalidCastException(message, errorCode);
            }
        }

        /// <summary>
        /// Raises the <see cref="AggregateException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerExceptions">The inner exceptions.</param>
        public void AggregateException(bool when, string message = null, params Exception[] innerExceptions)
        {
            if (when)
            {
                throw new AggregateException(message, innerExceptions);
            }
        }

        /// <summary>
        /// Raises the <see cref="FileNotFoundException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="innerException">The inner exception.</param>
        public void FileNotFoundException(
            bool when,
            string message = null,
            string fileName = null,
            Exception innerException = null)
        {
            if (when)
            {
                throw new FileNotFoundException(message, fileName, innerException);
            }
        }

        /// <summary>
        /// Raises
        /// the <see cref="System.Threading.Tasks.TaskCanceledException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void TaskCanceledException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new TaskCanceledException(message, innerException);
            }
        }

        /// <summary>
        /// Raises
        /// the <see cref="System.Threading.Tasks.TaskCanceledException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="task">The task.</param>
        public void TaskCanceledException(bool when, Task task)
        {
            if (when)
            {
                throw new TaskCanceledException(task);
            }
        }

        /// <summary>
        /// Raises the <see cref="OperationCanceledException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="token">The cancellation token.</param>
        public void OperationCanceledException(
            bool when,
            string message = null,
            Exception innerException = null,
            CancellationToken? token = null)
        {
            if (when)
            {
                throw new OperationCanceledException(message, innerException, token ?? CancellationToken.None);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void Exception(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message, innerException);
#pragma warning restore S112 // General exceptions should never be thrown
            }
        }

        /// <summary>
        /// Raises the <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void InvalidOperationException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new InvalidOperationException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="InvalidDataException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void InvalidDataException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new InvalidDataException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="IndexOutOfRangeException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void IndexOutOfRangeException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new IndexOutOfRangeException(message, innerException);
#pragma warning restore S112 // General exceptions should never be thrown
            }
        }

        /// <summary>
        /// Raises the <see cref="FormatException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void FormatException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new FormatException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="NullReferenceException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void NullReferenceException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new NullReferenceException(message, innerException);
#pragma warning restore S112 // General exceptions should never be thrown
            }
        }

        /// <summary>
        /// Raises the <see cref="NotImplementedException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void NotImplementedException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new NotImplementedException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void NotSupportedException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new NotSupportedException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="TimeoutException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void TimeoutException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new TimeoutException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="KeyNotFoundException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void KeyNotFoundException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new KeyNotFoundException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="UnauthorizedAccessException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void UnauthorizedAccessException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new UnauthorizedAccessException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="AmbiguousMatchException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void AmbiguousMatchException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new AmbiguousMatchException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="TypeLoadException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void TypeLoadException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new TypeLoadException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="DllNotFoundException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void DllNotFoundException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new DllNotFoundException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="DirectoryNotFoundException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void DirectoryNotFoundException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new DirectoryNotFoundException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="PathTooLongException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void PathTooLongException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new PathTooLongException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="FileLoadException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="innerException">The inner exception.</param>
        public void FileLoadException(
            bool when,
            string message = null,
            string fileName = null,
            Exception innerException = null)
        {
            if (when)
            {
                throw new FileLoadException(message, fileName, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.MissingMemberException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="className">The class name.</param>
        /// <param name="memberName">The member name.</param>
        public void MissingMemberException(bool when, string className = null, string memberName = null)
        {
            if (when)
            {
                throw new MissingMemberException(className, memberName);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.MissingMemberException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void MissingMemberException(bool when, string message, Exception innerException)
        {
            if (when)
            {
                throw new MissingMemberException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.MissingFieldException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="className">The class name.</param>
        /// <param name="fieldName">The field name.</param>
        public void MissingFieldException(bool when, string className = null, string fieldName = null)
        {
            if (when)
            {
                throw new MissingFieldException(className, fieldName);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.MissingFieldException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void MissingFieldException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new MissingFieldException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.MissingMethodException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="className">The class name.</param>
        /// <param name="methodName">The method name.</param>
        public void MissingMethodException(bool when, string className = null, string methodName = null)
        {
            if (when)
            {
                throw new MissingMethodException(className, methodName);
            }
        }

        /// <summary>
        /// Raises the <see cref="System.MissingMethodException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void MissingMethodException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new MissingMethodException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="InvalidCredentialException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void InvalidCredentialException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new InvalidCredentialException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="AuthenticationException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void AuthenticationException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new AuthenticationException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="DriveNotFoundException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void DriveNotFoundException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new DriveNotFoundException(message, innerException);
            }
        }

        /// <summary>
        /// Raises the <see cref="SerializationException"/>.
        /// </summary>
        /// <param name="when">A condition to throw the exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public void SerializationException(bool when, string message = null, Exception innerException = null)
        {
            if (when)
            {
                throw new SerializationException(message, innerException);
            }
        }
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore CC0091 // Use static method
    }
}
