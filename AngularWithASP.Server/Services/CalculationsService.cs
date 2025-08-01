using AngularWithASP.Server.DTOs;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AngularWithASP.Server.Services
{
    public class CalculationsService : ICalculationsService
    {
        int mulsum = 0;
        int mul3or5Sum = 0;
       public int GetSumOfCountByThrees(int n)
        {
            if (n > 0)
            {
                int sum = 0;
                for (int i = 1; i <= n; i++)
                {
                    if (i % 3 == 0)
                    {
                        sum += i;
                    }
                }
                return sum;
            }
            else return 0;
        }
        public int calculateMNSum(int m, int n)
        {
            if (n > m)
            {
                int sum = 0;
                for(int i =m; i <= n; i++)
                {
                    sum += i;
                }
                return sum;
            }
            else
                return 0;
        }
        public int calculateMNProduct(int m, int n)
        {
            if (n > m)
            {
                int sum = 1;
                for (int i = m; i <= n; i++)
                {
                    sum *= i;
                }
                return sum;
            }
            else
                return 0;
        }
        public bool calculateMult3or5(int n)
        {
            if (n > 0)
            {
                if (n % 3 == 0 || n % 5 == 0)
                    return true;
                else return false;
            }
            return false;
        }
        public int calculateSumOfNotMult3or5(int n)
        {
            if (n > 0)
            {
                if (!calculateMult3or5(n))
                    mulsum += n;
                calculateSumOfNotMult3or5(n - 1);
            }
            return mulsum;
        }
        public bool endsWith3or5(int n)
        {
            if (n % 10 == 3 || n % 10 == 5)
                return true;
            else return false;
        }
        public int calculateSumOfEndsWith3or5(int n)
        {
            if (n > 0)
            {
                if (endsWith3or5(n))
                    mul3or5Sum += n;
                n--;
                calculateSumOfEndsWith3or5(n);
            }
            return mul3or5Sum;
        }
        public bool calculateIsBouncy(int n)
        {
            if (n > 0)
            {
                //get one's digit
                int ones = n % 10;
                int tens = (n / 10) % 10;
                int hunds = n / 100;
                if (tens > ones && hunds < tens)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public BouncyObjects calculateSumOfBouncy(int m, int n)
        {
            BouncyObjects bouncyObj = new BouncyObjects();
            if (n > m)
            {
                
                List<int> bouncy = new List<int>();
                int sum = 1;
                for (int i = m; i <= n; i++)
                {
                    if (calculateIsBouncy(i))
                    {
                        bouncy.Add(i);
                        sum += i;
                    }
                }
                bouncyObj.Sum = sum;
                bouncyObj.Bouncy = bouncy;
                return bouncyObj;
            }
            else
                return bouncyObj;
        }

    }
}
