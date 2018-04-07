namespace Composite.Test.Infrastructure
{
    ///<summary>A simple class designed to use as a sample type in cases where generics are involved.</summary>
    public class Simple
    {
        ///<summary>A sample int payload.</summary>
        public int Number { get; set; }

        ///<summary>The string representation of the sample class.</summary>
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}