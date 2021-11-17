[![martinstm - benchmarks](https://img.shields.io/static/v1?label=martinstm&message=benchmarks&color=blue&logo=github)](https://github.com/martinstm/benchmarks "Go to GitHub repo") [![stars - benchmarks](https://img.shields.io/github/stars/martinstm/benchmarks?style=social)](https://github.com/martinstm/benchmarks) [![forks - benchmarks](https://img.shields.io/github/forks/martinstm/benchmarks?style=social)](https://github.com/martinstm/benchmarks)
[![.NET](https://github.com/martinstm/benchmarks/workflows/.NET/badge.svg)](https://github.com/martinstm/benchmarks/actions?query=workflow:".NET") [![License](https://img.shields.io/badge/License-MIT-blue)](#license)

[![Medium -  Click here](https://img.shields.io/badge/Medium-_Click_here-2ea44f?logo=medium)](https://medium.com/@martinstm)

# Performance Wars - C#

This is the repository with all test cases from Performance Wars - C#. It is a series of posts from  [my Medium page](https://medium.com/@martinstm)

## .NET Version

Until now, all the tests run on **.NET 5** version.

## BenchmarkDotNet

The performance tests were done using the BenchmarkDotNet library. You can find all the details and documentation [here](https://benchmarkdotnet.org/articles/overview.html).

## How to run?

The `Program.cs` file has the definition of all the benchmark classes. You just need to uncomment the desired classes and run. 

```
$ dotnet run Benchmarks.csproj -c release
```

I advise you to run them one at a time to see results faster. Keep in mind that some tests take some time to complete.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
