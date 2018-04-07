using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite.Test.Infrastructure
{
    ///<summary>Test infrastructure functions for enumerable sequences.</summary>
    public static class EnumerableExtensions
    {
        private const string  _AsLimitedWalkPastLimitErrorMessage = "You've attempted to iterate past the limit"
                                                                    + "designated for the maximum number of elements" 
                                                                    + "produced by this enumerable.";
        ///<summary>Converts a sequence into another sequence from which the user is allowed to take no more than the given number of elements.</summary>
        ///<param name="source">The source sequence.</param>
        ///<param name="limit">The maximum number of elements the user is allowed to take from the sequence.</param>
        ///<returns>A sequence with as many elements as the source but only a limited number of them available for the taking.</returns>
        ///<exception cref="System.InvalidOperationException">Thrown when the limit of elements available for the taken is exceeded by the user code.</exception>
        public static IEnumerable<T> AllowTake<T>(this IEnumerable<T> source, int limit)
        {            
            if(limit < 1)
            {
                throw new InvalidOperationException(_AsLimitedWalkPastLimitErrorMessage);
            }
            var i = 0;
            foreach (var element in source)
                if (i++ < limit) yield return element;
                else throw new InvalidOperationException(_AsLimitedWalkPastLimitErrorMessage);
        }

        ///<summary>Introduces a side effect into the proccess of iteration of the source sequence.</summary>
        ///<param name="source">The source sequence.</param>
        ///<param name="sideEffect">The side effect.</param>
        ///<returns>A sequence with a a side effect.</returns>
        public static IEnumerable<T> WithSideEffect<T>(this IEnumerable<T> source, Action<T> sideEffect)
        {
            return source.Select(x =>
            {
                sideEffect(x);
                return x;
            });
        }
    }
}