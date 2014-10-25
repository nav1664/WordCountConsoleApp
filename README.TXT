Thoughts
--------
1. Is a console application okay or was a UI expected? 
   Assumption console app is okay as the algorithm and style is probably what is being looked for.
2. Does the application need to scale in the future?
3. Could iterate string as charactor array for performace, or use RegEx.Matches or use LINQ (with grouping & count).
4. Do a quick internet search to see what else is already avaliable:
   * http://en.wikipedia.org/wiki/Sentence_(linguistics)
   * http://courses.csail.mit.edu/6.006/spring11/lectures/lec01.pdf
   * http://stackoverflow.com/questions/7285714/linq-with-groupby-and-count
   * http://www.dotnetperls.com/word-count


Issues and outstanding
------
* Multiple sentences not handled
* Abbreviations (eg I'd & they're) and quotes (Bob's cat, Sams') not handled very well.
* Performance not tested/measured
* Move WordUtils into separate assembly
* More usability add loop to main() or allow commmand line args or add UI
* Started looking at iteration solution, the code wasn't tidy as the link code.