﻿using System;
using System.Threading.Tasks;
using Application.Currency;

namespace Application.Services
{
    public interface IExchangeRateService
    {
        Task<Currencies[]> CurrenciesAsync(DateTime fromDate, DateTime toDate);
    }
}