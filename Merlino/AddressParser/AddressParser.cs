using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Merlino.AddressParser
{
    public class AddressParser
    {
        private static readonly List<string> prefixes = new List<string>
                {
                    "via", "v.","v",
                    
                    "viale", "v.le", "vl.",
                    "piazza", "p.zza", "p.za",
                    "corso", "c.so",
                    "largo", "l.go",
                    "piazzale", "p.le","pzl",
                    "vicolo", "v.lo", "v.co",
                    "strada", "s.da","str","ss","sp", "s.s.","s.p.",
                    "stradale", "str.le",
                    "rotonda", "rot.",
                    "galleria", "g.le",
                    "lungomare", "l.mare","lma",
                    "lungolago", "l.lago",
                    "lungotevere", "lgt.",
                    "lungarno", "l.no",
                    "salita", "sal.","sal",
                    "discesa", "dis.","dis",
                    "contrada", "c.da","con",
                    "borgo", "b.go",
                    "località", "loc.","loc",
                    "traversa", "trav.", "trv",
                    "passaggio", "pass.",
                    "rione", "r.ne",
                    "frazione", "fraz.","frz","frz.",
                    "isola", "is.","is",
                    "colle", "c.le",
                    "costa", "c.ta",
                    "circonvallazione", "circ.ne",
                    "campo", "c.po",
                    "calata", "c.ta",
                    "alzaia", "alz.","alz",
                    "parco", "p.co",
                    "giardino", "g.no",
                    "porto", "p.to",
                    "molo", "m.lo"
                };


        private static readonly HashSet<string> provinceValide = new HashSet<string>
    {
        "TO", "VC", "NO", "CN", "AT", "AL", "AO", "IM", "SV", "GE", "SP", "VA", "CO", "SO", "MI", "BG", "BS", "PV",
        "CR", "MN", "BZ", "TN", "VR", "VI", "BL", "TV", "VE", "PD", "RO", "UD", "GO", "TS", "PC", "PR", "RE", "MO",
        "BO", "FE", "RA", "FC", "PU", "AN", "MC", "AP", "MS", "LU", "PT", "FI", "LI", "PI", "AR", "SI", "GR", "PG",
        "TR", "VT", "RI", "RM", "LT", "FR", "CE", "BN", "NA", "AV", "SA", "AQ", "TE", "PE", "CH", "CB", "FG", "BA",
        "TA", "BR", "LE", "PZ", "MT", "CS", "CZ", "RC", "TP", "PA", "ME", "AG", "CL", "EN", "CT", "RG", "SR", "SS",
        "NU", "CA", "PN", "IS", "OR", "BI", "LC", "LO", "RN", "PO", "KR", "VV", "VB", "MB", "FM", "BT", "SU"
    };

        public static string ExtractPrefix(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return null;

            // Rimuove spazi iniziali/finali
            address = address.Trim();

            // Rimuove i punti per facilitare il matching (ma non modifica l'indirizzo originale)
            string addressWithoutDots = address.Replace(".", "");

            foreach (var prefix in prefixes)
            {
                // Rimuovi i punti dal prefisso per il confronto
                string normalizedPrefix = prefix.Replace(".", "");

                // Confronta il prefisso letterale nell'indirizzo originale (case-insensitive)
                int prefixIndex = addressWithoutDots.IndexOf(normalizedPrefix, StringComparison.OrdinalIgnoreCase);

                if (prefixIndex == 0)
                {
                    // Restituisce il prefisso esattamente come appare nell'indirizzo originale
                    return address.Substring(prefixIndex, prefix.Length).Trim();
                }
            }

            return null; // Nessun prefisso corrispondente trovato
        }



        public static string RemoveParenthesesContent(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Usa una regex per trovare e rimuovere tutto ciò che è tra parentesi tonde
            string result = Regex.Replace(input, @"\([^)]*\)", "").Trim();

            return result;
        }


        public static string RemoveSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Mantiene solo lettere, numeri, spazi, slash (/), e trattini (escluso nel civico) nella stringa
            string result = Regex.Replace(input, @"[^a-zA-Z0-9\s\/\-]", "").Trim();

            return result;
        }


        public static string FindCivicNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            // Espressione regolare aggiornata per includere anche "sn" e "snc" in maiuscolo/minuscolo
            string pattern = @"\b\d+([A-Za-z]{1,2})?(\/[A-Za-z0-9]{1,3})?( ?[bisBISsnSNsncSNC]{1,3})?\b|(?i)\b(sn|snc)\b";

            // Cerca la prima occorrenza che corrisponde al pattern
            Match match = Regex.Match(input, pattern);

            // Se trovato, restituisci il numero civico
            if (match.Success)
            {
                return match.Value.Trim();
            }

            return null; // Nessun numero civico trovato
        }



        public static string RemoveProvincia(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Dividi la stringa in parole
            string[] parole = input.Split(new char[] { ' ', ',', '.', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            // Ricostruisci la stringa senza la provincia
            List<string> paroleRimanenti = new List<string>();

            foreach (string parola in parole)
            {
                // Aggiungi la parola alla lista se non è una provincia valida
                if (!provinceValide.Contains(parola.ToUpper()))
                {
                    paroleRimanenti.Add(parola);
                }
            }

            // Ricostruisci la stringa originale senza la provincia
            return string.Join(" ", paroleRimanenti).Trim();
        }


        public static string RemoveCAP(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Espressione regolare per trovare un numero di 4 o 5 cifre
            string pattern = @"\b\d{4,5}\b";

            // Usa una regex per sostituire tutte le occorrenze del CAP con una stringa vuota
            string result = Regex.Replace(input, pattern, "").Trim();

            // Restituisce la stringa senza il CAP
            return result;
        }


        public static string RemoveNonLetterCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Espressione regolare per mantenere solo lettere, apice singolo e spazi
            string pattern = @"[^a-zA-Z'\s]";

            // Usa una regex per sostituire tutti i caratteri che non siano lettere, apice singolo o spazi
            string result = Regex.Replace(input, pattern, "").Trim();

            return result;
        }

        public string getComuneFromIndirizzo(string indirizzo)
        {
            indirizzo = indirizzo.Trim();
            indirizzo = RemoveParenthesesContent(indirizzo);
            indirizzo = RemoveSpecialCharacters(indirizzo);

            string prefix = ExtractPrefix(indirizzo);
            string numCivico = FindCivicNumber(indirizzo);

            if (prefix == null || numCivico == null)
                return "";

            // Trova la posizione del prefisso e del numero civico nella stringa
            int prefixIndex = indirizzo.ToLower().IndexOf(prefix.ToLower());
            int numCivicoIndex = indirizzo.ToLower().IndexOf(numCivico.ToLower()) + numCivico.Length;

            // Estrai la parte dalla posizione del prefisso fino alla fine del numero civico
            try
            {
                string via = indirizzo.Substring(prefixIndex, numCivicoIndex - prefixIndex).Trim();
            }
            catch (Exception ex) {
                return "";
            }
            // Estrai tutto ciò che viene dopo il numero civico
            string secondaParte = indirizzo.Substring(numCivicoIndex).Trim();

            // Pulisci la seconda parte rimuovendo provincia e CAP
            string secondaParteClean = RemoveProvincia(secondaParte);
            string comune = RemoveCAP(secondaParteClean);

            comune = RemoveNonLetterCharacters(comune);

            return comune.ToString().Trim();
        }








    }


}