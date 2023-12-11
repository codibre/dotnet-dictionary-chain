[![Actions Status](https://github.com/Codibre/dotnet-dictionary-chain/workflows/build/badge.svg)](https://github.com/Codibre/dotnet-dictionary-chain/actions)
[![Actions Status](https://github.com/Codibre/dotnet-dictionary-chain/workflows/test/badge.svg)](https://github.com/Codibre/dotnet-dictionary-chain/actions)
[![Actions Status](https://github.com/Codibre/dotnet-dictionary-chain/workflows/lint/badge.svg)](https://github.com/Codibre/dotnet-dictionary-chain/actions)
[![benchmark](https://github.com/Codibre/dotnet-dictionary-chain/actions/workflows/benchmark.yml/badge.svg)](https://github.com/Codibre/dotnet-dictionary-chain/actions/workflows/benchmark.yml)
[![Test Coverage](https://api.codeclimate.com/v1/badges/d97994e24ee6b162c626/test_coverage)](https://codeclimate.com/github/codibre/dotnet-dictionary-chain/test_coverage)
[![Maintainability](https://api.codeclimate.com/v1/badges/d97994e24ee6b162c626/maintainability)](https://codeclimate.com/github/codibre/dotnet-dictionary-chain/maintainability)

DictionaryChain extension for any .net project

## Why

Some highly accessed lists can benefit from a chained dictionary structure. Let's say you have three fields where you apply a equality comparison to choose between the items of the list. This operation, unless you do a binary search, will have a processing complexity of O(N). However, if you create an instance of chained dictionaries with depth 3, where the keys for each level are the values for each field, you can have the same result in O(1), as long as you have stablished uniqueness for the fields used to build this instance. If not, you can have a list with every list item that matches that path, and now you'll have to traverse much fewer items than before, as the items are distributed between the nodes!

Long story short, you can better the performance of you application by caching those chained dictionaries on strategic points, making much less list traversals throughout your application execution!

## How to use it

First, import the application namespace:

```c#
using Codibre.DictionaryChain
```

Now, you'll have the method **ToDictionaryChain** in every **IEnumerable<>** instance, and you just have to build it. Let's say you have a list with items that look like this:

```c#
struct Person {
    public string Name;
    public string City;
    public string State;
    public string Country;
}
```

If so, you may build a chain of dictionaries using the field **country**, **state** and **city**

```c#
var chain = list.ToDictionaryChain(x => x.Country, x => x.State, x => x.City);
```

The object chain will have a type like this:

```c#
IDictionary<string, IDictionary<string, IDictionary<string, List<Person>>>
```

So, if you want to find every listed person that lives in the country **US**, state of **Florida**, in the city of **Tallahassee**, you just have to do:

```c#
var persons = chain['US']['Florida']['Tallahassee'];
```

Or 

```c#
if (!chain.TryGetValue('US', out var stateChain)
 || !stateChain.TryGetValue('Florida', out var cityChain)
 || !cityChain.TryGetValue('Tallahassee', out var persons)
) return null;

return persons;
```

## Custom Leaf Values

Let's say you don't care about each individual value, but just one of them, or even some transformation based on the list of values that goes on each leaf. In that case, you can use the **ToDictionaryChain** variant where you specify the leaf construction:

```c#
var chain = list.ToDictionaryChain(
    () => 0, // Initializes the leaf value
    (acc, newItem) => acc + (newItem.Name.StartsWith("A") ? 1 : 0), // Transforms the leaf value based on the value of a new item
    x => x.Country, x => x.State, x.City)
```

That way, each leaf will have the number of people in each city with a name starting with "A"!

## Limitation

This package, for now, can only infer a strong chain of Dictionary types up to depth 7, which we hope will be enough for most cases. If you need more than that, though, the result object will be an instance of **ChainedDictionary**. If you use it directly, you'll need to do some type checking at each level to check (or cast) wether it is another level, or already the leaf, as this object doesn't have the type of every level strongly defined. The best way to deal with this situation is to use the method **MakeDictionary**, just after creating it, like this:

```c#
var chain list.ToDictionary(
    x => x.Country,
    x => x.State,
    x => x.City,
    x => x.BirthCountry,
    x => x.BirthState,
    x => x.BirthCity,
    x => x.Age,
    x => x.Sex,
).MakeDictionary<Dictionary<string, Dictionary<string,
    Dictionary<string,
        Dictionary<string,
            Dictionary<string,
                Dictionary<string,
                    Dictionary<int,
                        Dictionary<SexEnum, Person>
                    >
                >
            >
        >
    >
>>>()
```

MakeDictionary will do some reflection operations to convert the ChainedDictionary into an instance of the chain of Dictionaries provided as type argument. It does have an overload so, the idea is not to use it every time, but to load it in memory once, then letting it being memoized for some time, to avoid repeating the operation and optimizing the query.
Does it look good? No, it does not, but it is the better we could do with the current C# design, and it'll still speed up your application!

## License

Licensed under [MIT](https://en.wikipedia.org/wiki/MIT_License).
