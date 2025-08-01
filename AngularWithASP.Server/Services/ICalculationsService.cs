using AngularWithASP.Server.DTOs;

namespace AngularWithASP.Server.Services
{
    public interface ICalculationsService
    {
        public int GetSumOfCountByThrees(int n);
        public int calculateMNSum(int m, int n);
        public int calculateMNProduct(int m, int n);
        public bool calculateMult3or5(int n);
        public int calculateSumOfNotMult3or5(int n);
        public int calculateSumOfEndsWith3or5(int n);
        public bool calculateIsBouncy(int n);
        public BouncyObjects calculateSumOfBouncy(int m, int n);
    }
}
