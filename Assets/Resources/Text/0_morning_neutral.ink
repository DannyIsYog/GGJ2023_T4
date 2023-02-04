VAR nurture = 0
#Narrator

What would you like to say?
+   [Hungry?]
        -> plant_wiggle
+   [You're cute!]
        -> plant_happy
+   [You're ugly]
        -> plant_cry
        
=== plant_wiggle ===
The plant wiggles as if it's about to answer.
It doesn't.
~ nurture = nurture+1
-> day1_morning_end

=== plant_happy ===
The plant wiggles in joy!
At least you think it's joy.
But you wouldn't know, since it doesn't speak.
~ nurture = nurture+1
-> day1_morning_end

=== plant_cry ===
The plant seems to wither at the comment.
You look closer to see what's happening.
The plant looks the same as before.
Must have been your imagination...
~ nurture = nurture-1
-> day1_morning_end

=== day1_morning_end ===
-> END