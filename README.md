Proof of Concept about perform operation in sample containers.

## Usage

```

Compilation: dotnet build TransportManager.sln

Test execution: execute_tests.bat

Usage: dotnet TransportManager.Application [arguments]

Arguments:
  op          	Operation to execute (Can concate many operations. Example (0,1,3)
  id			Sample container identification
  
Operations availables:
  0				Sample arrive
  1				Sample with no priority
  2				Sample with max priority
  3				Sample leave
  
Example
 dotnet TransportManager.Application -op 0,1,3 -id 12345