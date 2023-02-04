VAR nurture = 0
#Narrator

What would you like to say?
+   [Need anything?]
        -> plant_silence
+   [I'm so proud!]
        -> plant_happy
+   [Disgusting]
        -> plant_scary
        
=== plant_silence ===
You wait a few moments and the plant doesn't respond.
...
...
!
You remember that it's still a plant and it can't talk.
~ nurture = nurture+1
-> day2_night_end

=== plant_happy ===
You take a closer look at the plant's mouth and jagged teeth.
It's really creepy.
~ nurture = nurture+1
-> day2_night_end

=== plant_scary ===
As you begin speaking...
You get the feeling that you should probably stay quiet.
And decide not to say anything.
~ nurture = nurture-1
-> day2_night_end

=== day2_night_end ===
-> END