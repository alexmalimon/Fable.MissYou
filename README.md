# Fable.MissYou 

[MissYou](https://github.com/Bahlaouane-Hamza/I-Miss-You/) integration with Fable, made with :heart:

## Installation
- Install this library from nuget
```
paket add Fable.MissYou --project /path/to/Project.fsproj
```
### Code Sample
This is an example of `MissYou` notification.

```fs
let options =
    { Title = Some "I miss you!"
      FaviconHref = Some "path/to/favicon.ico" }

Miss.register options
```