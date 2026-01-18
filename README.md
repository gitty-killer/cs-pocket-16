# cs-pocket-16

A small C# tool that computes text statistics for pocket.

## Objective
- Provide quick text metrics for pocket documents.
- Report top word frequencies for fast inspection.

## Use cases
- Validate pocket drafts for repeated terms before review.
- Summarize pocket notes when preparing reports.

## Usage
dotnet run --project TextStats.csproj -- data/sample.txt --top 5

## Output
- lines: total line count
- words: total word count
- chars: total character count
- top words: most frequent tokens (case-insensitive)

## Testing
- run `bash scripts/verify.sh`

## Notes
- Only ASCII letters and digits are treated as word characters.
