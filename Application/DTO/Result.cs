using System.Collections.Generic;
using Application.Currency;

namespace Application.DTO
{
    public class ResultModel<T>
    {
        // public Currencies[] Currencies { get; set; }
        public T Result { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}