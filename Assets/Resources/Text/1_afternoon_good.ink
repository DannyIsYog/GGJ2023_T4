VAR nurture = 0
#Narrator

What would you like to say?
+   [You happy?]
        -> plant_silence
+   [Stare contest]
        -> plant_happy
+   [You're boring]
        -> plant_sad
        
=== plant_silence ===
You wait a little for the plant to respond.
But it never does.
Well, you guess it's still a plant.
~ nurture = nurture+1
-> day2_afternoon_end

=== plant_happy ===
You lock eyes with the plant and begin a staring contest.
o_o
o_o
o_o
30 seconds pass and neither of you looks like they're going to give up.
o_o
o_o
o_o
10 seconds pass and your eyes begin to burn.
o_o
o_o
;_;
As you start to cry, you realise that all of this was pointless, since the plant doesn't have eyes and can't play with you.
You declare yourself the winner by default.
~ nurture = nurture+1
-> day2_afternoon_end

=== plant_sad ===
A few of its leaves fall.
Might be totally unrelated to your comment.
But you get the feeling that the plant is saddened by it.
~ nurture = nurture-1
-> day2_afternoon_end

=== day2_afternoon_end ===
-> END