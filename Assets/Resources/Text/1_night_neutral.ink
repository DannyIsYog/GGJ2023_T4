VAR nurture = 0
#Narrator

What would you like to say?
+   [Need anything?]
        -> plant_silence
+   [Time to sleep]
        -> plant_happy
+   [Mistake]
        -> plant_cry
        
=== plant_silence ===
You wait a few moments and the plant doesn't respond.
...
...
!
You remember that it's still a plant and it can't talk.
~ nurture = nurture+1
-> day2_night_end

=== plant_happy ===
The plant wiggles a little bit and you can almost see it smile.
But that could just be your imagination.
~ nurture = nurture+1
-> day2_night_end

=== plant_cry ===
A drop of water slides down the side of the plant.
But you don't care.
~ nurture = nurture-1
-> day2_night_end

=== day2_night_end ===
-> END