﻿using System.Collections.Generic;
using System.Text;

namespace Snap.Data.Utility
{
    public class CommandLineBuilder
    {
        private const char WhiteSpace = ' ';
        private readonly Dictionary<string, string?> options = new();

        public CommandLineBuilder AppendIf(string name, bool condition, object? value = null)
        {
            return condition ? this.Append(name, value) : this;
        }

        public CommandLineBuilder Append(string name, object? value = null)
        {
            this.options.Add(name, value?.ToString());
            return this;
        }

        public string Build()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            StringBuilder s = new();
            foreach ((string key, string? value) in this.options)
            {
                s.Append(WhiteSpace);
                s.Append(key);
                if (!string.IsNullOrEmpty(value))
                {
                    s.Append(WhiteSpace);
                    s.Append(value);
                }
            }
            return s.ToString();
        }
    }
}
