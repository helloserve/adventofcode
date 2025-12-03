namespace helloserve.com.AdventOfCode;
public abstract class Base
{
	public abstract string Filename { get; set; }

	public T[] ReadMultiLineInput<T>(string filename, Func<string, T> parseLine)
	{
		var allText = File.ReadAllText(filename);
		return allText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
			.Select(o => parseLine(o))
			.ToArray();
	}

	public T[] ReadSingleLineInput<T>(string filename, Func<string, T> parseValue, char separator = ',')
	{
		var allText = File.ReadAllText(filename);
		return allText.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
			.Select(o => parseValue(o))
			.ToArray();
	}

	public abstract string Part1();
	public abstract string Part2();
}
