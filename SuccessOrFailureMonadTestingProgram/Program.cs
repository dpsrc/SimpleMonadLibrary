using SuccessOrFailureMonadLibrary;

using System;
using System.Linq;

namespace SuccessOrFailureMonad
{
    static class Program
    {
        static void Main(string[] args)
        {
            SuccessOrFailure<bool, int> failure = SuccessOrFailure<bool, int>.CreateFailure(false);
            Console.WriteLine(failure.ClassifyAs(failure => failure.ToString(), success => success.ToString()));

            SuccessOrFailure<bool, int> success = SuccessOrFailure<bool, int>.CreateSuccess(35);
            Console.WriteLine(success.ClassifyAs(failure => success.ToString(), success => success.ToString()));

            SuccessOrFailure<Exception, int> failureEx;
            try
            {
                int i = int.Parse("a");
                failureEx = SuccessOrFailure<Exception, int>.CreateSuccess(i);
            }
            catch (Exception ex)
            {
                failureEx = SuccessOrFailure<Exception, int>.CreateFailure(ex);
                Console.WriteLine(ex is FormatException);
                Console.WriteLine(ex is Exception);
                Console.WriteLine(ex is ArgumentNullException);
            }
            Console.WriteLine(failureEx.ClassifyAs(failure => failure.Message, success => success.ToString()));

            SuccessOrFailure<Exception, int> successEx;
            try
            {
                int i = int.Parse("4");
                successEx = SuccessOrFailure<Exception, int>.CreateSuccess(i);
            }
            catch (Exception ex)
            {
                successEx = SuccessOrFailure<Exception, int>.CreateFailure(ex);
            }
            Console.WriteLine(successEx.ClassifyAs(failure => failure.Message, success => success.ToString()));
        }

        private static SuccessOrFailure<Exception, int> ParseMonad(string s)
        {
            SuccessOrFailure<Exception, int> result;
            try
            {
                int i = int.Parse("a");
                result = SuccessOrFailure<Exception, int>.CreateSuccess(i);
            }
            catch (Exception ex)
            {
                result = SuccessOrFailure<Exception, int>.CreateFailure(ex);
                Console.WriteLine(ex is FormatException);
                Console.WriteLine(ex is Exception);
                Console.WriteLine(ex is ArgumentNullException);
            }

            return result;
        }
    }
}
