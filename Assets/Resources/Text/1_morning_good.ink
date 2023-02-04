VAR nurture = 0
#Narrator

What would you like to say?
+   [A flower?]
        -> plant_silence
+   [You're pretty!]
        -> plant_happy
+   [Ewww!]
        -> plant_sad
        
=== plant_silence ===
...
No answer, it's still a plant.
But it's probably as surprised as you.
~ nurture = nurture+1
-> day2_morning_end

=== plant_happy ===
You see the color of the petals becoming more vibrant.
The plant becomes even more beautiful.
But that could just be the lighting.
~ nurture = nurture+1
-> day2_morning_end

=== plant_sad ===
The plant turns a little greyer and you see one of its petals wither a little.
What a weird coincidence.
~ nurture = nurture-1
-> day2_morning_end

=== day2_morning_end ===
-> END