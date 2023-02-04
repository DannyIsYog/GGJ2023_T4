VAR nurture = 0
#Narrator

What would you like to say?
+   [You happy?]
        -> plant_silence
+   [Stare contest]
        -> plant_happy
+   [Hungry?]
        -> plant_angry
        
=== plant_silence ===
You wait a while for the plant to respond.
...
No awnser, it's still a plant
~ nurture = nurture+1
-> day2_afternoon_end

=== plant_happy ===
You lock eyes with the plant and begin your contest.
o_o
o_o
o_o
30 seconds pass and neither of you looks like they're going to give up.
o_o
o_o
o_o
10 seconds pass and your eyes begin to burn.
o_o
;_;
>_<
As you start to cry, you can't help but to close your eyes and lose the contest.
Not that it matters since the plant doesn't have eyes.
However, the plant looks a lot creepier than you remember.
~ nurture = nurture+1
-> day2_afternoon_end

=== plant_angry ===
It opens its mouth slightly and starts salivating.
The plant looks threatening.
You get a bad feeling and regret asking what you asked.
~ nurture = nurture-1
-> day2_afternoon_end

=== day2_afternoon_end ===
-> END