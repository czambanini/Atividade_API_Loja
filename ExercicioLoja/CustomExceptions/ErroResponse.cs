﻿namespace ExercicioLoja.CustomExceptions
{
    public class ErroResponse
    {
        public string Titulo { get; set; }
        public string Detalhes { get; set; }
        public int StatusCode { get; set; }
    }
}
