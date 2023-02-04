VAR nurture = 0
#Narrator

What would you like to say?
+   [You alive?]
        -> plant_nods
+   [You look good!]
        -> plant_happy
+   [You're boring]
        -> plant_stare
        
=== plant_nods===
The plant nods in affirmation.
Well, at least you think it does...
~ nurture = nurture+1
->day1_afternoon_end

=== plant_happy ===
The plant seems to blush.
Or maybe it's just the sun's golden hour giving it a reddish coloration.
Either way, you should be proud of your little plant.
~ nurture = nurture+1
->day1_afternoon_end

=== plant_stare ===
Feels like the plant is staring you down as if she's offended.
Which doesn't make a lot of sense, since it doesn't have any eyes.
~ nurture = nurture-1
->day1_afternoon_end

=== day1_afternoon_end ===
-> END