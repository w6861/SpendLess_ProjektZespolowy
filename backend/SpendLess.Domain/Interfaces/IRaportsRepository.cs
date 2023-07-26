using System;
using SpendLess.Api;
using SpendLess.Domain.Models;

namespace SpendLess.Domain.Interfaces
{
    public interface IRaportsRepository
    {
        Task<Raport> GetRaport(GetRaport query);
    }
}

