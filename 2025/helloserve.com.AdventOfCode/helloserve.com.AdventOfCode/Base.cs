namespace helloserve.com.AdventOfCode;
public abstract class Base
{
	public T[] ReadInput<T>(string filename, Func<string, T> parseLine)
	{
		var allText = File.ReadAllText(filename);
		return allText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
			.Select(o => parseLine(o))
			.ToArray();
	}

	public abstract string Part1(string filename);
	public abstract string Part2(string filename);
}
