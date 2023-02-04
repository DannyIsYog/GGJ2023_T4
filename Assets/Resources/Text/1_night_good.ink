VAR nurture = 0
#Narrator

What would you like to say?
+   [Need anything?]
        -> plant_silence
+   [Good job today!]
        -> plant_happy
+   [Disappointment]
        -> plant_sad
        
=== plant_silence ===
You wait a few moments and the plant doesn't respond.
...
...
!
You remember that it's still a plant and it can't talk.
~ nurture = nurture+1
-> day2_night_end

=== plant_happy ===
You take a closer look and see that the plant almost seems to shine in the moonlight glow.
~ nurture = nurture+1
-> day2_night_end

=== plant_sad ===
The plant doesn't answer.
Is it ignoring you?
Either way, you don't care.
~ nurture = nurture-1
-> day2_night_end

=== day2_night_end ===
-> END