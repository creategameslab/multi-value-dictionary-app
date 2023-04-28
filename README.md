# multi-value-dictionary-app

A console application serving as an interface to manipulate an in-memory datastore (in this case simulated by a static collection). The goal of the application is to showcase design decisions to tackle a given problem, basic oo principles, data structures, and the beginnings of unit testing.

<sub>This solutions assumes we want to enforce uniqueness of values.</sub>

### Supported Commands

The following commands are not case sensitive.

<sub>*represent commands added to make it easier to test or for utility.</sub>

- **add** - Adds a member to a collection for a given key. Displays an error if the member already exists for the key.
- **allmembers** - Returns all the members in the dictionary. Returns nothing if there are none. Order is not guaranteed.
- **clear** - Removes all keys and all members from the dictionary.
- **items** - Returns all keys in the dictionary and all of their members. Returns nothing if there are none. Order is not guaranteed.
- **keyexists** - Returns whether a key exists or not.
- **keys** - Returns all the keys in the dictionary. Order is not guaranteed.
- **memberexists** - Returns whether a member exists within a key. Returns false if the key does not exist.
- **members** - Returns the collection of strings for the given key. Return order is not guaranteed. Returns an error if the key does not exists.
- **removeall** - Removes all members for a key and removes the key from the dictionary. Returns an error if the key does not exist.
- **remove** - Removes a member from a key. If the last member is removed from the key, the key is removed from the dictionary. If the key or member does not exist, displays an
error.
- seed* - seeds the datastore with test data.
- exit* - exits the console application
- help* - displays all the commands (Are of improvement would be to support help commandName to get examples of usage)

### Command Usage

Any command not listed does not require parameters.

- **add** - add *{keyname} {keyvame}* ex: add foo bar
- **keyexists** - keyexists *{keyname}* ex: keyexists foo
- **memberexists** - memberexists *{keyname} {keyvame}* ex: memberexists foo bar
- **members** - members *{keyname}* ex: members foo
- **removeall** - removeall *{keyname}* ex: removeall foo
- **remove** - remove *{keyname} {keyvame}* ex: remove foo bar

### Stack

Build with .NET Core 7 with a dependency on Microsoft.Extensions.DependencyInjection for DI setup.

### Screenshots 

![image](https://user-images.githubusercontent.com/118249228/235066062-0fec18cf-1c6d-48bf-96c8-a393aea4c7ee.png)


![image](https://user-images.githubusercontent.com/118249228/235064864-19c46bf8-9deb-4650-afd0-e0b6dcd127c4.png)
