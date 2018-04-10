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
        ///<returns>A string in which composite bounds are represented as brackets and values are shown as their <c>ToString()</c> representations.</returns>
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

        ///<summary>Converts a marked sequence composite into a human-readable short string representation.</summary>
        ///<param name="source">The source composite.</param>
        ///<returns>A string in which composite bounds are represented as brackets and values are shown as their <c>ToString()</c> representations. Both values and composites can be preceded with <c>ToString()</c> representations of their marks in parenthesis if they are not null or empty.</returns>
        public static string ToStringShort<TMark, TPayload>(this Composite<TMark, TPayload> source)
        {
            if(source is Composite<TMark, TPayload>.MarkedComposite composite)
            {
                var innerString = string.Join(", ", composite.Item.Components.Select(x => x.ToStringShort()));
                var markString = composite.Item.Mark.ToString();
                return string.Format(string.IsNullOrEmpty(markString) ? string.Empty : "( {0} )" , markString) +
                    string.Format(string.IsNullOrEmpty(innerString) ? "[ ]" : "[ {0} ]", innerString);
            }
            else if(source is Composite<TMark, TPayload>.MarkedValue value)
            {
                var markString = value.Item.Mark.ToString();
                return string.Format(string.IsNullOrEmpty(markString) ? string.Empty : "( {0} )" , markString) +
                    value.Item.Value.ToString();
            }
            else return string.Empty;
        }
    }
}