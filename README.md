# BearLibNET

[BearLibTerminal](https://github.com/cfyzium/bearlibterminal) wrapper for .NET 5. BearLibNET is designed to stay as close to the original BearLibTerminal API as possible. It contains minimal recreations of the structs from System.Drawing that BearLibTerminal's original C# wrapper used. 

# Usage

1. Install BearLibNET from [nuget.org](https://www.nuget.org/packages/bearlibNET) or using your IDE's nuget package manager
2. Copy the [pre-compiled library](http://foo.wyrd.name/en:bearlibterminal#download) file(s) to your project's directory
3. Make sure the library files(s) are copied to the build directory. The easiest way to do this is to add them to your csproj file or set them to "Copy If Newer" in your IDE.

# Example

Below is a minimal example of BearLibNET's API:

```csharp
using BearLibTerminal;

namespace Example
{
	public class Program
	{
		public static void Main()
		{
			Terminal.Open();
			Terminal.Clear();
			Terminal.Print(1, 1, "Hello World!");
			Terminal.Refresh();

			while (Terminal.Read() != Terminal.TK_CLOSE) {

			}

			Terminal.Close();
		}
	}
}
```


# Licensing

BearLibNET is MIT licensed and includes the original BearLibTerminal's license at the top of `BearLibTerminal.cs`
