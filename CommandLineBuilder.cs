using System.Collections.Generic;
using System.Text;

namespace Snap.Data.Utility
{
    public class CommandLineBuilder
    {
        private const char WhiteSpace = ' ';
        private readonly Dictionary<string, string?> options = new();

        public CommandLineBuilder AppendIf(bool condition, string name, object? value = null)
        {
            return condition ? Append(name, value) : this;
        }

        public CommandLineBuilder Append(string name, object? value = null)
        {
            options.Add(name, value?.ToString());
            return this;
        }

        public string Build()
        {
            return ToString();
        }

        public override string ToString()
        {
            StringBuilder s = new();
            foreach (KeyValuePair<string, string?> option in options)
            {
                s.Append(WhiteSpace);
                s.Append(option.Key);
                if (!string.IsNullOrEmpty(option.Value))
                {
                    s.Append(WhiteSpace);
                    s.Append(option.Value);
                }
            }
            return s.ToString();
        }
    }
}
