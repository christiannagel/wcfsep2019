# Lab 4

Behaviors

# Stateful Service

1. Create a Windows Service Library
2. Define a service contract similar to:

```csharp
interface ICalculatorService
{
    void Add(int value);
    int GetCompleteSum();
}
```

3. Create an implementation to implement the previously defined interface

The GetCompleteSum method should return the summary of previously called Add methods.

Test and run the service. Change the implementation, so that the GetCompleteSum method returns the remembered state.
