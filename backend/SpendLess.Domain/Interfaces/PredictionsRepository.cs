using SpendLess.Domain.Models;

namespace SpendLess.Domain.Interfaces
{
    public interface IPredictionsRepository
    {
        Task<Prediction> GetPrediction();
    }
}

