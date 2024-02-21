﻿namespace ExercicioLoja.CustomExceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; }

        public CustomException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

    }
}
