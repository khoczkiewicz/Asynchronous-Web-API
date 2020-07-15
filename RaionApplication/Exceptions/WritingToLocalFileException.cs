// <copyright file="WritingToLocalFileException.cs" company="RAION SOFTWARE Sp. z o.o.">
// Copyright (c) RAION SOFTWARE Sp. z o.o.. All rights reserved.
// </copyright>

namespace RaionApplication.Extensions
{
    using System;

    public class WritingToLocalFileException : Exception
    {
        public static readonly string ErrorMesage = "An error occurred:";

        public WritingToLocalFileException(string message)
            : base($"{ErrorMesage} {message}")
        {
            // Empty
        }

        public WritingToLocalFileException(string message, Exception innerException)
            : base($"{ErrorMesage} {message} - {innerException.Message}", innerException)
        {
            // Empty
        }
    }
}
