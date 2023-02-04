VAR nurture = 0
#Narrator

What would you like to say?
+   [Need anything?]
        -> plant_silence
+   [Beautiful!]
        -> plant_happy
+   [Disgusting]
        -> plant_angry
        
=== plant_silence===
The plant doesn't respond.
Because you know...
It's a plant.
~ nurture = nurture+1
->day1_night_end

=== plant_happy ===
You start dancing with joy.
And you are almost certain the plant is wiggling with you.
Maybe it's just the wind.
But whatever it was, it stopped now. 
~ nurture = nurture+1
->day1_night_end

=== plant_angry ===
You feel goose bumps in the back of your neck.
You can't shake the feeling that you should probably sleep with one eye open tonight.
~ nurture = nurture-1
->day1_night_end

=== day1_night_end ===
-> END