using CantinaFacil.Shared.Kernel.Domain.Exceptions;
using System;

namespace CantinaFacil.Shared.Kernel.GuardCauses
{
    public class Guard 
    {
        public static void Requires(Func<bool> predicate, string message)
        {
            if (predicate()) 
                return;
            
            throw new ArgumentException(message);
        }

        public static T Null<T>(T input, string parameterName)
        {
            if (input is null)
                throw new ArgumentException($"{parameterName} não pode ser nulo.");

            return input;
        }
    }

    public class DomainGuard
    {   
        public static T Null<T>(T input, string message)
        {
            if (input is null)
                throw new DomainException(message);

            return input;
        }
    }
}
