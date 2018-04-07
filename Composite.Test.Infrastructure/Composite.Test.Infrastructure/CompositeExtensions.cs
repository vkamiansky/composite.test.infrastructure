using System;
using System.Collections.Generic;
using System.Linq;

using Composite;

namespace Composite.Test.Infrastructure
{
    ///<summary>Test infrastructure functions for sequence composites.</summary>
    public static class CompositeExtensions
    {
        ///<summary>Converts a sequence composite into a human-readable short string representation.</summary>
        ///<param name="source">The source composite.</param>
        ///<returns>A string in which composite bounds are represented as brackets and values are as their <c>ToString()</c> representations.</returns>
        public static string ToStringShort<T>(this Composite<T> source)
        {
            if(source is Composite<T>.Composite composite)
            {
                var innerString = string.Join(", ", composite.Item.Select(x => x.ToStringShort()));
                return string.Format(string.IsNullOrEmpty(innerString) ? "[ ]" : "[ {0} ]", innerString);
            }
            else
                return (source as Composite<T>.Value).Item.ToString();
        }
    }
}