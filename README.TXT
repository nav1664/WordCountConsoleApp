Thoughts
--------
1. Is a console application okay or was a UI expected? 
   Assumption console app is okay as the algorithm and style is probably what is being looked for.
2. Does the application need to scale in the future?
3. First thought is to use LINQ, with grouping & count.
4. Do a quick internet search to see what else is already avaliable:
   * http://en.wikipedia.org/wiki/Sentence_(linguistics)
   * http://courses.csail.mit.edu/6.006/spring11/lectures/lec01.pdf
   * http://stackoverflow.com/questions/7285714/linq-with-groupby-and-count


Issues and outstanding
------
* Multiple sentences not handled (eg split by ., ?, ! first)
* Abbreviations (eg I'd & they're) and quotes (Bob's cat, Sams') not handled very well.
* Performance not tested/measured
* Move WordUtils into separate assembly
* More usability add loop to main() or allow commmand line args or add UI