public  class Calculator
    {
        public int DivOperation(int numerator,int denominator)
        {
            Console.WriteLine($"Before Operation ..{nameof(numerator)}:{numerator} and {nameof(denominator)}: {denominator}");
            if (numerator==0 || denominator==0) { throw new ArgumentNullException(); }
            int result = default(int);
            try
            {
                result = numerator / denominator;
                
            }
            catch(DivideByZeroException ex)
            {
                throw ex;
            }
            Console.WriteLine($"End Operation ..{nameof(result)}:{result}");
            return result;

        }
    }
