using System.Text;

namespace Snap.Data.Utility
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendIf(this StringBuilder sb, bool condition,string? value)
        {
            return condition ? sb.Append(value) : sb;
        }
    }
}
