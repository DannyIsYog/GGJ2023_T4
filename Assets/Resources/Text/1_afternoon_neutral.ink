VAR nurture = 0
#Narrator

What would you like to say?
+   [You happy?]
        -> plant_silence
+   [Stare contest]
        -> plant_happy
+   [You look ugly]
        -> plant_sad
        
=== plant_silence ===
A moment passes and the plant seems emotionless.
Well, you guess it's still a plant.
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
Not that it matters since the plant doesn't have any eyes and couldn't play with you to begin with.
~ nurture = nurture+1
-> day2_afternoon_end

=== plant_sad ===
If a plant could look sad, it would probably look like yours.
~ nurture = nurture-1
-> day2_afternoon_end

=== day2_afternoon_end ===
-> END