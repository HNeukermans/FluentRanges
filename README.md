# FluentRanges
Library for all sorts of ranges like numerics, dates and other value types.

## Why FluentRanges?
FluentRanges helps in code-modeling business rules like:
when patients whose ages ranges from 13 to 25 years then do ...
when an event occurs between now and 2 days later then do ...
when the amount of an invoice is 1000 with 5 as error margin then do ...

## What is FluentRanges?
FluentRanges contains classes and convenient extensions methods that make creating and working with ranges easy.
A range represents an area or extend between 2 limits: upper and lower limit. The width of the range is the distance/duration between both limits.
 - IntRange
 - DRange
 - DateTimeRange
 - DateTimeOffsetRange

### How do I use it?

### IsBetween/HappenedDuring
Here fluentRanges exposes convenient extension methods for integers, doubles, datetime(offset) to code against ranges.
 ''' if(age.IsBetween(new IntRange(13,25)) then {}
if(invoiceAmount.IsBetween(new IntRange(1000-5,1000+5)) then {}
if(eventDate.HappenedDuring(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)) then {}

### Intersects
if(new IntRange(5,25).Intersect(new IntRange(13,25)) then {}
if(invoiceAmount.IsBetween(new IntRange(1000-5,1000+5)) then {}
if(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2).Intersect(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)) then {}

### Intersection
var i = new IntRange(5,16).Intersection(new IntRange(13,25))  /* i == new IntRange(13,16) */
var d = new DateTimeRange(DateTime.Now.addDays(-1), DateTime.Now.AddDays(1).Intersection(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)) /* i == new DateTimeRange(DateTime.Now,DateTime.Now.AddDays(1)) */

### Offset
var i = new IntRange(5,16).Offset(2)  /* i == new IntRange(7,18) */
var d = new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(1)).Offset(TimeSpan.FromDays(1)) /* d == new DateTimeRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)) */

### Ranges are immutable
The limits of any range instance can not be changed. Methods like Offset, SetLower, SetUpper all return new Range instances
var i = new IntRange(5,16)
d = i.Offset(2) /* the limits of i have not been ofsetted.*/

### Ranges are equatable
Range are treated as equal only if both range instances have the same lower and upper limits
var i = new IntRange(5,16)
var d = ne IntRange(5,16);
d.Equals(i) /* returns true*/
Object.ReferenceEquals(i, d) /* returns false*/

### Ranges are sortable
var i = new IntRange(5,16)
var d = ne IntRange(5,16);


### ToString()
Console.WriteLine(new IntRange(5,16).ToString()) /* ==> "Lower:5, Upper:16, Width:11" */


### IsLesserThen/HappenedBefore
if(age.IsLesserThen(new IntRange(13,25)) then {}   /* age < 13 */
if(eventDate.HappenedBefore(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)) then {} /* eventDate < DateTime.Now */
if(invoiceAmount.IsLesserThen(new IntRange(1000-5,1000+5)) then {} /* invoiceAmount < 1000-5 */

### IsGreater/HappenedAfter
if(age.IsGreaterThen(new IntRange(13,25)) then {}   /* age > 25 */
if(eventDate.HappenedAfter(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)) then {} /* eventDate < DateTime.Now */
if(invoiceAmount.IsGreater(new IntRange(1000-5,1000+5)) then {} /* invoiceAmount > 1000+5 */


if(new IntRange(13,25).IsBetween(age)) then {}
if(new IntRange(1000-5,1000+5).IsBetween(invoiceAmount)) then {}
if(new DateTimeRange(DateTime.Now, DateTime.Now.AddDays(2)).HappenedDuring(eventDate)) then {}
 or using extension methods
 
 

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


