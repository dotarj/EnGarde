# EnGarde 

EnGarde allows you to validate arguments using a fluent interface, for example:

```csharp
Ensure.That(() => value).Not.IsNull().And.StartsWith("En");
```

## Where can I get it?

Open the Visual Studio Package Manager Console and run the following command:

``
Install-Package EnGarde -pre
``
