VAR nurture = 0
#Narrator

What would you like to say?
+   [Thirsty?]
        -> plant_silence
+   [*Pet it*]
        -> plant_happy
+   [You're boring]
        -> plant_sad
        
=== plant_silence ===
You wait a little bit for the plant to respond.
But it never does...
~ nurture = nurture+1
-> day2_morning_end

=== plant_happy ===
OUCH! You stung your finger on one of the spikes.
You look at the plant angry about its betrayal.
The plant looks happier, at least you think it does.
Did it sting you on purpose?
~ nurture = nurture+1
-> day2_morning_end

=== plant_sad ===
The color of the plant seems even duller now.
And if it didn't before, now it most definitely looks boring.
~ nurture = nurture-1
-> day2_morning_end

=== day2_morning_end ===
-> END