# FluentRanges
Library for all sorts of ranges like numerics, dates and other value types.  


## Why FluentRanges?
Offers a code model for representing a 1-dimensional area between 2 limits. 
* This can help when you want to write rules fluently like:  
  **'x is between'**  
  **'x happened during a period'** 
* Compute **intersections** between two or more 1-dimensional scalar areas.   
* *Rich behavior* classes that allow **sorting, comparing, offset, inflate**
	
## What is FluentRanges?
FluentRanges contains set of **rich-behavior** classes and convenient extensions methods that make creating and working with ranges easy.

 - IntRange
 - DRange
 - DateTimeRange
 - DateTimeOffsetRange

### How do I use it?

#### IsBetween/HappenedDuring
FluentRanges offers convenient extension methods for integers, doubles, datetime(offset) to code against ranges **fluently**.
```
if(age.IsBetween(new IntRange(13,25)) then {}
if(invoiceAmount.IsBetween(new IntRange(1000-5,1000+5)) then {}
if(eventDate.HappenedDuring(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)) then {}
```
#### Intersects
```
if(new IntRange(5,25).Intersect(new IntRange(13,25)) then {}
if(invoiceAmount.IsBetween(new IntRange(1000-5,1000+5)) then {}
if(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2).Intersect(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)) then {}
```
#### Intersections
```
var i = new IntRange(5,16).Intersection(new IntRange(13,25))  /* i == new IntRange(13,16) */
var d = new DateTimeRange(DateTime.Now.addDays(-1), DateTime.Now.AddDays(1).Intersection(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)) /* i == new DateTimeRange(DateTime.Now,DateTime.Now.AddDays(1)) */
```
#### Offset
```
var i = new IntRange(5,16).Offset(2)  /* i == new IntRange(7,18) */
var d = new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(1)).Offset(TimeSpan.FromDays(1)) /* d == new DateTimeRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)) */
```
#### Ranges are immutable
The limits of any range instance can not be changed. Methods like Offset, SetLower, SetUpper all return new Range instances
```
var i = new IntRange(5,16)
d = i.Offset(2) /* the limits of i have not been ofsetted.*/
```
#### Ranges are equatable
Range are treated as equal only if both range instances have the same lower and upper limits
```
var i = new IntRange(5,16)
var d = ne IntRange(5,16);
d.Equals(i) /* returns true*/
Object.ReferenceEquals(i, d) /* returns false*/
```

#### Ranges are sortable
```
var i = new IntRange(5,16)
var d = ne IntRange(5,16);
```

#### override ToString()
```
Console.WriteLine(new IntRange(5,16).ToString()) /* ==> "Lower:5, Upper:16, Width:11" */
```

### HappenedBefore/HappenedAfter
In scenarios where you want to know if a given date happened before or after the period defined by the daterange 
```
if(eventDate.HappenedBefore(DateTimeRange.StartsAt(DateTime.Now, TimeSpan.FromDays(1)) then {} /* eventDate < DateTime.Now */
if(eventDate.HappenedAfter(DateTimeRange.StartsAt(DateTime.Now, TimeSpan.FromDays(1)) then {} /* eventDate > DateTime.Now.AddDays(1) */
if(invoiceAmount.IsLesserThen(new IntRange(1000-5,1000+5)) then {} /* invoiceAmount < 1000-5 */
```
### IsLesser/IsGreater
```
if(age.IsLesserThen(new IntRange(13,25)) then {}   /* age < 13 */
if(age.IsGreaterThen(new IntRange(13,25)) then {}   /* age > 25 */
```

 
 

## What are the charateristics of an xRange class?
####Properties:
All xRange, with exception DateTime(Offset)Range, classes have these properties:
 Begin:
 End:
 Width:

For DateTime(Offset)Range similar properties exists, except these are named differently.
  Start:
  Stop:
  Duration:

####Behavior:
 Intersects

Specify provides you with a consistent Given When Then, class per scenario, style for all of your tests, with the same high quality BDDfy HTML reports for all.

## Where do you get it?
The source code is available on GitHub, and you can download the compiled library with NuGet.


