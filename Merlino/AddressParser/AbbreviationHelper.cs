using System.Collections.Generic;

namespace Merlino.AddressParser
{
    public static class AbbreviationHelper
    {
        public static readonly Dictionary<string, string> Abbreviations = new Dictionary<string, string>
        {
            { "V.", "Via" },
            { "Piazz.", "Piazza" },
            { "Corso", "Corso" },
            { "Viale", "Viale" },
            { "Largo", "Largo" },
        };

        public static string ExpandAbbreviations(string input)
        {
            foreach (var abbrev in Abbreviations)
            {
                // Trova l'abbreviazione senza fare distinzione tra maiuscole/minuscole
                int index = input.IndexOf(abbrev.Key, System.StringComparison.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    // Sostituisci l'abbreviazione con il testo completo
                    input = input.Substring(0, index) + abbrev.Value + input.Substring(index + abbrev.Key.Length);
                }
            }
            return input;
        }
    }
}
