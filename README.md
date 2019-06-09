Principal_Assesment

## Usage

```
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