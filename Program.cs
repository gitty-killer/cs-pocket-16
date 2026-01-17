using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class TextStats {
    static List<string> Tokenize(string text) {
        return Regex.Matches(text.ToLowerInvariant(), "[A-Za-z0-9]+")
            .Select(m => m.Value)
            .ToList();
    }

    static int Main(string[] args) {
        if (args.Length < 1) {
            Console.Error.WriteLine("usage: TextStats <path> [--top N]");
            return 1;
        }
        int top = 10;
        string path = null;
        for (int i = 0; i < args.Length; i++) {
            if (args[i] == "--top" && i + 1 < args.Length) {
                top = int.Parse(args[++i]);
            } else if (path == null) {
                path = args[i];
            }
        }

        string text = File.ReadAllText(path);
        int lines = string.IsNullOrEmpty(text) ? 0 : text.Count(c => c == '\n') + 1;
        var words = Tokenize(text);
        var counts = new Dictionary<string, int>();
        foreach (var w in words) {
            counts[w] = counts.TryGetValue(w, out var c) ? c + 1 : 1;
        }
        var sorted = counts.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key).Take(top);

        Console.WriteLine($"lines: {lines}");
        Console.WriteLine($"words: {words.Count}");
        Console.WriteLine($"chars: {text.Length}");
        Console.WriteLine("top words:");
        foreach (var kv in sorted) {
            Console.WriteLine($"  {kv.Key}: {kv.Value}");
        }
        return 0;
    }
}
